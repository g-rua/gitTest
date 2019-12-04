using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingHumanPop : MonoBehaviour
{
    [SerializeField] GameObject popHuman;
    public GameObject human;
    public int popCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HumanPop(Transform dest)
    {

        if (human==null)
        {
            human=Instantiate(popHuman, transform.position, transform.rotation)as GameObject;
            human.GetComponent<TitleCharaMove>().destination = dest;
        }
        popCount++;
    }


}
