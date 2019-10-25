using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceJudge : MonoBehaviour
{
    public GameObject[] rank;
    public int rankIndex=0;
    public int players=2;
    public bool gameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        rankIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //全員ゴールで終わり
        if((rankIndex==players)&&!gameEnd)
        {
            gameEnd = true;
        }
        if(gameEnd)
        {
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            //ゴールしたら配列にいれて判定を消す
            rank[rankIndex] = other.gameObject;
            rankIndex++;
            Destroy(other);
            Debug.Log("Goal");
        }
    }

}
