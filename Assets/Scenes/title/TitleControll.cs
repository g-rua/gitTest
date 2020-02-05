using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControll : MonoBehaviour
{
    [SerializeField] GameObject s;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(/*Input.GetKeyDown(KeyCode.Return)||*/Input.GetButtonDown("optionReturn"))
        {
            GetComponent<sceneMove>().NoFadeChange();
            //s.SetActive(true);
        }
        else
        {
            //s.SetActive(false);
        }
    }
}
