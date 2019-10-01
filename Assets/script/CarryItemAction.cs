using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItemAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemAction(GameObject obj)
    {
        if (obj == null) return;
        //それぞれのレイヤー番号を見て分岐
        switch (obj.layer)
        {
            case 8:
                //懐中電灯のオンオフ
                obj.GetComponent<FlashActiveSwitch>().FlashSwitch();
                break;
            case 9:
                break;
            case 10:
                //ボムを投げるために向いてる方向を取得
                Vector3 vec = obj.transform.position - transform.position;
                //投げる速度をかけて速度を決定
                Vector3 throwVec = new Vector3(vec.x * 20f, 3f, vec.z * 20f);
                //投げる
                obj.GetComponent<BomControll>().BomThrow(throwVec);
                //投げるからアイテムを離す処理をする
                GetComponent<CharaCon>().Release();
                break;
            default:
                break;

        }

    }
}
