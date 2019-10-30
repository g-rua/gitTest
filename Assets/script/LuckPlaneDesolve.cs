﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckPlaneDesolve : MonoBehaviour
{
    [SerializeField] BoxCollider boxCol;
    private Material myMaterial;
    public float alpha;
    public float maxAlpha;
    public float addAlpha;
    public bool desolveFlag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            desolveFlag = true;
        }

        if (desolveFlag)
        {
            myMaterial = GetComponent<MeshRenderer>().materials[0];
            alpha = Mathf.Clamp(alpha, 0, maxAlpha);
            alpha += addAlpha;
            myMaterial.SetFloat("_Slider", alpha);
            if (myMaterial.GetFloat("_Slider") <= 0.7f)
            {
                Destroy(boxCol);
            }
            GetComponent<MeshRenderer>().materials[0] = myMaterial;
            if (myMaterial.GetFloat("_Slider") <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
