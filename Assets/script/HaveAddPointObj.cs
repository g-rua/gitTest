using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveAddPointObj : MonoBehaviour
{
    public GameObject carrier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            transform.parent.GetComponent<HaveAddPoint>().point++;
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"&&transform.parent==null)
        {
            carrier = other.gameObject;
            transform.position = other.gameObject.transform.Find("AddPointPos").position;
            transform.parent = other.gameObject.transform.Find("AddPointPos");
            
        }
    }

}
