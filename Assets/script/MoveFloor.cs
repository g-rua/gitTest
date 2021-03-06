﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private float xSpeed;
    public float dev = 1f;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="MoveFloor")
        {
            //動く床の場合その床のUVスクロール速度に基づいて移動
            xSpeed = other.transform.GetComponent<MeshRenderer>().materials[0].GetFloat("_XSpeed")*-1f;
            transform.position -= new Vector3(xSpeed/dev, 0, 0)*Time.deltaTime;
        }
    }

}
