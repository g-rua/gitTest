using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlockpop : MonoBehaviour
{
    [SerializeField] GameObject colorBlock;
    private float diff = 1.1f;
    private int xCnt=10;
    private int zCnt=10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<zCnt;i++)
        {
            for(int j=0;j<xCnt;j++)
            {
                GameObject.Instantiate(colorBlock, new Vector3(transform.position.x + (diff * j), transform.position.y ,transform.position.z + (-diff * i)), Quaternion.identity,transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
