﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatHitBomColor : MonoBehaviour
{
    private Color bomColor;
    // Start is called before the first frame update
    void Start()
    {
        bomColor = GetComponent<MeshRenderer>().materials[1].color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapCountChangeAlpha(int tap,int maxtap)
    {
        //連打数を限界数との割合にして透過率を上げていく
        bomColor.a = (float)tap / (float)maxtap;
        GetComponent<MeshRenderer>().materials[1].color = bomColor;
    }

}
