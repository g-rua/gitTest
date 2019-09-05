using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashActiveSwitch : MonoBehaviour
{
    [SerializeField] GameObject flash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void FlashSwitch()
    {
        if (!flash.activeInHierarchy)
        {
            flash.gameObject.SetActive(true);
        }
        else
        {
            flash.gameObject.SetActive(false);
        }
    }
}
