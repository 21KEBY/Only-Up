using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Outline : MonoBehaviour
{
    private Renderer rend;
    private Material originalMaterial;
    private Material outlineMaterial;
    public Color outlineColor = Color.yellow;
    public float outlineWidth = 1.5f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;

        outlineMaterial = new Material(Shader.Find("Outlined/Uniform"));
        outlineMaterial.SetColor("_OutlineColor", outlineColor);
        outlineMaterial.SetFloat("_OutlineWidth", outlineWidth);
    }

    public void ShowOutline(bool show)
    {
        rend.material = show ? outlineMaterial : originalMaterial;
    }
}
