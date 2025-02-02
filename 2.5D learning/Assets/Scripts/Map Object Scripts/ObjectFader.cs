using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    [SerializeField]private float fadeSpeed, fadeAmount;
    public float orignalOpacity { get; private set; }
    private Material material;
    private bool doFade = false;


    void Start()
    {
        material = GetComponent<Renderer>().material;
        orignalOpacity = material.color.a;
    }

    void Update()
    {
        if (doFade)
        {
            FadeOut();
        }
        else
        {
            FadeIn();
        }
        doFade = false;
    }

    public void SetFade(bool shouldFade)
    {
        if (doFade != shouldFade)
        {
            doFade = shouldFade;
        }
    }

    void FadeIn()
    {
        Color currentColor = material.color;
        Color smoothColor = new Color(
            currentColor.r,
            currentColor.g,
            currentColor.b,
            Mathf.Lerp(currentColor.a, orignalOpacity, fadeSpeed * Time.deltaTime)
        );

        material.color = smoothColor;
    }

    void FadeOut()
    {
        Color currentColor = material.color;
        Color smoothColor = new Color(
            currentColor.r,
            currentColor.g,
            currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime)
        );

        material.color = smoothColor;
    }
}
