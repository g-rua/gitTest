using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingGame : MonoBehaviour
{
    public int timer;
    [SerializeField] GameObject fall1;
    [SerializeField] GameObject fall2;
    [SerializeField] GameObject t1;
    [SerializeField] GameObject t2;
    [SerializeField] GameObject win;
    public Vector3 diff1;
    public Vector3 diff2;
    public float mag1;
    public float mag2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            fall1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            diff1 = fall1.transform.position - t1.transform.position;
            mag1 = diff1.magnitude;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            fall2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            diff2 = fall2.transform.position - t2.transform.position;
            mag2 = diff2.magnitude;
        }

        if(mag1<mag2)
        {
            win = t1;
        }
        else
        {
            win = t2;
        }

    }
}
