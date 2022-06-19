using UnityEngine;
using System.Collections.Generic;

namespace uLipSync
{

[ExecuteAlways]
public class uLipSyncBlendShape : MonoBehaviour
{
    [System.Serializable]
    public class BlendShapeInfo
    {
        public string phoneme;
        public int index = -1;
        public float maxWeight = 1f;

        public float weight { get; set; } = 0f;
        public float weightVelocity { get; set; } = 0f;
    }

    public SkinnedMeshRenderer skinnedMeshRenderer;
    public List<BlendShapeInfo> blendShapes = new List<BlendShapeInfo>();
    public float minVolume = -2.5f;
    public float maxVolume = -1.5f;
    [Range(0f, 0.3f)] public float smoothness = 0.05f;

    LipSyncInfo _info = new LipSyncInfo();
    bool _lipSyncUpdated = false;
    float _volume = 0f;
    float _openCloseVelocity = 0f;
    protected float volume => _volume;

#if UNITY_EDITOR
    bool _isAnimationBaking = false;
    float _animBakeDeltaTime = 1f / 60;
#endif

    public void OnLipSyncUpdate(LipSyncInfo info)
    {
        _info = info;
        _lipSyncUpdated = true;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (_isAnimationBaking) return;
#endif
        UpdateVolume();
        UpdateVowels();
        _lipSyncUpdated = false;
    }

    void LateUpdate()
    {
#if UNITY_EDITOR
        if (_isAnimationBaking) return;
#endif
        LateUpdateBlendShapes();
    }

    float SmoothDamp(float value, float target, ref float velocity)
    {
#if UNITY_EDITOR
        return Mathf.SmoothDamp(value, target, ref velocity, smoothness, Mathf.Infinity, _animBakeDeltaTime);
#else
        return Mathf.SmoothDamp(value, target, ref velocity, smoothness);
#endif
    }

    void UpdateVolume()
    {
        float normVol = 0f;
        if (_lipSyncUpdated && _info.rawVolume > 0f)
        {
            normVol = Mathf.Log10(_info.rawVolume);
            normVol = (normVol - minVolume) / Mathf.Max(maxVolume - minVolume, 1e-4f);
            normVol = Mathf.Clamp(normVol, 0f, 1f);
        }
#if UNITY_EDITOR
        _volume = SmoothDamp(_volume, normVol, ref _openCloseVelocity);
#else
        _volume = SmoothDamp(_volume, normVol, ref _openCloseVelocity);
#endif
    }

    void UpdateVowels()
    {
        float sum = 0f;
        var ratios = _info.phonemeRatios;

        foreach (var bs in blendShapes)
        {
            float targetWeight = 0f;
            if (ratios != null && !string.IsNullOrEmpty(bs.phoneme)) 
            {
                ratios.TryGetValue(bs.phoneme, out targetWeight);
            }
            float weightVel = bs.weightVelocity;
            bs.weight = SmoothDamp(bs.weight, targetWeight, ref weightVel);
            bs.weightVelocity = weightVel;
            sum += bs.weight;
        }

        foreach (var bs in blendShapes)
        {
            bs.weight = sum > 0f ? bs.weight / sum : 0f;
        }
    }

    protected virtual void LateUpdateBlendShapes()
    {
        if (!skinnedMeshRenderer) return;

        foreach (var bs in blendShapes)
        {
            if (bs.index < 0) continue;
            skinnedMeshRenderer.SetBlendShapeWeight(bs.index, 0f);
        }

        foreach (var bs in blendShapes)
        {
            if (bs.index < 0) continue;
            float weight = skinnedMeshRenderer.GetBlendShapeWeight(bs.index);
            weight += bs.weight * bs.maxWeight * volume * 100;
            skinnedMeshRenderer.SetBlendShapeWeight(bs.index, weight);
        }
    }

#if UNITY_EDITOR
    public void OnAnimationBakeStart()
    {
        _lipSyncUpdated = true;
        _isAnimationBaking = true;
    }

    public void OnAnimationBakeUpdate(LipSyncInfo info, float dt)
    {
        _info = info;
        _animBakeDeltaTime = dt;
        UpdateVolume();
        UpdateVowels();
    }

    public Dictionary<int, float> GetAnimationBakeBlendShapes()
    {
        var weights = new Dictionary<int, float>();

        foreach (var bs in blendShapes)
        {
            if (bs.index < 0) continue;

            if (!weights.ContainsKey(bs.index))
            {
                weights.Add(bs.index, 0f);
            }
            
            weights[bs.index] += bs.weight * bs.maxWeight * volume * 100f;
        }

        return weights;
    }

    public void OnAnimationBakeEnd()
    {
        _lipSyncUpdated = false;
        _isAnimationBaking = false;
    }
#endif
}

}

