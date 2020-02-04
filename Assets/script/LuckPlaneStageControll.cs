using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckPlaneStageControll : MonoBehaviour
{
    [SerializeField] GameObject[] stage;
    private int stageIndex = 0;
    [SerializeField] GameManage gm;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<stage.Length;i++)
        {
            stage[i].GetComponent<FallOrBom>().enabled = false; ;
            for(int j=0;j<stage[i].transform.childCount;j++)
            {
                stage[i].transform.GetChild(i).GetComponent<LuckPlaneDesolve>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.waitflag)
        {
            for(int i=0;i<stage[gm.stageindex-1].transform.childCount;i++)
            {
                stage[gm.stageindex-1].transform.GetChild(i).GetComponent<LuckPlaneDesolve>().enabled = true;
            }
            stage[gm.stageindex-1].GetComponent<FallOrBom>().enabled = true;

            //stageIndex++;
        }

    }
}
