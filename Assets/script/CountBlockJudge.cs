using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBlockJudge : MonoBehaviour
{
    [SerializeField] GameObject[] goals;
    [SerializeField] int[] counts;
    public int teamCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<teamCount;i++)
        {
            counts[i] = goals[i].GetComponent<OnBlockCounter>().GetCount();
        }
    }
}
