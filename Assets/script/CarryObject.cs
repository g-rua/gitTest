using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    //左手のターゲット座標系
    [SerializeField] Transform leftHandTransform;
    //右手のターゲット座標系
    [SerializeField] Transform rightHandTransform;
    //ターゲットオブジェクト
    [SerializeField] GameObject targetObj;
    //IKを反映させるコントローラ
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ターゲットのオブジェクトの向きを合わせる
        if (targetObj != null)
        {
        }

    }

    public void OnAnimatorIK(int layerIndex)
    {
        //ターゲットオブジェクトに右手で持つ場所があるとき
        if (rightHandTransform != null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.1f);
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandTransform.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandTransform.rotation);
        }
        //ターゲットオブジェクトに左手で持つ場所があるとき
        if (leftHandTransform != null)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.1f);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTransform.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTransform.rotation);
        }
    }

    public void SetCarryObject(GameObject obj)
    {
        //持ち運ぶオブジェクトの設定
        targetObj = obj;
        //それぞれの手の位置を決める
        rightHandTransform = targetObj.transform.Find("RightHandPos");
        leftHandTransform = targetObj.transform.Find("LeftHandPos");
        targetObj.transform.rotation = transform.rotation;

    }

    public void ObjRelease()
    {
        //手放すために親の解除、手の位置の解除
        targetObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        targetObj = null;
        rightHandTransform = null;
        leftHandTransform = null;
        
    }
}
