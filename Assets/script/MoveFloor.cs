using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    private float xSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="MoveFloor")
        {
            xSpeed = other.transform.GetComponent<MeshRenderer>().materials[0].GetFloat("_XSpeed")*-1f;
            transform.position -= new Vector3(xSpeed, 0, 0)*Time.deltaTime;
        }
    }

}
