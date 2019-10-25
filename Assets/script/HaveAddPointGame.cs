using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveAddPointGame : MonoBehaviour
{
    public int[] points;
    [SerializeField] HaveAddPoint[] hap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<points.Length;i++)
        {
            //追加されてくる仮ポイントを1秒ごとに本ポイントにする
            points[i] = hap[i].point/60;
        }
    }
}
