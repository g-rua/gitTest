using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underPipeCreate : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    private float diffx = 1f;
    public int popCnt;
    public int popCnter;
    // Start is called before the first frame update
    void Start()
    {
        while(popCnter<popCnt)
        {
            GameObject.Instantiate(pipe, new Vector3(transform.position.x+(-diffx*popCnter+1), 11.53f, transform.position.z), pipe.transform.rotation);
            popCnter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
