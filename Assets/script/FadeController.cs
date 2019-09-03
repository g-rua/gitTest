using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeController : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Canvas canvas;
    private Color myColor;
    private string nextScene;
    public float alpha;
    public float maxAlpha;
    public float addAlpha;
    public bool isFade;
    public bool isFadeIn;
    public bool isFadeOut;

    void Start()
    {
        myColor = Color.black;
    }



    public void FadeIn()
    {
        isFadeIn = true;
        alpha = 1f;
    }

    public void FadeOut(string name,Color fadeColor)
    {
        myColor = fadeColor;
        isFadeOut = true;
        alpha = 0f;
        nextScene = name;
    }

    void Update()
    {
        alpha = Mathf.Clamp(alpha, 0f, maxAlpha);
        if (isFadeIn)
        {
            //透明度を下げていく
            alpha -= addAlpha;
            if (alpha <= 0f)
            {
                //キャンバスを破棄し、見えるようにする
                isFadeIn = false;
                canvas.enabled = false;
            }
            myColor.a = alpha;
            img.color = myColor;
        }
        else if (isFadeOut)
        {
            //透明度を加算し、消えていく
            alpha += addAlpha;
            if (alpha >= maxAlpha)
            {
                //消えきったら指定のシーンへ行く
                isFadeOut = false;
                SceneManager.LoadScene(nextScene);
            }
            myColor.a = alpha;
            img.color = myColor;
        }
    }

    public bool IsFadeOut()
    {
        return isFadeOut;
    }

    public bool IsFadein()
    {
        return isFadeIn;
    }
}

