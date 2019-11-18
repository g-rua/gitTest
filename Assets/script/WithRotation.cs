using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithRotation : MonoBehaviour
{
    public float rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,rot);
    }
}
