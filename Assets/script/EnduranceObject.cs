using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnduranceObject : MonoBehaviour
{
    [SerializeField] GameObject[] obj;
    [SerializeField] GameObject enduranceObj;
    private int popCount;
    private int popTime;
    private int popTimer;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        popTime = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        if(++popTimer>popTime)
        {
            scale = new Vector3(Random.Range(70, 200f), Random.Range(70f, 200f), Random.Range(70f, 200f));
            enduranceObj = GameObject.Instantiate(obj[Random.Range(0,obj.Length)], transform.position, Quaternion.identity);
            enduranceObj.transform.localScale = scale;
            popTimer = 0;
            popTime = Random.Range(0, 250);
        }
    }
}
