using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGravity : MonoBehaviour
{
    public Level lvl;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (lvl.Down)
        {
            rb2d.gravityScale = 5f;
        }
        else
        {
            rb2d.gravityScale = 0f;
            rb2d.velocity = Vector2.zero;
        }
    }
}
