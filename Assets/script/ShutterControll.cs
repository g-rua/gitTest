using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShutterControll : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject save;
    static GameObject[] award;
    public int[] rankScore = new int[4];
    public List<int> gamePointList;
    private Vector3 vel;
    public Vector3 initPos;
    public Vector3 endPos;
    public bool moveFlag;
    public int maxidx;
    public int idxscore;
    public int rankidx;
    public int rank=0;
    public bool moveEnd;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos;
        for(int i=0;i<rankScore.Length;i++)
        {
            //順位事の付加ポイントを格納しとく
            rankScore[i] = 100 - (25*i);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShutterClose()
    {

        initPos = new Vector3(0, 960, 0);
        vel = new Vector3(0, -10, 0);
        endPos = new Vector3(0, 0, 0);
        if (transform.position.y <= endPos.y)
        {
            vel = Vector3.zero;
            moveEnd = true;
            ScoreSort();
            GetComponent<sceneMove>().NoFadeChange();
        }
        transform.position += vel;

    }

    public void ShutterOpen()
    {
        initPos = Vector3.zero;
        vel = new Vector3(0, 10, 0);
        endPos = new Vector3(0, 960, 0);
        if (Mathf.Abs(transform.position.y) >= endPos.y)
        {
            moveEnd = true;
            vel = Vector3.zero;
        }

        transform.position += vel;

    }


    private void ScoreSort()
    {
        //ソート処理用のリストにゲーム毎のスコアを格納する
        for (int i = 0; i < players.Length; i++)
        {
            gamePointList.Add(players[i].GetComponent<GameScoreManage>().gamePoint);
        }
        //リストが空になるまで回す
        while (gamePointList.Count > 0)
        {
            //最大の数値が入っているインデクスを取得
            maxidx = gamePointList.IndexOf(gamePointList.Max());
            //得たインデクスの中にあるスコアを取得する
            idxscore = gamePointList[maxidx];
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

