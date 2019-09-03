using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameCelecter : MonoBehaviour
{
    [SerializeField] GameObject fader;
    [SerializeField] Text gameNo;
    public int gameVal=0;
    public int lastVal = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameVal = Random.Range(0, 3);
        gameNo.text = gameVal.ToString();
        Debug.Log(GameScore.scoreA);
        Debug.Log(GameScore.scoreB);
        Debug.Log(GameControll.gameCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            lastVal = gameVal;
            gameVal = Random.Range(0, 3);

            gameNo.text = gameVal.ToString();
        }
        //遊ぶゲームを乱数で決めて、それぞれのシーンに遷移
        if(Input.GetKeyDown(KeyCode.Return))
        {
            switch (gameVal)
            {
                case 0:
                    fader.SetActive(true);
                    fader.GetComponent<FadeController>().FadeOut("game1",Color.black);
                    break;
                case 1:
                    fader.SetActive(true);
                    fader.GetComponent<FadeController>().FadeOut("game2", Color.black);
                    break;
                case 2:
                    fader.SetActive(true);
                    fader.GetComponent<FadeController>().FadeOut("game3", Color.black);
                    break;
                default:
                    fader.SetActive(true);
                    fader.GetComponent<FadeController>().FadeOut("title", Color.black);
                    break;
            }

        }
    }
}
