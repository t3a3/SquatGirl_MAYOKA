using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterParameterSlider : MonoBehaviour
{
    public static CharacterParameterSlider Instance;
    Slider slider;
    GameObject body;
    GameObject Costume;
    SkinnedMeshRenderer body_skinnedmeshRenderer;
    SkinnedMeshRenderer body_nipple_skinnedmeshRenderer;
    SkinnedMeshRenderer Tops_skinnedmeshRenderer;
    SkinnedMeshRenderer Tops_nipple_skinnedmeshRenderer;

    public static int DefaultBreastSize = 100;
    public static int DefaultNippleSize = 0;
    public static int b_Index;//body_breast
    public int n_Index;//body_nipple
    public static int t_Index;//Cos_Tops
    public int tn_Index;//Cos_nipple
    public static int b_value=100;
    void Start()
    {
        slider = this.gameObject.GetComponentInChildren<Slider>();

        body = GameObject.FindGameObjectWithTag("body");
        body_skinnedmeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        body_nipple_skinnedmeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        b_Index = body_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Breast_big");
        n_Index = body_nipple_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Chikubi");
        body_skinnedmeshRenderer.SetBlendShapeWeight(b_Index, 80);

        Costume = GameObject.FindGameObjectWithTag("Tops");
        Tops_skinnedmeshRenderer = Costume.GetComponent<SkinnedMeshRenderer>();
        t_Index = Tops_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Breast_big");
        tn_Index = Tops_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Chikubi");

    }


    public void Breast_Slider()
    {
        if (CostumeChange.hadakaBool == false)
        {
            Costume = GameObject.FindGameObjectWithTag("Tops");
            Tops_skinnedmeshRenderer = Costume.GetComponent<SkinnedMeshRenderer>();
            t_Index = Tops_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Breast_big");
            int value = (int)slider.value;
            body_skinnedmeshRenderer.SetBlendShapeWeight(b_Index, value - 20);
            Tops_skinnedmeshRenderer.SetBlendShapeWeight(t_Index, value);
            DefaultBreastSize = value;
        }
        else
        {
            int value = (int)slider.value;
            body_skinnedmeshRenderer.SetBlendShapeWeight(b_Index, value);
            DefaultBreastSize = value;
        }

    }
    public void Nipple_Slider()
    {
        if (CostumeChange.hadakaBool == false)
        {
            Costume = GameObject.FindGameObjectWithTag("Tops");
            Tops_nipple_skinnedmeshRenderer = Costume.GetComponent<SkinnedMeshRenderer>();
            tn_Index = Tops_nipple_skinnedmeshRenderer.sharedMesh.GetBlendShapeIndex("Chikubi");
            int value = (int)slider.value;
            body_nipple_skinnedmeshRenderer.SetBlendShapeWeight(n_Index, value);
            Tops_nipple_skinnedmeshRenderer.SetBlendShapeWeight(tn_Index, value);
            DefaultNippleSize = value;
        }
        else
        {
            int value = (int)slider.value;
            body_nipple_skinnedmeshRenderer.SetBlendShapeWeight(n_Index, value);
            DefaultNippleSize = value;
        }
    }

}
