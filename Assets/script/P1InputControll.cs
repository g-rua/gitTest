using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1InputControll : MonoBehaviour
{
    [SerializeField] CharaCon cc;
    [SerializeField] CarryItemAction itemAction;
    private GameObject haveObj;
    private bool Ground;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //jumpFlame = cc.jumpFlame;
        haveObj = cc.haveObj;
        Ground = cc.g;
        cc.SetDirection(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.F))
        {
            cc.ItemCarry();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            itemAction.ItemAction(haveObj);
        }

        //ジャンプの区別
        if (Input.GetKey(KeyCode.Space) && Ground)
        {
            //小ジャンプか大ジャンプを区別するためにインクリメント
            cc.jumpFlame++;

            //一定値以上になったら強制ジャンプ
            if (cc.jumpFlame >= cc.maxJumpFlame)
            {
                cc.DecideJumpPower(cc.jumpFlame);
                cc.jumpFlame = 0;
            }
        }

        //即離した場合
        if (Input.GetKeyUp(KeyCode.Space) && Ground)
        {
            Debug.Log("harf");
            cc.DecideJumpPower(cc.jumpFlame);
            cc.jumpFlame = 0;
        }

    }



}
