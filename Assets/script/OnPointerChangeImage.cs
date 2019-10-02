using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPointerChangeImage : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Sprite changeImage;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(img.sprite);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        img.sprite = changeImage;
    }
}
