﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static int scoreA;
    public static int scoreB;
    public static int[] score = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        
        scoreA = 0;
        scoreB = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Reset()
    {
        scoreA = 0;
        scoreB = 0;
        for(int i=0;i<score.Length;i++)
        {
            score[i] = 0;
        }
    }
}
