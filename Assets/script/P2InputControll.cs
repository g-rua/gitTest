using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2InputControll : MonoBehaviour
{
    [SerializeField] CharaCon cc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cc.SetDirection(Input.GetAxis("Vertical2"),Input.GetAxis("Horizontal2"));
    }



}
