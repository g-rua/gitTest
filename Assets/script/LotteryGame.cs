﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotteryGame : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] LotteryRotation lr;
    [SerializeField] Transform sphereExit;
    private GameObject lotterySphere;
    public float enterRot;
    public bool rotationStart;
    public bool rotationEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&!rotationEnd)
        {
            lr.SetFirstRot(enterRot);
            rotationStart = true;
        }
        if(rotationStart&&lr.GetRot()==0f)
        {
            lotterySphere = GameObject.Instantiate(sphere, sphereExit.position, sphereExit.rotation);
            rotationEnd = true;
            rotationStart = false;
        }
    }
}
