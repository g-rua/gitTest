using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCtrl : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites=new Sprite[10];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeSprite(int no)
    {
        if (no > 9 || no < 0) no = 0;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //実際に描画する画像を配列から取り出しいれる
        spriteRenderer.sprite = sprites[no];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
