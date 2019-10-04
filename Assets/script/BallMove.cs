using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public Vector3 dashVel;
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

        vel *=0.9f;
        
        transform.position += vel * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="dashground")
        {

           vel =dashVel;
            
        }
    }

}
