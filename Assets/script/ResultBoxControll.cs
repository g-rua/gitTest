using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBoxControll : MonoBehaviour
{
    [SerializeField] GameObject body;
    [SerializeField] GameObject cover;
    [SerializeField] ParticleSystem ps;
    [SerializeField] GameObject bom;
    [SerializeField] GameObject flower;
    public GameObject item;
    [SerializeField] Transform itemPopPos;
    [SerializeField] ResultBoxCover coverScript;
    private bool resultItemPop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKeyDown(KeyCode.Return))
       // {
       //     BoxOpen();
       // }


    }

    public void BoxOpen()
    {
        coverScript.enabled = true;
        ps.Play();

        if (coverScript.open)
        {
            if (!resultItemPop)
            {
                //item = bom;
                GameObject.Instantiate(item, itemPopPos.position, item.transform.rotation);
                resultItemPop = true;
            }
        }
    }
}
