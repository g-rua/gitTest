using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndPattern : MonoBehaviour
{
    [SerializeField] GameManage gameManage;
    [SerializeField] FallCameraMove fcm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointTimeProccesing(ref int time,ref bool flag)
    {
        flag = true;
        time = 0;
    }

    public void SurvivalTimeProccesing(ref int time, ref int defTime, int stageindex, int maxstageindex, ref bool flag)
    {
        if(stageindex<maxstageindex+1)
        {
            time = defTime;
        }
        else
        {
            flag = true;
        }
    }

}
