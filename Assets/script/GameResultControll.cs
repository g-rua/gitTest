using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultControll : MonoBehaviour
{
    [SerializeField] ShutterControll shutter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shutter.ShutterOpen();
    }
}
