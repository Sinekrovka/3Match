using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    private int sizeX;
    private int sizeY;
    private float startX;
    private float startY;
    
    public GameObject tileObject;
    public Level level;
    void Start()
    {
        startX = -2f;
        sizeX = level.Weight;
        sizeY = level.Hight;
        level.CountLife = level.Life;
        float endCoordinatsX = startX + sizeX;
        float endCoordinatsY;

        level.CountBolsData= sizeX * sizeY;
        level.Down = false;
        
        if (sizeY < 10)
        {
            startY = 4.5f;
            endCoordinatsY = startY - sizeY;
        }
        else
        {
            startY = -2.5f;
            endCoordinatsY = startY + sizeY;
        }
        
        for (float i = startX; i < endCoordinatsX; ++i)
        {
            if (sizeY < 10)
            {
                for (float j = startY; j > endCoordinatsY; --j)
                {
                    GameObject newtile = Instantiate(tileObject, 
                        new Vector3(i,j,0f), Quaternion.identity);
                }
            }
            else
            {
                for (float j = startY; j < endCoordinatsY; ++j)
                {
                    GameObject newtile = Instantiate(tileObject, 
                        new Vector3(i,j,0f), Quaternion.identity);
                }
            }
        }
    }
}
