﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameIndexChangeImage : MonoBehaviour
{

    public int gameIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = gameIndex.ToString();
    }
}
