using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddNumberSprit : MonoBehaviour
{
    [SerializeField] Sprite[] numSprite;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = numSprite[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
