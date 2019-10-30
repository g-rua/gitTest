using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCon : MonoBehaviour
{
    //カメラ　移動方向を決めるために設定
    [SerializeField] Camera cam;
    //アニメーション用
    [SerializeField] AnimationControll ac;
    //トリガー処理をするためのコライダー
    [SerializeField] GameObject triggerCheckCollider;
    //アイテムを運搬するための処理をするスクリプト
    [SerializeField] CarryObject carryObj;
    //トリガー処理するためのチェックをするスクリプト
    [SerializeField] TriggerChecker tc;
    //持っているアイテムによってアクションを変えるスクリプト
    private CarryItemAction itemAction;
    private Vector3 moveVel;
    public GameObject haveObj;
    //外部から影響を受けるためのベロシティ
    public Vector3 vel;
    private float horizontal;
    private float vertical;
    private float speed = 5f;
    private float jumpPow = 10f;
    private float rotY;
    public int jumpFlame = 0;
    public int maxJumpFlame = 10;
    public int harfJumpFlame = 5;
    public float velY = 0f;
    public float harfVelY = 0.95f;
    public float maxVelY = 1.1f;
    public bool g;
    public bool isCarry;

    public bool Ground { get; set; }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー２操作用
        velY = Mathf.Clamp(velY, 0f, maxVelY);
        Animations();
        g = Ground;
        //移動
        MoveMent();

    }

    private void MoveMent()
    {
        //ジャンプの処理
        if (vel.y <= 0f)
        {
            //0以下にになったらめり込まないように減算をやめる
            vel = Vector3.zero;
        }
        else
        {
            //0以上なら加速度に重力を加算しつつ上昇させる
            velY += -0.15f;
            vel.y += velY;
        }
        moveVel.x = horizontal;
        moveVel.z = vertical;

        //ジャンプパネルを踏んだら大ジャンプより高いジャンプをする
        if (GetComponent<TriggerChecker>().jumpPanelFlag)
        {
            HighJump();
        }

        //Debug.Log(jumpFlame);
       
        vel.y += velY;
        //transform.position += ((transform.forward) * (speed*vertical) + vel) * Time.deltaTime;

        //カメラの向きによって移動方向を決めるためカメラの正面のベクトルを取得
        Vector3 cameraForward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        //キャラクターの移動方向をカメラの向きに従って変える
        Vector3 moveForward = (cameraForward * vertical + cam.transform.right * horizontal);
        Vector3 velocity = transform.forward * speed * Time.deltaTime;
        transform.position += (((moveForward * speed)+ vel) * Time.deltaTime) ;

        if (moveForward != Vector3.zero)
        {
            //移動する方向に回転させる
            transform.rotation = Quaternion.LookRotation(moveForward);
        }


    }


    public void SetDirection(float vert,float hori)
    {
        horizontal = hori;
        vertical = vert;
    }


    public void DecideJumpPower(int flame)
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

    public void Jump()
    { 
        Debug.Log("jump");
        //jumpFlame = 0;
        Ground = false;
    }

    private void HighJump()
    {
        Ground = false;
        velY = 1.5f;
        //jumpFlame = 0;
    }

    private void Animations()
    {
        //animationsControllが着地しているか見れるために
        ac.SetOnGround(Ground);
        //移動アニメーションの設定
        ac.SetMovement(vertical,horizontal);

        ac.ExcuteMotion(AnimationControll.MotionType.mt_walk);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ac.ExcuteMotion(AnimationControll.MotionType.mt_opendoor);
        }
    }

    public void ItemCarry()
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
        if (!isCarry&&
            (tc.GetObject().transform.parent == null||
            tc.GetObject().transform.parent.tag != "Player"))
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

    public void Release()
    {
        isCarry = false;
        haveObj.transform.parent = null;
        haveObj = null;
        carryObj.ObjRelease();

    }

    public void SetVelY(float y)
    {
        velY = y;
    }

    public void SetVel(Vector3 invel)
    {
        vel = invel;
    }

}
