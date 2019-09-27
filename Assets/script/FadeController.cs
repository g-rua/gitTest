using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeController : MonoBehaviour
{
    //[SerializeField] Image img;
    //[SerializeField] Canvas canvas;
    //[SerializeField] Slider slider;
    [SerializeField] GameObject fadeCanvasprefab;
    private GameObject fadeCanvas;
    private Image fadeinImage;
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
        FadeIn();
        myColor = Color.white;
        myColor.a = 0;

    }



    public void FadeIn()
    {
        isFadeIn = true;
        fadeCanvas = GameObject.Instantiate(fadeCanvasprefab) as GameObject;
        fadeinImage = fadeCanvas.transform.GetChild(0).GetComponent<Image>();
        alpha = 1f;
        fadeinImage.material.SetFloat("_Slider", alpha);
    }

    public void FadeOut(string name,Color fadeColor)
    {
        myColor = fadeColor;
        isFadeOut = true;
        alpha = 0f;
        fadeCanvas = GameObject.Instantiate(fadeCanvasprefab) as GameObject;
        fadeinImage = fadeCanvas.transform.GetChild(0).GetComponent<Image>();
        fadeinImage.material.SetFloat("_Slider", alpha);
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
                Destroy(fadeCanvas);
            }
            fadeinImage.material.SetFloat("_Slider", alpha);
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
            fadeinImage.material.SetFloat("_Slider", alpha);
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

