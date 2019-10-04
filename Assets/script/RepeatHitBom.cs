using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatHitBom : MonoBehaviour
{
    [SerializeField] GameObject exp;
    [SerializeField] GameObject expInstance;
    public int maxTapCount;
    public int tapCount;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            tapCount++;
        transform.localScale += new Vector3(scale ,scale ,scale);
        }
        if(tapCount>maxTapCount)
        {
            exp = GameObject.Instantiate(expInstance, transform.position, Quaternion.identity);
            exp.transform.localScale = transform.localScale;
            Destroy(this.gameObject);
        }
        GetComponent<RepeatHitBomColor>().TapCountChangeAlpha(tapCount, maxTapCount);
    }
}
