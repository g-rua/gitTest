using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBomPopper : MonoBehaviour
{
    [SerializeField] GameObject bom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Instantiate(bom, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
