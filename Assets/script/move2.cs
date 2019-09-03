using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    private Vector3 vel;
    private float speed = 5f;
    private float jumpPow = 10f;
    private float velY = 0f;
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

        //プレイヤー２操作スクリプト
        GetComponent<AnimationControll>().SetOnGround(Ground);
        g = Ground;
        vel = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));
        transform.position += vel * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) && Ground)
        {
            velY = jumpPow;
            Ground = false;
        }

    }
}
