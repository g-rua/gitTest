using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyntLaserDodge : MonoBehaviour
{
    [SerializeField] Transform stepPos;
    [SerializeField] Transform nextPos;
    private Vector3 vel;
    private Vector3 vec;
    private int index=0;
    private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = stepPos.GetChild(index);
    }

    // Update is called once per frame
    void Update()
    {

        vec = nextPos.position - transform.position;
        transform.position += vec * speed * Time.deltaTime;
        if(Mathf.Abs(vec.magnitude)<1f)
        {
            index++;
        if(index>1)
        {
            index = 0;
        }
            nextPos = stepPos.GetChild(index);
        }
        transform.rotation = nextPos.rotation;
    }
}
