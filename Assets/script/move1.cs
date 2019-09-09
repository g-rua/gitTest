using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    [SerializeField] AnimationControll ac;
    [SerializeField] GameObject triggerCheckCollider;
    [SerializeField] CarryObject carryObj;
    [SerializeField] TriggerChecker tc;
    private CarryItemAction itemAction;
    public GameObject haveObj;
    public Vector3 vel;
    private float horizontal;
    private float vertical;
    private float speed = 5f;
    private float jumpPow = 10f;
    public int jumpFlame = 0;
    public int maxJumpFlame = 10;
    public int harfJumpFlame = 5;
    public float velY = 0f;
    public float harfVelY = 0.95f;
    public float maxVelY = 1.4f;
    public bool g;
    public bool isCarry;
    public bool Ground { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Ground = false;
        itemAction = GetComponent<CarryItemAction>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー1操作用
        ac.SetOnGround(Ground);
        g = Ground;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //移動アニメーションの設定
        ac.SetWalkAnimation(vertical);
        //移動
        MoveMent();
        //アイテムの持ち運び
        if (Input.GetKeyDown(KeyCode.V))
        {
            ItemCarry();
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            itemAction.ItemAction(haveObj);
        }
        transform.Rotate(Vector3.up, horizontal * 3f);
    }

    private void MoveMent()
    {
        if (vel.y <= 0f)
        {
            velY = 0f;
            vel.y = 0f;
        }
        else
        {
            velY += -0.15f;
            vel.y += velY;
        }

        if (Input.GetKey(KeyCode.Space) && Ground)
        {
            jumpFlame++;

            if (jumpFlame >= maxJumpFlame)
            {
                DecideJumpPower(jumpFlame);
                Jump();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && Ground)
        {
            Debug.Log("harf");
            DecideJumpPower(jumpFlame);
            Jump();
        }
        if (GetComponent<TriggerChecker>().jumpPanelFlag)
        {
            HighJump();
        }

        vel.y += velY;
        transform.position += ((transform.forward) * (speed * vertical) + vel) * Time.deltaTime;
    }

    private void DecideJumpPower(int flame)
    {
        if (flame <= harfJumpFlame)
        {
            velY = harfVelY;
        }
        else
        {
            velY = maxVelY;
        }
    }

    private void Jump()
    {
        Debug.Log("jump");
        jumpFlame = 0;
        Ground = false;
    }

    private void HighJump()
    {
        jumpFlame = 0;
        Ground = false;
        velY = 1.5f;
    }

    private void ItemCarry()
    {
        //アイテムを手放す
        if (isCarry && haveObj != null)
        {
            isCarry = false;
            haveObj.transform.parent = null;
            haveObj = null;
            carryObj.ObjRelease();
        }
        //アイテムを持ち上げる
        if (!isCarry && tc.GetObject().transform.parent == null)
        {
            isCarry = true;
            carryObj.SetCarryObject(tc.GetObject());
            haveObj = tc.GetObject();
            haveObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            tc.GetObject().transform.position = triggerCheckCollider.transform.position;
            tc.GetObject().transform.parent = transform;
            tc.Carry();
        }

    }

}
