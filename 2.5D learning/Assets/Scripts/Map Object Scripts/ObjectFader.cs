using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    [SerializeField]private float fadeSpeed, fadeAmount;
    public float orignalOpacity { get; private set; }
    private Material material;
    public bool doFade { get; private set; }


    void Start()
    {
        material = GetComponent<Material>();
        orignalOpacity = material.color.a;
        doFade = false;
    }

    void Update()
    {
        
    }
}
