using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomBlowAway : MonoBehaviour
{
    private Vector3 targetVec;
    public int scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            //爆風に当たった時にプレイヤーを吹っ飛ばす
            transform.parent = null;
            //吹っ飛ばす方向を決めるため、プレイヤーと爆風のベクトルを取得
            targetVec = other.transform.position - transform.position;
            //ベクトルに倍率をかけて吹っ飛ばす
            other.gameObject.GetComponent<CharaCon>().SetVel(targetVec * scale);
        }
    }

}
