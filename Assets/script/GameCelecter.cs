using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameCelecter : MonoBehaviour
{

    [SerializeField] Text gameNo;
    [SerializeField] EmphasizeTheFrameByIndex frameIndex;
    [SerializeField] Image manualImage;
    [SerializeField] Sprite[] manualImageTexture;
    [SerializeField] Transform gameList;
    [SerializeField] Transform gameManual;
    [SerializeField] Color[] listColor;
    [SerializeField] Image[] manualColor;
    [SerializeField] string[] gameName;
    public int gameVal=0;
    public int lastVal = 0;
    public int celectVal=0;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(GameScore.scoreA);
        Debug.Log(GameScore.scoreB);
        Debug.Log(GameControll.gameCount);
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    lastVal = gameVal;
        //    gameVal = Random.Range(0, 3);

        //    gameNo.text = gameVal.ToString();
        //}

        switch (celectVal)
        {
            case 0:

                CelectGame();
                break;
            case 1:
                GameManual();
                break;
            default:
                break;
        }

        
    }

    private void CelectGame()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            GetComponent<FadeController>().FadeOut("GameSetting");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            celectVal++;
            gameList.gameObject.SetActive(false);
            gameManual.gameObject.SetActive(true);
            for (int i = 0; i < gameManual.childCount; i++)
            {
                gameManual.GetChild(i).GetComponent<AlphaControll>().Appear();
            }
        }
        gameVal = frameIndex.gameIndex;
    }

    private void GameManual()
    {
        manualImage.sprite= manualImageTexture[gameVal];
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            celectVal--;
            gameManual.gameObject.SetActive(false);
            gameList.gameObject.SetActive(true);
            //for (int i = 0; i < gameManual.childCount; i++)
            //{
            //    gameManual.GetChild(i).GetComponent<AlphaControll>().Erase();
            //}
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<FadeController>().FadeOut(gameName[gameVal]);
        }
        //for (int i = 0; i < gameManual.childCount; i++)
        //{
        //    gameManual.GetChild(i).GetComponent<AlphaControll>().Appear();
        //}

    }

}
