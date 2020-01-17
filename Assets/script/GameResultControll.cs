using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultControll : MonoBehaviour
{
    [SerializeField] ShutterControll shutter;
    [SerializeField] ResultBoxControll[] resultBoxes;
    [SerializeField] GameObject[] jems;
    public static int gameStyle;
    public bool resultEnd;
    private int[] listRank;
    public List<int> ranks;
    public int[] rank;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            ranks.Add(i);
        }
            int rankidx = 0;
        while (ranks.Count > 0)
        {
            int idx = Random.Range(0, ranks.Count);
            rank[rankidx++] = ranks[idx];
            ranks.RemoveAt(idx);
        }
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

    private GameObject rankSizeDia(int rankidx)
    {
        GameObject dia = jems[rankidx];

        return dia;

    }

}
