using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItemAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemAction(GameObject obj)
    {
        if (obj == null) return;
        switch (obj.layer)
        {
            case 8:
                obj.GetComponent<FlashActiveSwitch>().FlashSwitch();
                break;
            case 9:
                break;
            default:
                break;

        }

    }
}
