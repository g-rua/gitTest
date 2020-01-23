using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HamonColorCOntroll : MonoBehaviour
{
    [SerializeField] Image parentimg;
    private Color col;
    // Start is called before the first frame update
    void Start()
    {
        //col = GetComponent<Image>().material.sha;
    }

    // Update is called once per frame
    void Update()
    {
        //col.a = parentimg.color.a;
        //GetComponent<Image>().material.color = col;
    }
}
