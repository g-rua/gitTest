using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterControll : MonoBehaviour
{
    private Vector3 vel;
    public Vector3 initPos;
    public Vector3 endPos;
    public bool moveFlag;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShutterClose()
    {

            initPos = new Vector3(0, 960, 0);
            vel = new Vector3(0, -10, 0);

            endPos = new Vector3(0,0, 0);
        if (transform.position.y <= endPos.y)
        {
            vel = Vector3.zero;
            GetComponent<sceneMove>().NoFadeChange();
        }
        transform.position += vel;

    }

    public void ShutterOpen()
    {

        initPos = Vector3.zero;
            vel = new Vector3(0, 10, 0);
            //transform.position = initPos;
            endPos = new Vector3(0, 960, 0);
        if (Mathf.Abs(transform.position.y) >= endPos.y)
        {
            vel = Vector3.zero;
        }
        transform.position += vel;
        

    }
}

