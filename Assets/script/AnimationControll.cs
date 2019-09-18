using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    [SerializeField] bool playerOnGround;
    [SerializeField] Animator anim;
    public enum MotionType
    {
        mt_none,
        mt_walk,
        mt_wave,
        mt_opendoor,
    };
    private Ray ray;
    private int rayDistance = 1;
    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnGround)
        {
            anim.SetBool("Grounded", true);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }

    }

    public void ExcuteMotion(MotionType mt)
    {
        switch (mt)
        {
            case MotionType.mt_none:
                break;
            case MotionType.mt_walk:
                anim.SetFloat("MoveSpeed", movement);
                break;
            case MotionType.mt_wave:
                anim.SetBool("Wave", true);
                break;
            case MotionType.mt_opendoor:
                anim.SetBool("opendoor", true);
                break;
            default:
                break;

        }

    }

    public void SetOnGround(bool ground)
    {
        playerOnGround = ground;
    }

    public void SetMovement(float vert)
    {
        movement = vert;
    }

}
