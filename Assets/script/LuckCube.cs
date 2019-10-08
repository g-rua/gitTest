using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckCube : MonoBehaviour
{
    public int luckIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetLuckIndex(int index)
    {
        luckIndex = index;
    }

    public int GetLuckIndex()
    {
        return luckIndex;
    }

    public void SetPosition()
    {
        transform.position += new Vector3(0, luckIndex * 1.5f, 0);
    }

}
