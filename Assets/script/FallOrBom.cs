using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOrBom : MonoBehaviour
{
    private int safeIndex;

    // Start is called before the first frame update
    void Start()
    {
        safeIndex = Random.Range(0, transform.childCount);
        DecideFallOrBom(safeIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecideFallOrBom(int index)
    {
        for(int i=0;i<transform.childCount;i++)
        {
            bool flag = false;
            if(i==index)
            {
                flag = true;

            }
            transform.GetChild(i).GetComponent<LuckPlaneDesolve>().desolveFlag=flag;           
        }
    }

}
