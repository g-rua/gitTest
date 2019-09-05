using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public bool canCarry = false;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetObject()
    {
        return item;
    }

    public void Carry()
    {
        item = null;
        canCarry = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CarryItem")
        {
            canCarry = true;
            item = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag=="CarryItem")
        {
            canCarry = false;
            item = null;
        }
    }

}
