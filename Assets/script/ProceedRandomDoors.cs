using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceedRandomDoors : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPosition()
    {
        return target.transform.position;
    }

}
