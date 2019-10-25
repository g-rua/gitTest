using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveAddPointObj : MonoBehaviour
{
    public GameObject carrier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            //このオブジェクトを勝手に動けなくする
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //親がいた場合その親が持っているスクリプトの数値を足していく
            transform.parent.GetComponent<HaveAddPoint>().point++;
        }
        else
        {
            //このオブジェクトを自由にする
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーが何も持っていない状態で接触
        if(other.tag=="Player"&&transform.parent==null)
        {
            //自身に誰に運ばれているか覚えさせる
            carrier = other.gameObject;
            //座標を指定の場所に置く
            transform.position = other.gameObject.transform.Find("AddPointPos").position;
            //親の頭頂部についていかせるため子にする
            transform.parent = other.gameObject.transform.Find("AddPointPos");
            
        }
    }

}
