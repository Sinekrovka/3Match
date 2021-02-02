using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ColorPalette", menuName = "Color Palette", order = 51)]
public class ColorPalette : ScriptableObject
{
    [SerializeField] private List<Color> colors;
    
    public List<Color> Colors
    {
        get => colors;
        set => colors = value;
    }
}
