using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleDoorsIndex : MonoBehaviour
{
    public int index;
    public int childIndex;
    // Start is called before the first frame update
    void Start()
    {
        childIndex = Random.Range(0, transform.childCount);
        SetNextStageIndex(childIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetNextStageIndex(int chIdx)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            bool flag = false;
            if(i==chIdx)
            {
                flag = true;
            }
            transform.GetChild(i).GetComponent<StageProceedOrReturn>().SetProceedFlag(flag);
            ActiveChildScript(i,flag);
        }
    }

    private void ActiveChildScript(int i,bool flag)
    {
        if(flag)
        {
            transform.GetChild(i).GetComponent<ReturnRandomDoors>().enabled = false;
            transform.GetChild(i).GetComponent<ProceedRandomDoors>().enabled = true;
        }
        else
        {
            transform.GetChild(i).GetComponent<ReturnRandomDoors>().enabled = true;
            transform.GetChild(i).GetComponent<ProceedRandomDoors>().enabled = false;
        }
    }

}
