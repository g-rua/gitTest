using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addscire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameScore.score[0] += 50;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameScore.score[1] += 50;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameScore.score[2] += 50;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameScore.score[3] += 50;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameScore.Reset();
        }
    }
}
