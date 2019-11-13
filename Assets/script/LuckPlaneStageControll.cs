using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckPlaneStageControll : MonoBehaviour
{
    [SerializeField] GameObject[] stage;
    private int stageIndex = 0;
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
        if(Input.GetKeyDown(KeyCode.Return))
        {
            for(int i=0;i<stage[stageIndex].transform.childCount;i++)
            {
                stage[stageIndex].transform.GetChild(i).GetComponent<LuckPlaneDesolve>().enabled = true;
            }
            stage[stageIndex].GetComponent<FallOrBom>().enabled = true;

            stageIndex++;
        }

    }
}
