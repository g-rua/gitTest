using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GroundChecker : MonoBehaviour
{
    public UnityEvent OnEnterGround;
    public UnityEvent OnExitGround;
    private int enterNum=0;
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
        Debug.Log("Ground");
        enterNum++;
        OnEnterGround.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Air");
        enterNum--;
        if(enterNum<=0)
        {
            OnExitGround.Invoke();
        }
    }

}
