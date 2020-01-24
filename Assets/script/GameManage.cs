﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    [SerializeField] FadeController fader;
    [SerializeField] GameObject shutter;
    [SerializeField] GameObject[] players;
    [SerializeField] CharaCon[] characterControll;
    [SerializeField] NumberPop gameCount;
    [SerializeField] NumberPop team1Count;
    [SerializeField] NumberPop team2Count;
    public int[] rankScore;
    public List<int> gamePointList;
    public int gameTime;
    public int drawTime;
    public bool gameStart;
    public bool gameEnd;
    public float numposY = 8.6f;
    public bool rankSortFlag;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        fader.FadeIn();
        for (int i = 0; i < rankScore.Length; i++)
        {
            //順位事の付加ポイントを格納しとく
            rankScore[i] = 100 - (25 * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fader.gameObject.activeInHierarchy)
        {
            gameStart = !fader.isFadeIn;
        }
        if (gameStart)
        {
            //ゲームタイムを進めていく
            gameTime++;
            //６０フレーム毎に本当の時間を減らす
            if (gameTime > 60)
            {
                gameTime = 0;
                drawTime--;
            }
            //ゲームタイムが０になったら終了処理用のフラグを立てる
            if (drawTime < 0)
            {
                gameEnd = true;
            }
        }
        if (gameEnd)
        {
            //終わったら操作出来ないように操作用スクリプトを止める
            foreach (var chara in characterControll)
            {
                chara.enabled = false;
            }
            if(!rankSortFlag)
            {

                ScoreSort();
                rankSortFlag = true;
            //ゲーム終了演出を始める
            GetComponent<FadeController>().FadeOut(nextScene);
            }


        }
        //ゲームタイムをオブジェクトとして生成する
        gameCount.NumPop(drawTime, new Vector3(0.96f, numposY, -1.2f), false);
        gameCount.gameObject.transform.rotation = Quaternion.Euler(45f, 0, 0);
    }

    private void ScoreSort()
    {
        //ソート処理用のリストにゲーム毎のスコアを格納する
        for (int i = 0; i < players.Length; i++)
        {
            gamePointList.Add(players[i].GetComponent<GameScoreManage>().gamePoint);
        }
        int rank = 0;
        //リストが空になるまで回す
        while (gamePointList.Count > 0)
        {
            //最大の数値が入っているインデクスを取得
            int maxidx = gamePointList.IndexOf(gamePointList.Max());
            //得たインデクスの中にあるスコアを取得する
            int idxscore = gamePointList[maxidx];
            int rankidx = 0;
            //元のスコアとが格納されてるインデクスを確認するループ
            for (int i = 0; i < players.Length; i++)
            {
                //スコアと一致していたらそこのインデクスを取得する
                if (players[i].GetComponent<GameScoreManage>().gamePoint == idxscore)
                {
                    rankidx = i;
                    break;
                }
            }
            //取得したインデクスのキャラにランクに応じたポイントを付与する
            GameScore.score[rankidx] += rankScore[rank++];
            //次の最大を探すために今の最大値を消す
            gamePointList.RemoveAt(maxidx);
        }
    }
}
