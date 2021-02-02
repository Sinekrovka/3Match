using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour
{
    private Color _color;

    void Start()
    {
        _color = transform.parent.GetComponent<SpriteRenderer>().color;
      
      ParticleSystem ps = GetComponent<ParticleSystem>();
      var main = ps.main;
      main.startColor = new Color(_color.r, _color.g,_color.b);
    }
}
