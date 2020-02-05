using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var name = Input.GetJoystickNames();
        Debug.Log(name[0]);
        GetComponent<Text>().text = name[0];
    }
}
