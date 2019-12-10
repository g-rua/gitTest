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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //switch (gameType)
        //{
        //    case GameType.gt_carry:
        //        CarryJudge();
        //        break;
        //    case GameType.gt_tileChange:
        //        TileChangeJudge();
        //        break;
        //    case GameType.gt_race:
        //        RaceJudge();
        //        break;
        //    default:
        //        fader.GetComponent<FadeController>().FadeOut("title");
        //        break;

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
