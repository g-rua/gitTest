using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPollSpeed : MonoBehaviour
{
    [SerializeField] GameManage gm;
    [SerializeField] ObjectRotation or;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(gm.drawTime<20)
        {
            rotSpeed = 4;
        }
       if(gm.drawTime<10)
        {
            rotSpeed = 6;
        }
        or.rot = rotSpeed;
    }
}
