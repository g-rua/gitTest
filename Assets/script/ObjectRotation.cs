using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] Vector3 axis;
    public float rot;
    public float rotSpeed;
    public bool up;
    public bool right;
    public bool forward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rot += rotSpeed*Time.deltaTime;
        if (obj != null)
        {
            if(up)
            {
                obj.transform.Rotate(Vector3.up, rot);
            }
            if (right)
            {
                obj.transform.Rotate(Vector3.right, rot);
            }
            if(forward)
            {
                obj.transform.Rotate(Vector3.forward, rot);
            }

        }
    }
}
