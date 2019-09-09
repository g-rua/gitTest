using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorChange : MonoBehaviour
{
    private Color blockColor;
    public int teamIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        blockColor = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    public void ChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void SetTeamIndex(int index)
    {
        teamIndex = index;
    }

}
