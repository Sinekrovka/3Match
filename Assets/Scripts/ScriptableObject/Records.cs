using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Records", menuName = "Records", order = 53)]
public class Records : ScriptableObject
{
    private List<int> countDestroy;

    public List<int> CountDestroy
    {
        get => countDestroy;
        set => countDestroy = value;
    }
}
