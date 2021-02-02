using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu (fileName = "Level", menuName = "Level", order = 54)]
public class Level : ScriptableObject
{
    [SerializeField] private int hight;
    [SerializeField] private int weight;
    [SerializeField] private int life;
    [SerializeField] private int score;

    private int countLife;
    private bool down;
    private int countBolsData;
    

    public int Hight => hight;

    public int Weight => weight;

    public int CountBolsData
    {
        get => countBolsData;
        set => countBolsData = value;
    }

    public bool Down
    {
        get => down;
        set => down = value;
    }

    public int CountLife
    {
        get => countLife;
        set => countLife = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }

    public int Life => life;
}
