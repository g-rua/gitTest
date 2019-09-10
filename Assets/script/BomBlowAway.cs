using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomBlowAway : MonoBehaviour
{
    private Vector3 targetVec;
    public int scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            transform.parent = null;
            targetVec = other.transform.position - transform.position;
            other.gameObject.transform.position += targetVec * scale;
        }
    }

}
