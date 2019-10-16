using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotteryRotation : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] Vector3 axis;
    private Quaternion InitQuat;
    public float firstRot;
    public float rotSpeed;  //変更可能な回転初速値
    public float decaySpeed;   //減衰速度 要は摩擦
    public bool up;
    public bool right;
    public bool forward;
    public float rot;          //回転速度

    // Start is called before the first frame update
    void Start()
    {
        InitQuat = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        LotteryRot();
    }

    public void LotteryRot()
    {




        if (rot < 1f)
        {
            if (transform.rotation.z- InitQuat.z<0.1f)
            {
                rot = 0f;
            }
        }
        else
        {
        rot = rot - decaySpeed; //摩擦でゆっくり
        }
        if (rot > 0)
        {
            if (up)
            {
                obj.transform.Rotate(Vector3.up, rot);
            }
            if (right)
            {
                obj.transform.Rotate(Vector3.right, rot);
            }
            if (forward)
            {
                obj.transform.Rotate(Vector3.forward, rot);
            }
        }

    }

    public void SetFirstRot(float frot)
    {
        firstRot = frot;
        if (rot < firstRot)
        {
            rot += firstRot;    //上のif文で速度制限してます
        }
    }
    public float GetRot()
    {
        return rot;
    }

}
