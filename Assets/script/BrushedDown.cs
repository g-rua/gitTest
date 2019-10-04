using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushedDown : MonoBehaviour
{
    public Vector3 blowVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag=="tumblingDoll")
        {
            col.gameObject.transform.GetComponent<tumblingDollBlow>().SetVel(blowVel);
        }
    }

}
