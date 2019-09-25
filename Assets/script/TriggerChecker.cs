﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public bool canCarry = false;
    public GameObject item;
    public Color teamColor;
    public int teamIndex;
    public bool jumpPanelFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObject()
    {
        return item;
    }

    public void Carry()
    {
        item = null;
        canCarry = false;
    }

    public void SetTeamColor(Color color)
    {
        teamColor = color;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CarryItem")
        {
            canCarry = true;
            item = other.gameObject;
        }
        if(other.tag=="ChangeColorTile")
        {
            other.GetComponent<BlockColorChange>().ChangeColor(teamColor);
            other.GetComponent<BlockColorChange>().SetTeamIndex(teamIndex);
        }
        if(other.tag=="JumpPanel")
        {
            jumpPanelFlag = true;
        }
        if(other.tag=="ShuffleDoors")
        {
            transform.position = other.gameObject.GetComponent<StageProceedOrReturn>().ProceedOrReturn();
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag=="CarryItem")
        {
            canCarry = false;
            item = null;
        }
        if (other.tag == "JumpPanel")
        {
            jumpPanelFlag = false;
        }
    }

}
