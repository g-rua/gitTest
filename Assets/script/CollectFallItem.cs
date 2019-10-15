using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFallItem : MonoBehaviour
{
    public int collectItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="FallItem")
        {
            Destroy(other);
            collectItem+=1;
        }
    }

}
