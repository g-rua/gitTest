using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloorMove : MonoBehaviour
{
    [SerializeField] Transform initPos;
    [SerializeField] Transform destPos;
    [SerializeField] Transform target;
    public bool moveFlag;
    public bool returnFlag;
    private Vector3 vel;
    public float mag;
    // Start is called before the first frame update
    void Start()
    {
        target = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveFlag)
        {
            Vector3 vec = target.position - transform.position;
            if(!returnFlag)
            {
                target = destPos;
                if (transform.position.z<target.position.z+0.5f)
                {
                    returnFlag= true;
                }
            }
            else
            {
                target = initPos;

                if (transform.position.z>target.position.z-0.5f)
                {
                    moveFlag = false;
                    returnFlag = false;
                    transform.position = target.position;
                }
            }
                //vec = target.position - transform.position;
            mag = vec.magnitude;
            transform.position += vec*Time.deltaTime;
        }
    }

    public void BoShoot()
    {
        moveFlag = true;
    }
}
