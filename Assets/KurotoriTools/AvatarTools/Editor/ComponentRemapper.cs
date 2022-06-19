using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace KurotoriTools
{
    using BonePathList = Dictionary<string, Transform>;

    public struct BonePathInfo
    {
        public BonePathList pathList;
        public Transform rootBone;
    };

    public interface IComponentRemapper
    {

        void Remap(BonePathInfo assembledPathInfo);
    }

    public static class ComponentRemapperFactory
    {
        public static IComponentRemapper CreateComponentRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            if (component == null) return null;

            var type = component.GetType();
            
            if (type == typeof(AimConstraint))
            {
                return new AimConstraintReMapper(component, target, partsPathInfo);
            }
            if (type == typeof(LookAtConstraint))
            {
                return new LookAtConstraintReMapper(component, target, partsPathInfo);
            }
            if (type == typeof(ParentConstraint))
            {
                return new ParentConstraintRemapper(component, target, partsPathInfo);
            }
            if (type == typeof(PositionConstraint))
            {
                return new PositionConstraintRemapper(component, target, partsPathInfo);
            }
            if (type == typeof(RotationConstraint))
            {
                return new RotationConstraintRemapper(component, target, partsPathInfo);
            }
            if (type == typeof(ScaleConstraint))
            {
                return new ScaleConstraintRemapper(component, target, partsPathInfo);
            }

            if (type.Name.Equals("DynamicBone"))
            {
                return new DynamicBoneRemapper(component, target, partsPathInfo);
            }

            if (type.Name.Equals("DynamicBoneColliderBase"))
            {
                return new DynamicBoneColliderRemapper(component, target,partsPathInfo);
            }

            return null;
        }
    }

    public class DynamicBoneRemapper : IComponentRemapper
    {
        private Component component;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public DynamicBoneRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            this.component = component;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        

        public void Remap(BonePathInfo assembledPathInfo)
        {
            Type dynamicBoneType = KurotoriUtility.GetTypeByClassName("DynamicBone");
            Component assembledComponent = target.AddComponent(dynamicBoneType);

            {   // ルートのマッピング
                Transform root = (Transform)KurotoriUtility.GetFieldValueByName(component, "m_Root", dynamicBoneType);

                var rootBonePath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, root);

                Transform newRoot;
                if (assembledPathInfo.pathList.TryGetValue(rootBonePath, out newRoot))
                {
                    KurotoriUtility.SetFieldValueByName(assembledComponent, "m_Root", newRoot, dynamicBoneType);
                }
            }

            {   // コライダーのマッピング
                var colliders = KurotoriUtility.GetFieldValueByName(component, "m_Colliders", dynamicBoneType);
                var colliderList = KurotoriUtility.GetListPropertyByName(colliders);
                
                var colliderTransformList = new List<Transform>();
                
                foreach (var collider in colliderList)
                {
                    Type DBColliderType = collider.GetType();
                    var transform = (Transform)DBColliderType.GetProperty("transform").GetValue(collider);

                    var colliderBonePath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, transform);
                    Transform newColliderTransform;
                    if(assembledPathInfo.pathList.TryGetValue(colliderBonePath, out newColliderTransform))
                    {
                        colliderTransformList.Add(newColliderTransform);
                    }
                }

                var dynamicBoneColliderType = KurotoriUtility.GetTypeByClassName("DynamicBoneColliderBase");
                if (dynamicBoneColliderType != null)
                {
                    Type openedType = typeof(List<>);
                    Type closedType = openedType.MakeGenericType(dynamicBoneColliderType);
                    object newDBColliderList = Activator.CreateInstance(closedType);
                    Type dbColliderListType = newDBColliderList.GetType();
                    var addMethod = dbColliderListType.GetMethod("Add");

                    foreach (var collider in colliderTransformList)
                    {
                        var colliderComponent = collider.gameObject.GetComponent(dynamicBoneColliderType);
                        addMethod.Invoke(newDBColliderList, new object[] { colliderComponent });
                    }

                    KurotoriUtility.SetFieldValueByName(assembledComponent, "m_Colliders", newDBColliderList, dynamicBoneType);
                }
                else
                {
                    KurotoriUtility.OutputLog(LogType.ERROR, "DynamicBoneColliderのリマップに失敗しました。最新のDynamicBoneを正しくインポートできていない可能性があります。");
                }
            }

            {   // 除外オブジェクトのマッピング
                var exclusions = KurotoriUtility.GetFieldValueByName(component, "m_Exclusions", dynamicBoneType);
                var exclusionsList = KurotoriUtility.GetListPropertyByName(exclusions);

                var newExclusionsList = new List<Transform>();

                foreach (var exclusion in exclusionsList)
                {
                    if(exclusion != null)
                    {
                        var exclusionPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, (Transform)exclusion);
                        Transform newExclusionTransform;
                        if(assembledPathInfo.pathList.TryGetValue(exclusionPath, out newExclusionTransform))
                        {
                            newExclusionsList.Add(newExclusionTransform);
                        }
                    }
                }

                KurotoriUtility.SetFieldValueByName(assembledComponent, "m_Exclusions", newExclusionsList,dynamicBoneType);
            }

            KurotoriUtility.CopyFieldValue("m_Damping",             component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_DampingDistrib",      component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_DistanceToObject",    component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_DistantDisable",      component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_Elasticity",          component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_ElasticityDistrib",   component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_EndLength",           component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_EndOffset",           component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_Force",               component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_FreezeAxis",          component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_Gravity",             component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_Inert",               component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_InertDistrib",        component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_Radius",              component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_RadiusDistrib",       component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_Stiffness",           component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_StiffnessDistrib",    component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_UpdateMode",          component, assembledComponent, dynamicBoneType);
            KurotoriUtility.CopyFieldValue("m_UpdateRate",          component, assembledComponent, dynamicBoneType);
        }
    }

    public class DynamicBoneColliderRemapper : IComponentRemapper
    {
        private Component component;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public DynamicBoneColliderRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            this.component = component;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            Type dynamicBoneColliderType = KurotoriUtility.GetTypeByClassName("DynamicBoneColliderBase");
            if(dynamicBoneColliderType == null)
            {
                KurotoriUtility.OutputLog(LogType.ERROR, "DynamicBoneColliderBaseが見つかりません。最新のDynamicBoneを正しくインポートできていない可能性があります。");
            }

            Component assembledComponent = target.AddComponent(dynamicBoneColliderType);

            if (component.GetType() == KurotoriUtility.GetTypeByClassName("DynamicBoneCollider"))
            {
                KurotoriUtility.CopyFieldValue("m_Direction",   component, assembledComponent, dynamicBoneColliderType);
                KurotoriUtility.CopyFieldValue("m_Center",      component, assembledComponent, dynamicBoneColliderType);
                KurotoriUtility.CopyFieldValue("m_Bound",       component, assembledComponent, dynamicBoneColliderType);
                KurotoriUtility.CopyFieldValue("m_Radius",      component, assembledComponent, dynamicBoneColliderType);
                KurotoriUtility.CopyFieldValue("m_Height",      component, assembledComponent, dynamicBoneColliderType);
            }
        }
    }

    public class AimConstraintReMapper : IComponentRemapper
    {
        private AimConstraint constraint;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public AimConstraintReMapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            constraint = component as AimConstraint;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            AimConstraint assembledComponent = target.AddComponent<AimConstraint>();

            assembledComponent.aimVector = constraint.aimVector;
            assembledComponent.locked = constraint.locked;
            assembledComponent.rotationAtRest = constraint.rotationAtRest;
            assembledComponent.rotationAxis = constraint.rotationAxis;
            assembledComponent.rotationOffset = constraint.rotationOffset;
            assembledComponent.upVector = constraint.upVector;
            assembledComponent.weight = constraint.weight;

            if (constraint.worldUpObject != null)
            {
                var worldUpObjectPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, constraint.worldUpObject);

                Transform assembledWorldUpObject;
                if (assembledPathInfo.pathList.TryGetValue(worldUpObjectPath, out assembledWorldUpObject))
                {
                    assembledComponent.worldUpObject = assembledWorldUpObject;
                }
                else
                {
                    KurotoriUtility.OutputLog(LogType.WARNING, "AimConstraintのworldUpObjectの参照の書き換えに失敗しました。正しく結合できていない可能性があります。");
                }
            }

            assembledComponent.worldUpType = constraint.worldUpType;
            assembledComponent.worldUpVector = constraint.worldUpVector;

            for (int i = 0; i < constraint.sourceCount; ++i)
            {
                var constraintSource = constraint.GetSource(i);
                Transform sourceTransform = constraintSource.sourceTransform;

                if (sourceTransform != null)
                {
                    var srcTransPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, sourceTransform);
                    Transform sameObject;

                    if (assembledPathInfo.pathList.TryGetValue(srcTransPath, out sameObject))
                    {
                        ConstraintSource source = constraintSource;
                        source.sourceTransform = sameObject;
                        assembledComponent.AddSource(source);
                    }
                }
            }

            assembledComponent.constraintActive = constraint.constraintActive;
        }
    }

    public class LookAtConstraintReMapper : IComponentRemapper
    {
        private LookAtConstraint constraint;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public LookAtConstraintReMapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            constraint = component as LookAtConstraint;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            LookAtConstraint assembledComponent = target.AddComponent<LookAtConstraint>();

            assembledComponent.locked = constraint.locked;
            assembledComponent.roll = constraint.roll;
            assembledComponent.rotationAtRest = constraint.rotationAtRest;
            assembledComponent.rotationOffset = constraint.rotationOffset;
            assembledComponent.useUpObject = constraint.useUpObject;
            assembledComponent.weight = constraint.weight;

            if (constraint.worldUpObject != null)
            {
                var worldUpObjectPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, constraint.worldUpObject);

                Transform assembledWorldUpObject;
                if (assembledPathInfo.pathList.TryGetValue(worldUpObjectPath, out assembledWorldUpObject))
                {
                    assembledComponent.worldUpObject = assembledWorldUpObject;
                }
                else
                {
                    KurotoriUtility.OutputLog(LogType.WARNING, "LookAtConstraintのworldUpObjectの参照の書き換えに失敗しました。正しく結合できていない可能性があります。");
                }
            }

            for (int i = 0; i < constraint.sourceCount; ++i)
            {
                var constraintSource = constraint.GetSource(i);
                Transform sourceTransform = constraintSource.sourceTransform;

                if (sourceTransform != null)
                {
                    var srcTransPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, sourceTransform);
                    Transform sameObject;

                    if (assembledPathInfo.pathList.TryGetValue(srcTransPath, out sameObject))
                    {
                        ConstraintSource source = constraintSource;
                        source.sourceTransform = sameObject;
                        assembledComponent.AddSource(source);
                    }
                }
            }

            assembledComponent.constraintActive = constraint.constraintActive;
        }
    }

    public class ParentConstraintRemapper : IComponentRemapper
    {
        private ParentConstraint constraint;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public ParentConstraintRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            constraint = component as ParentConstraint;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            ParentConstraint assembledComponent = target.AddComponent<ParentConstraint>();

            assembledComponent.locked = constraint.locked;
            assembledComponent.rotationAtRest = constraint.rotationAtRest;
            assembledComponent.rotationAxis = constraint.rotationAxis;
            assembledComponent.rotationOffsets = constraint.rotationOffsets;
            assembledComponent.translationAtRest = constraint.translationAtRest;
            assembledComponent.translationAxis = constraint.translationAxis;
            assembledComponent.translationOffsets = constraint.translationOffsets;
            assembledComponent.weight = constraint.weight;

            for (int i = 0; i < constraint.sourceCount; ++i)
            {
                var constraintSource = constraint.GetSource(i);
                Transform sourceTransform = constraintSource.sourceTransform;

                if (sourceTransform != null)
                {
                    var srcTransPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, sourceTransform);
                    Transform sameObject;

                    if (assembledPathInfo.pathList.TryGetValue(srcTransPath, out sameObject))
                    {
                        ConstraintSource source = constraintSource;
                        source.sourceTransform = sameObject;
                        assembledComponent.AddSource(source);
                    }
                }
            }

            assembledComponent.constraintActive = constraint.constraintActive;
        }
    }

    public class PositionConstraintRemapper : IComponentRemapper
    {
        private PositionConstraint constraint;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public PositionConstraintRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            constraint = component as PositionConstraint;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            PositionConstraint assembledComponent = target.AddComponent<PositionConstraint>();

            assembledComponent.locked = constraint.locked;
            assembledComponent.translationAtRest = constraint.translationAtRest;
            assembledComponent.translationAxis = constraint.translationAxis;
            assembledComponent.translationOffset = constraint.translationOffset;
            assembledComponent.weight = constraint.weight;

            for (int i = 0; i < constraint.sourceCount; ++i)
            {
                var constraintSource = constraint.GetSource(i);
                Transform sourceTransform = constraintSource.sourceTransform;

                if (sourceTransform != null)
                {
                    var srcTransPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, sourceTransform);
                    Transform sameObject;

                    if (assembledPathInfo.pathList.TryGetValue(srcTransPath, out sameObject))
                    {
                        ConstraintSource source = constraintSource;
                        source.sourceTransform = sameObject;
                        assembledComponent.AddSource(source);
                    }
                }
            }

            assembledComponent.constraintActive = constraint.constraintActive;
        }
    }

    public class RotationConstraintRemapper : IComponentRemapper
    {
        private RotationConstraint constraint;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public RotationConstraintRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            constraint = component as RotationConstraint;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            RotationConstraint assembledComponent = target.AddComponent<RotationConstraint>();

            assembledComponent.locked = constraint.locked;
            assembledComponent.rotationAtRest = constraint.rotationAtRest;
            assembledComponent.rotationAxis = constraint.rotationAxis;
            assembledComponent.rotationOffset = constraint.rotationOffset;
            assembledComponent.weight = constraint.weight;

            for (int i = 0; i < constraint.sourceCount; ++i)
            {
                var constraintSource = constraint.GetSource(i);
                Transform sourceTransform = constraintSource.sourceTransform;

                if (sourceTransform != null)
                {
                    var srcTransPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, sourceTransform);
                    Transform sameObject;

                    if (assembledPathInfo.pathList.TryGetValue(srcTransPath, out sameObject))
                    {
                        ConstraintSource source = constraintSource;
                        source.sourceTransform = sameObject;
                        assembledComponent.AddSource(source);
                    }
                }
            }

            assembledComponent.constraintActive = constraint.constraintActive;
        }
    }

    public class ScaleConstraintRemapper : IComponentRemapper
    {
        private ScaleConstraint constraint;
        private GameObject target;
        private BonePathInfo partsPathInfo;

        public ScaleConstraintRemapper(Component component, GameObject target, BonePathInfo partsPathInfo)
        {
            constraint = component as ScaleConstraint;
            this.target = target;
            this.partsPathInfo = partsPathInfo;
        }

        public void Remap(BonePathInfo assembledPathInfo)
        {
            ScaleConstraint assembledComponent = target.AddComponent<ScaleConstraint>();

            assembledComponent.locked = constraint.locked;
            assembledComponent.scaleAtRest = constraint.scaleAtRest;
            assembledComponent.scalingAxis = constraint.scalingAxis;
            assembledComponent.scaleOffset = constraint.scaleOffset;
            assembledComponent.weight = constraint.weight;

            for (int i = 0; i < constraint.sourceCount; ++i)
            {
                var constraintSource = constraint.GetSource(i);
                Transform sourceTransform = constraintSource.sourceTransform;

                if (sourceTransform != null)
                {
                    var srcTransPath = KurotoriUtility.GetBonePath(partsPathInfo.rootBone, sourceTransform);
                    Transform sameObject;

                    if (assembledPathInfo.pathList.TryGetValue(srcTransPath, out sameObject))
                    {
                        ConstraintSource source = constraintSource;
                        source.sourceTransform = sameObject;
                        assembledComponent.AddSource(source);
                    }
                }
            }

            assembledComponent.constraintActive = constraint.constraintActive;
        }
    }


}
