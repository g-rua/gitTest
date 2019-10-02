using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameJudge : MonoBehaviour
{
    [SerializeField] GameObject fader;
    public enum GameType{
        gt_carry,
        gt_tileChange,
        gt_race,
    };
    public GameType gameType;
    int scoreA;
    int scoreB;
    // Start is called before the first frame update
    void Start()
    {
        scoreA = 50;
        scoreB = 100;
    }

    // Update is called once per frame
    void Update()
    {

        switch (gameType)
        {
            case GameType.gt_carry:
                CarryJudge();
                break;
            case GameType.gt_tileChange:
                TileChangeJudge();
                break;
            case GameType.gt_race:
                RaceJudge();
                break;
            default:
                fader.GetComponent<FadeController>().FadeOut("title");
                break;

        }

        //テスト用のスコア加算
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    GameScore.scoreA += scoreA;
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    GameScore.scoreB += scoreB;
        //}

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    //残りのゲーム回数を見て、表彰に移るか次のゲームに移るか決める
        //    if (GameControll.gameCount <= 1)
        //    {
        //        fader.GetComponent<FadeController>().FadeOut("Award", Color.white);
        //    }
        //    else
        //    {
        //        fader.GetComponent<FadeController>().FadeOut("gameResult", Color.white);
        //    }
        //    GameControll.gameCount--;
            

        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //テスト用、ゲームスコアをリセットしタイトルへ
        //    GameScore.Reset();
        //    fader.SetActive(true);
        //    fader.GetComponent<FadeController>().FadeOut("title", Color.black);
        //}
    }
    public void SetGameType(int gameIndex)
    {
        gameType = (GameType)gameIndex;
    }

    private void CarryJudge()
    {

    }

    private void TileChangeJudge()
    {

    }

    private void RaceJudge()
    {

    }




}
