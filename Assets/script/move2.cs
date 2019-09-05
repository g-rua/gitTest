using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
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
    public float velY = 0f;
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
        ac.SetOnGround(Ground);
        g = Ground;
        horizontal = Input.GetAxis("Horizontal2");
        vertical = Input.GetAxis("Vertical2");
        //移動アニメーションの設定
        ac.SetWalkAnimation(vertical);
        //移動
        MoveMent();
        //アイテムの持ち運び
        if (Input.GetKeyDown(KeyCode.C))
        {
            ItemCarry();
        }
        if(Input.GetKeyDown(KeyCode.Z))
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
            velY += -8f * Time.deltaTime;
            vel.y += velY;
        }


        Jump();

        vel.y += velY;
        transform.position += ((transform.forward) * (speed * vertical) + vel) * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.X) && Ground)
        {

            Debug.Log("jump");
            velY = 1.13f;
            Ground = false;
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

}
