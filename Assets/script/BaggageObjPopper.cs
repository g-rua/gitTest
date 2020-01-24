using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggageObjPopper : MonoBehaviour
{
    [SerializeField] GameObject[] presents;
    public int popperTime;
    private int popperTimer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((popperTimer++)*Time.deltaTime>popperTime)
        {
            popperTimer = 0;
            GameObject.Instantiate(presents[Random.Range(0, presents.Length)], new Vector3(Random.Range(-10, 10), 10, Random.Range(-10, 10)), Quaternion.identity);
        }
    }



}
