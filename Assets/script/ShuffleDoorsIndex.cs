using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleDoorsIndex : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIndex(int idx)
    {
        index = idx;
    }
}
