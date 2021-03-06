﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmphasizeTheFrameByIndex : MonoBehaviour
{
    public int gameIndex;
    public bool inputDelay;
    public int waittime;
    public int waitTimer;
    public int lastindex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    gameIndex++;
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    gameIndex--;
        //}
        //gameIndex += (int)Input.GetAxis("D_Pad_H");
        if (lastindex != gameIndex)
        {
            waitTimer = 15;
            inputDelay = true;
        }
        lastindex = gameIndex;
        if (!inputDelay)
        {
            gameIndex += (int)(Input.GetAxis("D_Pad_H"));
            gameIndex += (int)(Input.GetAxis("D_Pad_V")) * 3;
        }
        else
        {
            if (waitTimer-- < 0)
            {
                inputDelay = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameIndex+=3;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameIndex-=3;
        }
        if(gameIndex<0)
        {
            gameIndex = 0;
        }
        if(gameIndex>5)
        {
            gameIndex = 5;
        }
        for(int i=0;i<transform.childCount;i++)
        {
            Color col = new Color(123f,255f,76f,255f);
            Vector3 scale = new Vector3(2.5f, 2.5f, 1);
            bool flag = false;
            if(i==gameIndex)
            {
                flag = true;
                //col = Color.red;
                scale = new Vector3(3f, 3f, 1f);
            }

            //transform.GetChild(i).GetComponent<Image>().color = col;
            transform.GetChild(i).GetChild(1).gameObject.SetActive(flag);
            transform.GetChild(i).localScale = scale;
        }
    }
}
