using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public static int gameCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public static void Reset()
    {
        gameCount = 0;
    }

    public static void SetCount(int count)
    {
        gameCount = count;
    }

}
