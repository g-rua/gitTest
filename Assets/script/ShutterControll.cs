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
    public List<int> test;
    public List<int> ts;
    public int[] kari;
    private Vector3 vel;
    public Vector3 initPos;
    public Vector3 endPos;
    public bool moveFlag;
    public int maxidx;
    public int idxscore;
    public int rankidx;
    public int rank=0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos;
        for(int i=0;i<rankScore.Length;i++)
        {
            rankScore[i] = 100 - (25*i);
           
            ts[i]=Random.Range(0, 500);
            
        }
        for (int i = 0; i < ts.Count; i++)
        {
            test.Add(ts[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            TestSort();
        }
    }

    public void ShutterClose()
    {

            initPos = new Vector3(0, 960, 0);
            vel = new Vector3(0, -10, 0);

            endPos = new Vector3(0,0, 0);
        if (transform.position.y <= endPos.y)
        {
            vel = Vector3.zero;
            ScoreSort();
            GetComponent<sceneMove>().NoFadeChange();
        }
        transform.position += vel;

    }

    public void ShutterOpen()
    {
        if (Mathf.Abs(transform.position.y) >= endPos.y)
        {


            vel = Vector3.zero;
        }
        initPos = Vector3.zero;
        vel = new Vector3(0, 10, 0);
        //transform.position = initPos;
        endPos = new Vector3(0, 960, 0);
        transform.position += vel;
        Debug.Log(award[0]);

    }

    private void ScoreSort()
    {

            award = players;
        
        for (int i = 0; i < award.Length; i++)
        {
            if (i + 1 < award.Length)
            {
                if (award[i].GetComponent<GameScoreManage>().gamePoint <
                    award[i + 1].GetComponent<GameScoreManage>().gamePoint)
                {
                    save = award[i];
                    award[i] = award[i + 1];
                    award[i + 1] = save;
                    i = -1;
                }
            }
        }
        Debug.Log(award[0]);
        
        /*ランク付け方法
         　付加ポイントは上から100,75,50,25
           それぞれゲームスコアに応じて降順にされた
           キャラ達に与えていく*/
        //for (int i = 0; i < st.Length; i++)
        //{
        //    if (i + 1 < st.Length)
        //    {
        //        if (st[i] <
        //            st[i + 1])
        //        {
        //            s = st[i];
        //            st[i] = st[i + 1];
        //            st[i + 1] = s;
        //            i = -1;
        //        }

        //    }
        //}
    }

    private void TestSort()
    {

        //while (test.Count > 0)
        //{

        //最大の数値が入っているインデクスを返す
            maxidx = test.IndexOf(test.Max());
            //得たインデクスの中にあるスコアを取得する
            idxscore = test[maxidx];
        for (int i = 0; i < ts.Count; i++)
        {
            if(ts[i]==idxscore)
            {
                rankidx = i;
                break;
            }
        }
            kari[rankidx] += rankScore[rank++];
            test.RemoveAt(maxidx);

        //    if(rank>3)
        //    {
        //        break;
        //    }


        //}

        //test.Clear();
    }
}

