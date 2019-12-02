using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleImageControll : MonoBehaviour
{
    [SerializeField] Transform moveObj;
    [SerializeField] Transform goalPos;
    [SerializeField] Transform target;
    [SerializeField] float goalX;
    public Vector3 speed;
    public float one=1f;
    public bool reverse;
    public bool end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = transform.position - goalPos.position;
        if (end)
        {
            //goalPos = target;
            //if (Mathf.Abs(vel.x) <= 5f)
            //{
                transform.position = goalPos.position;
                speed = Vector3.zero;
            //}
        }
        else
        {
            if (Mathf.Abs(vel.x) <= 5f)
            {
                speed.x *= -1f;
                end = true;
            }

        }
        speed.y = ((Mathf.Sin(Time.time * 3f)) * 8f);

        transform.position += speed;


    }
}
