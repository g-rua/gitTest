using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    [SerializeField] bool playerOnGround;
    [SerializeField] Animator anim;
    private Ray ray;
    private int rayDistance = 1;
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

    public void SetOnGround(bool ground)
    {
        playerOnGround = ground;
    }

    public void SetWalkAnimation(float vertical)
    {
        anim.SetFloat("MoveSpeed",vertical);
    }

}
