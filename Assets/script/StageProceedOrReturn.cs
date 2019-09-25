using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageProceedOrReturn : MonoBehaviour
{
    public bool proceed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProceedFlag(bool flag)
    {
        proceed = flag;
    }

    public Vector3 ProceedOrReturn()
    {
        if(proceed)
        {
            return GetComponent<ProceedRandomDoors>().GetPosition();
        }
        else
        {
            return GetComponent<ReturnRandomDoors>().GetPosition();
        }
    }

}
