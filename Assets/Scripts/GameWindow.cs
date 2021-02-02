using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{
    private Text bollCount;
    private Text lifeCount;
    private Text score;
    private bool winner;
    private int life;
    
    public Level lvl;
    public GameObject lose;
    public GameObject win;
    public Records rec;
    public bool endGame;

    void Start()
    {
        if (!endGame)
        {
            bollCount = transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
            bollCount.text = lvl.CountBolsData.ToString();
            lifeCount = transform.GetChild(2).transform.GetChild(1).GetComponent<Text>();
            lifeCount.text = lvl.CountLife.ToString();
            score = transform.GetChild(3).transform.GetChild(1).GetComponent<Text>();
            score.text = lvl.Score.ToString();
        }
        winner = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (lvl.CountLife >= 0 && !endGame)
        {
            bollCount.text = lvl.CountBolsData.ToString();
            lifeCount.text = lvl.CountLife.ToString();
            score.text = lvl.Score.ToString();
            
            if (lvl.CountLife == 0 && lvl.CountBolsData > 0)
            {
                Instantiate(lose, transform);
                lvl.CountLife = -1;
            }
            else if (lvl.CountLife >= 0 && lvl.CountBolsData == 0)
            {
                Instantiate(win, transform);
                lvl.CountLife = -1;
            }
        }

        if (endGame)
        {
            if (lvl.CountLife >= 0 && lvl.CountBolsData == 0)
            {
                winner = true;
            }
        }
    }

    public void ClickGravity()
    {
        if (lvl.CountLife >= 10)
        {
            lvl.Down = true;
            lvl.CountLife -= 10;
        }
    }

    public void returnHome()
    {
        SceneManager.LoadScene("MainMenu");
        if (winner)
        {
            Win();
        }
    }

    public void RestartGame()
    {
        if (winner)
        {
            Win();
        }
        else
        {
            lvl.Score = 0;
        }
        SceneManager.LoadScene("3Match");
    }

    public void Win()
    {
        rec.CountDestroy.Add(lvl.Score);
    }
}
