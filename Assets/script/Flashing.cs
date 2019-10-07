using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    private Color defColor;
    private Color changeColor;
    private int flashingIndex = 1;
    private int maxFlashingCount;
    public float addAlpha;
    public int defFlashingCount;
    public int flashingCount;
    public int targetObjCnt;
    public bool changeAlpha;
    // Start is called before the first frame update
    void Start()
    {
        flashingCount = defFlashingCount;
        maxFlashingCount = defFlashingCount;
        defColor = GetComponent<MeshRenderer>().materials[flashingIndex].color;
        changeColor = defColor;
    }

    // Update is called once per frame
    void Update()
    {
        //そのうちリファクタリングします
        flashingCount--;
        if(flashingCount==360)
        {
            addAlpha = 0.1f;
        }
        if(flashingCount==240)
        {
            addAlpha = 0.2f;
        }
        if(flashingCount==120)
        {
            addAlpha = 0.4f;
        }
        if (changeColor.a >= 1)
        {
            addAlpha *= -1f;
        }
        if (changeColor.a <= 0)
        {
            addAlpha *= -1f;
        }
        changeColor.a += addAlpha;


        //}
        GetComponent<MeshRenderer>().materials[flashingIndex].color = changeColor;

    }



    public void SetCountDownTime(int time)
    {
        targetObjCnt = time;
    }
}
