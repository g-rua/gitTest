using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    [SerializeField] AnimationControll ac;
    private Vector3 vel;
    private float horizontal;
    private float vertical;
    private float speed = 5f;
    private float jumpPow = 10f;
    private float velY=0f;
    public bool g;
    public bool Ground { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Ground = false;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー１操作用
        ac.SetOnGround(Ground);

        g = Ground;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        ac.SetWalkAnimation(vertical);
        //vel.x = horizontal;
        //vel.z = vertical;

        if (vel.y <= 0f)
        {
            velY = 0f;
            vel.y = 0f;
        }
        else
        {
            velY += -8f * Time.deltaTime;
            vel.y += velY;
        }



        if (Input.GetKeyDown(KeyCode.Space) && Ground)
        {
            Debug.Log("jump");
            velY = 1.13f;
            Ground = false;
        }
        vel.y += velY;
        transform.position += ((transform.forward) * (speed * vertical) + vel) * Time.deltaTime;
        transform.Rotate(Vector3.up, horizontal * 3f);
    }
}
