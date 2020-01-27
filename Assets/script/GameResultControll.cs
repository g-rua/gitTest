using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameResultControll : MonoBehaviour
{
    [SerializeField] ShutterControll shutter;
    [SerializeField] ResultBoxControll[] resultBoxes;
    [SerializeField] GameScoreManage[] ps;
    [SerializeField] GameObject[] jems;
    [SerializeField] GameObject[] rankJems;
    public List<int> score;
    public List<int> score2;
    public static int gameStyle;
    public bool resultEnd;
    private int[] listRank;
    public List<int> ranks;
    public int[] rank;
    public int maxidx;
    public int idx;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i=0;i<2;i++)
        {
            score.Add(Random.Range(0,500)/*ps[i].gamePoint*/);
            //score2.Add(ps[i].gamePoint);
        }
        for (int i = 0; i < 2; i++)
        {
            //score.Add(Random.Range(0, 500)/*ps[i].gamePoint*/);
            score2.Add(score[i]);
        }
        //for (int i = 0; i < 4; i++)
        //{
        //    ranks.Add(i);
        //}
        idx = 0;
        while (score.Count > 0)
        {
            maxidx = score.IndexOf(score.Max());
            int idxscore = score.Max();
            for (int i = 0; i < 2; i++)
            {
                if (score2[i] == idxscore)
                {
                    rankJems[i] = jems[idx];
                    resultBoxes[i].item = jems[idx++];
                }
            }
            //rankJems[maxidx] = jems[idx];
            //resultBoxes[maxidx].item = jems[idx++];
            score.RemoveAt(maxidx);
        }
        //for(int i=0;i<4;i++)
        //{
        //    rankJems[i] = jems[rank[i]];
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //shutter.ShutterOpen();

        //if (shutter.moveEnd)
        //{

        //}
        for (int i = 0; i < resultBoxes.Length; i++)
        {
            resultBoxes[i].BoxOpen();
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

    private GameObject rankSizeDia(int rankidx)
    {
        GameObject dia = jems[rankidx];

        return dia;

    }

}
