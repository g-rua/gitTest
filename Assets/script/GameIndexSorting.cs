using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIndexSorting : MonoBehaviour
{
    public int tekito = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Keypad6))
        {
            tekito += 6;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if(tekito-6>=0)
            tekito -=6;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<GameIndexChangeImage>().gameIndex = i+tekito+1;
        }
    }
}
