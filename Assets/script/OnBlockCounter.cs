using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBlockCounter : MonoBehaviour
{
    [SerializeField] GameObject ef;
    private Vector3 up;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        up=new Vector3(0,3f,0);
    }

    // Update is called once per frame
    void Update()
    {
        counter = transform.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.layer==9)
        {
            if (other.transform.parent == null)
            {
                GameObject.Instantiate(ef, transform.position+up, Quaternion.identity);
                other.transform.parent = transform;
            }
        }
    }

    public int GetCount()
    {
        return counter;
    }

}
