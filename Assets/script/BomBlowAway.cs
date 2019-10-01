using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomBlowAway : MonoBehaviour
{
    private Vector3 targetVec;
    private Vector3 up;
    public int scale;
    private int hitCount = 3;
    // Start is called before the first frame update
    void Start()
    {
        up = new Vector3(0, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        hitCount--;
        if(hitCount<0)
        {
            Destroy(GetComponent<SphereCollider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.tag == "Player")
            {
                //爆風に当たった時にプレイヤーを吹っ飛ばす
                transform.parent = null;
                //吹っ飛ばす方向を決めるため、プレイヤーと爆風のベクトルを取得
                targetVec = other.transform.position - transform.position;
                //ベクトルに倍率をかけて吹っ飛ばす
                other.gameObject.GetComponent<CharaCon>().SetVel((targetVec + up) * scale);
            }
        
    }

}
