using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private int x;

    public Level lvl;
    
    void Start()
    {
        x = 0;

        while(PlayerPrefs.HasKey(x.ToString()))
        {
            ++x;
        }

    }

    private void FixedUpdate()
    {
        if (lvl.CountLife <= 0 || lvl.CountBolsData == 0)
        {
            string actualTime = DateTime.Now.ToString("hh:mm:ss");
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            PlayerPrefs.SetString(x.ToString(), date + "-" + actualTime + " " + lvl.Score);
        }
    }
}
