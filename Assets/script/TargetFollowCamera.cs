using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Vector3 offset;
    private Vector3 targetPos;
    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.transform.position;
        offset = target.transform.position - transform.position;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += new Vector3(target.transform.position.x - targetPos.x, target.transform.position.y - targetPos.y, target.transform.position.z - targetPos.z);
        targetPos = target.transform.position;
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");

            transform.RotateAround(targetPos, Vector3.up, mouseX * Time.deltaTime * 300f);

        }
        if (Input.GetMouseButton(1))
        {

            mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(targetPos, Vector3.forward, mouseY * Time.deltaTime * 300f);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * 2;
    }
}
