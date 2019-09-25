using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCon : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] AnimationControll ac;
    [SerializeField] GameObject triggerCheckCollider;
    [SerializeField] CarryObject carryObj;
    [SerializeField] TriggerChecker tc;
    private CarryItemAction itemAction;
    private Vector3 moveVel;
    public GameObject haveObj;
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
        Ground = false;
        itemAction = GetComponent<CarryItemAction>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー２操作用
        velY = Mathf.Clamp(velY, 0f, maxVelY);
        //horizontal = Input.GetAxis("Horizontal2");
        //vertical = Input.GetAxis("Vertical2");
        Animations();
        g = Ground;
        //移動
        MoveMent();
        //アイテムの持ち運び
        if (Input.GetKeyDown(KeyCode.C))
        {
            ItemCarry();
        }
        //持っているアイテム毎のアクションを行う
        if(Input.GetKeyDown(KeyCode.Z))
        {
            itemAction.ItemAction(haveObj);
        }



    }

    private void MoveMent()
    {
        //ジャンプの処理
        if (vel.y <= 0f)
        {
            //0以下にになったらめり込まないように減算をやめる
            velY = 0f;
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

        //ジャンプの区別
        if(Input.GetKey(KeyCode.X)&&Ground)
        {
            //小ジャンプか大ジャンプを区別するためにインクリメント
            jumpFlame++;

            //一定値以上になったら強制ジャンプ
            if(jumpFlame>=maxJumpFlame)
            {
                DecideJumpPower(jumpFlame);
                Jump();
            }
        }

        //即離した場合
        if(Input.GetKeyUp(KeyCode.X)&&Ground)
        {
            Debug.Log("harf");
            DecideJumpPower(jumpFlame);
            Jump();
        }
        //ジャンプパネルを踏んだら大ジャンプより高いジャンプをする
        if(GetComponent<TriggerChecker>().jumpPanelFlag)
        {
            HighJump();
        }

        Debug.Log(jumpFlame);
       
        vel.y += velY;
        //transform.position += ((transform.forward) * (speed*vertical) + vel) * Time.deltaTime;

        Vector3 cameraForward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = (cameraForward * vertical + cam.transform.right * horizontal);
        Vector3 velocity = transform.forward * speed * Time.deltaTime;
        transform.position += (((moveForward * speed)+ vel) * Time.deltaTime) ;

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }


    }


    public void SetDirection(float vert,float hori)
    {
        horizontal = hori;
        vertical = vert;
    }


    private void DecideJumpPower(int flame)
    {
        if(flame<=harfJumpFlame)
        {
            velY = harfVelY;
        }
        else
        {
            velY =maxVelY;
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

    private void Animations()
    {
        //animationsControllが着地しているか見れるために
        ac.SetOnGround(Ground);
        //移動アニメーションの設定
        ac.SetMovement(vertical,horizontal);
        //ac.SetMovement(horizontal);

        ac.ExcuteMotion(AnimationControll.MotionType.mt_walk);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ac.ExcuteMotion(AnimationControll.MotionType.mt_opendoor);
        }
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
        if (!isCarry&&tc.GetObject().transform.parent==null)
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

    public void SetVel(Vector3 invel)
    {
        vel = invel;
    }

}
