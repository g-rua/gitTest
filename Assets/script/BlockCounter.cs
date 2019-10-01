using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] GameObject blocks;
    public int blockChildlens;
    public int redColorBlock;
    public int blueColorBlock;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(blocks.transform.childCount);
        blockChildlens = blocks.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        redColorBlock = 0;
        blueColorBlock = 0;
        for(int i=0;i<blocks.transform.childCount;i++)
        {
            if(blocks.transform.GetChild(i).GetComponent<BlockColorChange>().teamIndex==1)
            {
                blueColorBlock++;
            }
            if (blocks.transform.GetChild(i).GetComponent<BlockColorChange>().teamIndex == 2)
            {
                redColorBlock++;
            }
        }

    }
}
