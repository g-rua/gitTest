using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
    [SerializeField] GameObject shell;
    [SerializeField] GameObject body;
    [SerializeField] GameObject fireDirection;
    private float rotSpeed;
    private Vector3 shellVel;
    public float shellSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            //発射ボタンを押したら玉を発射
            GameObject s = GameObject.Instantiate(shell, fireDirection.transform.position, fireDirection.transform.rotation);
            //飛ばす方向と速度の決定
            shellVel = fireDirection.transform.forward * shellSpeed;
            //玉に速度を与える
            s.GetComponent<Rigidbody>().AddForce(shellVel);
        }

        transform.Rotate(Vector3.up, rotSpeed * Input.GetAxis("Horizontal"));
        body.transform.Rotate(Vector3.forward, rotSpeed * Input.GetAxis("Vertical"));
    }
}
