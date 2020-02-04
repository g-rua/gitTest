using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCameraMove : MonoBehaviour
{
    [SerializeField] Transform[] campos;
    private int idx=0;
    [SerializeField] GameManage gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //        transform.position = campos[gm.stageindex].position;
    }

}
