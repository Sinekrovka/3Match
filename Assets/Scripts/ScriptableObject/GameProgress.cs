using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GameProgress", menuName = "Game Progress", order = 52)]
public class GameProgress : ScriptableObject
{
    private int countMotion;
    private int contDestroy;

    public int CountMotion
    {
        get => countMotion;
        set => countMotion = value;
    }

    public int ContDestroy
    {
        get => contDestroy;
        set => contDestroy = value;
    }
}
