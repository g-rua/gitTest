using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBoxCover : MonoBehaviour
{
    [SerializeField] Transform body;

    public Vector3 vel;
    public float rot;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            if (Mathf.Abs(transform.position.z - body.position.z) < 0.5)
            {
                transform.position += vel;
                transform.Rotate(transform.right, rot);
 
            }
            else
            {
               open = true;
            }
        }
    }



}
