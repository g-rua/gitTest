using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatHitBom : MonoBehaviour
{
    [SerializeField] GameObject exp;
    [SerializeField] GameObject expInstance;
    public int maxTapCount;
    public int tapCount;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //連打していく事で爆弾が拡大
        if(Input.GetKeyDown(KeyCode.Return))
        {
            tapCount++;
        transform.localScale += new Vector3(scale ,scale ,scale);
        }
        //一定数超えたら爆弾が爆発する
        if(tapCount>maxTapCount)
        {
            exp = GameObject.Instantiate(expInstance, transform.position, Quaternion.identity);
            exp.transform.localScale = transform.localScale;
            //Destroy(this.gameObject);
        }
        //連打数で色を変えさせる
        GetComponent<RepeatHitBomColor>().TapCountChangeAlpha(tapCount, maxTapCount);
    }
}
