using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBG : MonoBehaviour
{
    public Renderer render;
    public Vector2 offset;

    void Start()
    {
        
    }

    void Update()
    {
        render.material.mainTextureOffset = offset;
    }
}
