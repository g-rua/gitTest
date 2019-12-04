using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharaMove : MonoBehaviour
{
    
    public Transform destination;
    private Vector3 vel;
    private Vector3 vec;
    public float speed;
    public AnimationControll ac;
    public bool Ground { set; get; }
    public bool g;
    public bool end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        g = Ground;
        Animations();
        vec = destination.position - transform.position;
        if(vec.magnitude<=0.5f)
        {
            speed = 0;
            end = true;
        }
        if (!end)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vec), 0.5f);
        }
    }

    private void Animations()
    {
        //animationsControllが着地しているか見れるために
        ac.SetOnGround(Ground);
        //移動アニメーションの設定
        ac.SetMovement(speed,speed );
        ac.ExcuteMotion(AnimationControll.MotionType.mt_walk);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Boshoot")
        {
            Destroy(this.gameObject);
        }
    }
}
