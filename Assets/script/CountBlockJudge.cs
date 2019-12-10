using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBlockJudge : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] goals;
    [SerializeField] int[] counts;
    public int teamCount;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        ////ゲームタイムを進めていく
        //gameTime++;
        ////６０フレーム毎に本当の時間を減らす
        //if(gameTime>60)
        //{
        //    gameTime = 0;
        //    drawTime--;
        //}
        ////ゲームタイムが０になったら終了処理用のフラグを立てる
        //if(drawTime<0)
        //{
        //    gameEnd = true;
        //}
        //if(gameEnd)
        //{
        //    //終わったら操作出来ないように操作用スクリプトを止める
        //    foreach(var chara in characterControll)
        //    {
        //        chara.enabled = false;
        //    }
        //    //ゲーム終了演出を始める
        //    shutter.GetComponent<ShutterControll>().ShutterClose();
        //}
        ////ゲームタイムをオブジェクトとして生成する
        //gameCount.NumPop(drawTime, new Vector3(0.96f, 8.6f, -1.2f), false);
        //gameCount.gameObject.transform.rotation = Quaternion.Euler(45f,0,0);
        //それぞれのゲームスコアを与える
        for(int i=0;i<teamCount;i++)
        {
            counts[i] = goals[i].GetComponent<OnBlockCounter>().GetCount();
            players[i].GetComponent<GameScoreManage>().gamePoint = counts[i];
        }
    }


}
