using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Vector3 vel;
    private int dashCount=0;
    private bool dashFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(dashFlag)
        {
        transform.position += vel*Time.deltaTime;
            if(dashCount--<0)
            {
                dashFlag = false;
            }
        }
        else
        {
            vel = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="dashground")
        {
            dashFlag = true;
            dashCount = 10;
           vel =new Vector3(0,8f,-10f);
            
        }
    }

}
