using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageBlink : MonoBehaviour
{
    [SerializeField] Image blinkImage;
    private Color blinkColor;
    public float alpha;
    public float addAlpha;
    // Start is called before the first frame update
    void Start()
    {
        blinkColor = blinkImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        blinkImage.color = blinkColor;
        blinkColor.a = alpha;
        alpha += addAlpha;
        if(alpha>1f||alpha<0f)
        {
            addAlpha *= -1;
        }
    }
}
