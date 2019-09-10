using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] Vector3 axis;
    public float rot;
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += rotSpeed*Time.deltaTime;
        obj.transform.Rotate(Vector3.right, rot);
    }
}
