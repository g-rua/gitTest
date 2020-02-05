using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckTest : MonoBehaviour
{
    [SerializeField] GameManage gm;
    [SerializeField] GameObject luckCube;
    private int luckIndex;
    private List<int> luckIndexes =new List<int>();
    public int time;
    public int timer;
    public bool upFlag;
    [SerializeField] Transform camt;
    // Start is called before the first frame update
    void Start()
    {
        //リストにキューブに格納する用の数値を設定
        for (int i = 0; i < luckCube.transform.childCount; i++)
        {
            luckIndexes.Add(i);
        }
        //SetLuckCubeIndex();
    }

    // Update is called once per frame
    void Update()
    {


        if(upFlag)
        {
            if(camt.position.y<34)
            {
                camt.position += new Vector3(0, 0.2f, -0.1f);
            }
              //upFlag = false;          
            for (int i = 0; i < luckCube.transform.childCount; i++)
            {
                //luckCube.transform.GetChild(i).GetComponent<LuckCube>().SetPosition();
                SetLuckCubeIndex();

            }

        }
        if((gm.drawTime<7)&&!upFlag)
        {
            upFlag = true;
        }

        //if ((timer++) * Time.deltaTime > time)
        //{
        //    upFlag = true;
        //}
        //if (upFlag)
        //{
        //    timer = 0;
        //}
    }

    private void SetLuckCubeIndex()
    {


        //子にアクセスするための数値
        int cubeIndex = 0;
        //リストにある分回す
        while (luckIndexes.Count > 0)
        {
            //どの数値を取り出すか決める
            luckIndex = Random.Range(0, luckIndexes.Count);
            //数値を取り出す
            int index = luckIndexes[luckIndex];
            //取り出した数値をそれぞれのキューブに設定する
            luckCube.transform.GetChild(cubeIndex).GetComponent<LuckCube>().SetLuckIndex(index);
            
            //重複しないように使った数値は消す
            luckIndexes.RemoveAt(luckIndex);
            //アクセスする子の数値を進める
            cubeIndex++;
        }
        
    }

}
