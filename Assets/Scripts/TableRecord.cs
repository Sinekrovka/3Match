using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TableRecord : MonoBehaviour
{
    private Dictionary<string, int> dict;
    private List<string> str;
    private int x;

    void Start()
    {
        x = 0;
        dict = new Dictionary<string, int>();
        str = new List<string>();
        
        while(PlayerPrefs.HasKey(x.ToString()))
        {
            string[] s = PlayerPrefs.GetString(x.ToString()).Split(' ');
            dict.Add(s[0], Convert.ToInt32(s[1]) );
            ++x;
        }
        
        foreach (var pair in dict.OrderBy(pair => pair.Value))
        {
            str.Add( pair.Key + "         " + pair.Value);
        }

        Text txt = transform.GetChild(0).GetComponent<Text>();

        Vector3 position = new Vector3(0f, 150f);
        for (int i = str.Count - 1; i > -1; --i)
        {
            txt.text += str[i] + '\n';
            txt.text += "---------------------------------------" + '\n';

        }
        

    }
}
