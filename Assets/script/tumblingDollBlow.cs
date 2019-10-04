using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumblingDollBlow : MonoBehaviour
{
    private Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel*Time.deltaTime;
    }

    public void SetVel(Vector3 invel)
    {
        vel = invel;
    }
}
