using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultControll : MonoBehaviour
{
    [SerializeField] ShutterControll shutter;
    [SerializeField] ResultBoxControll[] resultBoxes;
    public static int gameStyle;
    public bool resultEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shutter.ShutterOpen();
        if(shutter.moveEnd)
        {
            for (int i = 0; i < resultBoxes.Length; i++)
            {
                resultBoxes[i].BoxOpen();
            }
        }
        if (resultEnd)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (gameStyle)
                {
                    case 0:
                        GetComponent<FadeController>().FadeOut("RandomGameCelecter");
                        break;
                    case 1:
                        GetComponent<FadeController>().FadeOut("gamecelecter");
                        break;
                }

            }
        }
    }
}
