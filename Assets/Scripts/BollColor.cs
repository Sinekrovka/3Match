using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BollColor : MonoBehaviour
{
    public ColorPalette colors;
    
    private SpriteRenderer spr;
    private bool destroy;
    private int index;
    
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        index = Random.Range(0, colors.Colors.Count);
        float rr = colors.Colors[index].r;
        float gg = colors.Colors[index].g;
        float bb = colors.Colors[index].b;
        spr.color = new Color(rr, gg, bb);
        destroy = false;
    }

    private void Update()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
}
