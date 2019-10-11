using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJack : MonoBehaviour
{
    public struct CardInfo
    {
        public List<int> card;
        public int getCount;
        public int sum;
        public bool burst;
        public bool end;
    }
    public CardInfo p1;
    public CardInfo p2;
    public List<int> deckCard = new List<int>();
    private int maxDeckCard=14;
    public List<int> p1Card = new List<int>();
    public List<int> p2Card = new List<int>();
    public int p1num;
    public int p2num;
    public bool p1burst;
    public bool p2burst;
    public bool judge;
    public string winner;
    // Start is called before the first frame update
    void Start()
    {
        p1.card = new List<int>();
        p2.card = new List<int>();
        GameReset();
    }

    // Update is called once per frame
    void Update()
    {

        if(judge)
        {
            Judge(p1.sum, p2.sum,p1.burst,p2.burst);
        }

        //デッキにカードがあるときにひける
        if (deckCard.Count > 0)
        {
            //1Pが引く
            if (Input.GetKeyDown(KeyCode.Keypad1)&&!p1.end)
            {
                GetCard(ref p1.card);
                SumNum(p1.card,p1.getCount,ref p1.sum,ref p1.burst);
                p1.getCount++;
            }
            //2Pが引く
            if(Input.GetKeyDown(KeyCode.Keypad2)&&!p2.end)
            {
                GetCard(ref p2.card);
                SumNum(p2.card,p2.getCount,ref p2.sum,ref p2.burst);
                p2.getCount++;
            }
        }
        //1Pが引くのをやめる
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            p1.end = true;
        }
        //２Pが引くのをやめる
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            p2.end = true;
        }
        //どちらも引かない選択をしたら判定に移る
        if(p1.end&&p2.end)
        {
            judge = true;
        }
        //あとで消す
        p1Card = p1.card;
        p2Card = p2.card;
        p1num = p1.sum;
        p2num = p2.sum;
        p1burst = p1.burst;
        p2burst = p2.burst;
    }

    private void Judge(int num1,int num2,bool burst1,bool burst2)
    {
        //お互いのバーストしたかを確認
        if (burst1)
        {
            if(!burst2)
            {
                winner = "p2";
            }
            else
            {
                winner = "even";
            }
        }
        else
        {
            //どちらもバーストしてなければ値を比較して勝負
            if(!burst2)
            {
                if(num1==num2)
                {
                    winner = "even";
                }
                if(num1>num2)
                {
                    winner = "p1";
                }
                else
                {
                    winner = "p2";
                }
            }
            else
            {
                winner = "p1";
            }
        }
        //リザルト確認後ゲームのリセット
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            GameReset();
        }
    }

    private void GetCard(ref List<int> list)
    {
        //ランダムに値を取得
        int card = Random.Range(0, deckCard.Count);
        //渡されたリストに値を入れていく
        list.Add(deckCard[card]);
        //被らないように使った値を消す
        deckCard.RemoveAt(card);
    }

    private void SumNum(List<int> list,int getcount,ref int num,ref bool flag)
    {
        //持っているカードの値の合計を出す
        num += list[getcount];
        //21を超えたら強制敗北にする
        if(num>21)
        {
            flag = true;
        }
        Debug.Log(num);
    }



    private void GameReset()
    {
        //ゲームに使う値全てリセット
        judge = false;
        deckCard.Clear();
        for(int i=1;i<maxDeckCard;i++)
        {
            deckCard.Add(i);
        }
        p1.card.Clear();
        p1.burst = false;
        p1.end = false;
        p1.getCount = 0;
        p1.sum = 0;
        p2.card.Clear();
        p2.burst = false;
        p2.end = false;
        p2.getCount = 0;
        p2.sum = 0;
        winner = "";
    }
}
