using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool click;
    private bool createParticle;
    private bool run;
    private bool child;
    
    public Level lvl;
    
    private SpriteRenderer bol;
    private List<GameObject> familiarObjects;

    public ParticleSystem particle;
    
    void Start()
    {
        click = false;
        bol = transform.GetChild(0).GetComponent<SpriteRenderer>();
        createParticle = false;
        run = false;
        child = false;
        familiarObjects = new List<GameObject>();
        Vibration.Init();
    }

    private void OnMouseDown()
    {
        click = true;
    }

    private void FixedUpdate()
    {

        if (lvl.CountLife >= 0)
        {
            if (click && !createParticle)
            {
                bol.enabled = false;
                Vibration.Vibrate(25);
                particle = Instantiate(particle, transform.position, Quaternion.identity, transform.GetChild(0));
                click = false;
                createParticle = true;
                FindOther();
                lvl.Down = false;
            }

            if (run)
            {
                bol.enabled = false;
                Vibration.Vibrate(25);
                particle = Instantiate(particle, transform.position, Quaternion.identity, transform.GetChild(0));
                run = false;
                child = true;
                createParticle = true;
            }
        
        
            if (particle.isStopped && createParticle)
            {
                if (!child)
                {
                    lvl.CountBolsData = lvl.CountBolsData - familiarObjects.Count-1;
                    if (familiarObjects.Count >= 3)
                    {
                        lvl.Down = true;
                        lvl.CountLife += 4;
                    }
                    else if (familiarObjects.Count == 2)
                    {
                        lvl.CountLife += 3;
                    }
                    else if (familiarObjects.Count <= 1)
                    {
                        lvl.CountLife -= 1;
                    }

                    
                    if (familiarObjects.Count > 5)
                    {
                        lvl.Score += familiarObjects.Count*2 + 1;
                    }
                    else
                    {
                        lvl.Score += familiarObjects.Count + 1;
                    }

                }
                Destroy(gameObject);
            }
        }
    }

    private void GetOther()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        List<Vector2> moved = new List<Vector2>();
        moved.Add(Vector2.down);
        moved.Add(Vector2.left);
        moved.Add(Vector2.up);
        moved.Add(Vector2.right);

        foreach (Vector2 v in moved)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, v, 1);
            if (hit.collider != null && hit.collider.tag == "boll")
            {
                Color a = hit.collider.transform.gameObject.transform.GetChild(0)
                    .GetComponent<SpriteRenderer>().color;
                if ( a == transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color)
                {
                    familiarObjects.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<Tile>().FindOther();
                }
            }
        }

        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private void Collecting()
    {
        List<GameObject> addObjects = new List<GameObject>();
        for (int i = 0; i < familiarObjects.Count; ++i)
        {
            Tile t = familiarObjects[i].GetComponent<Tile>();
            for(int j= 0; j< t.FamiliarObjects.Count; ++j)
            {
                if (!familiarObjects.Contains(t.FamiliarObjects[j]))
                {
                    addObjects.Add(t.FamiliarObjects[j]);
                }
            }
        }
        
        familiarObjects.AddRange(addObjects);
        
        for (int i = 0; i < familiarObjects.Count; ++i)
        {
            if (!familiarObjects[i].GetComponent<Tile>().Run)
            {
                familiarObjects[i].GetComponent<Tile>().Run = true;
            }
        }
    }

    public List<GameObject> FamiliarObjects => familiarObjects;

    public bool Run
    {
        get => click;
        set => run = value;
    }

    public void FindOther()
    {
        GetOther();
        Collecting();
    }
}
