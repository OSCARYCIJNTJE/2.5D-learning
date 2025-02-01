using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    [SerializeField]private float fadeSpeed, fadeAmount;
    public float orignalOpacity { get; private set; }
    private Material material;
    public bool doFade = false;


    void Start()
    {
        material = GetComponent<Renderer>().material;
        orignalOpacity = material.color.a;
    }

    void Update()
    {
        FadeSetting(doFade ? 0 : orignalOpacity);
    }

    void FadeSetting(float opacity)
    {
        if (material == null)
        {
            Debug.LogWarning("Material is not assigned!");
            return;
        }

        Color currentColor = material.color;
        float targetOpacity = (opacity == 0) ? fadeAmount : opacity;

        Color smoothColor = new Color(
            currentColor.r,
            currentColor.g,
            currentColor.b,
            Mathf.Lerp(currentColor.a, targetOpacity, fadeSpeed * Time.deltaTime)
        );

        material.color = smoothColor;
    }
}
