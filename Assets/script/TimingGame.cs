using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingGame : MonoBehaviour
{
    public int timer;
    [SerializeField] GameObject fall1;
    [SerializeField] GameObject fall2;
    [SerializeField] GameObject t1;
    [SerializeField] GameObject t2;
    [SerializeField] GameObject win;
    public Vector3 diff1;
    public Vector3 diff2;
    public float mag1;
    public float mag2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once 
    void Update()
    {
        //それぞれのタイミングで止める
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            //押したら落とすのをやめる
            fall1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //止まったものと対象との距離を取る
            diff1 = fall1.transform.position - t1.transform.position;
            //ベクトルの大きさを取る
            mag1 = diff1.magnitude;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            //押したら止める
            fall2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //止まったものと対象との距離を取る
            diff2 = fall2.transform.position - t2.transform.position;
            //ベクトルの大きさを取る
            mag2 = diff2.magnitude;
        }

        //それぞれの大きさを比較して小さいほうの勝利
        if(mag1<mag2)
        {
            win = t1;
        }
        else
        {
            win = t2;
        }

    }
}
