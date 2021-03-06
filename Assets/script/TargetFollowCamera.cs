﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Vector3 offset;
    private Vector3 targetPos;
    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        //対象の座標を取得
        targetPos = target.transform.position;
        //対象開ける距離を決める
        offset = target.transform.position - transform.position;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        //対象に追随させる
        transform.position += new Vector3(target.transform.position.x - targetPos.x, target.transform.position.y - targetPos.y, target.transform.position.z - targetPos.z);
        //対象の座標を更新
        targetPos = target.transform.position;
        //カメラを対象の周りを回らせる(X方向)
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");

            transform.RotateAround(targetPos, Vector3.up, mouseX * Time.deltaTime * 300f);

        }
        //カメラを対象の周りを回らせる(Y方向)
        if (Input.GetMouseButton(1))
        {

            mouseY = Input.GetAxis("Mouse Y");
            transform.RotateAround(targetPos, transform.right, mouseY * Time.deltaTime * 300f);
        }
        //カメラを近づかせたり遠ざけたり
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * 2;
    }
}
