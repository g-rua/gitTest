using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumblingDollPop : MonoBehaviour
{
    private int childCount;
    [SerializeField] GameObject tumblingChild;
    // Start is called before the first frame update
    void Start()
    {
        //ダルマ落としの数を決める
        childCount = Random.Range(5,20);
        //決まった数分ポップさせる
        for(int i=0;i<childCount;i++)
        {
            GameObject.Instantiate(tumblingChild, transform.position + new Vector3(0, i * 1f, 0), Quaternion.identity,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
