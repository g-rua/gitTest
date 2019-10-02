using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeController : MonoBehaviour
{
    //フェードに使うテクスチャの配列
    [SerializeField] Texture[] mainTextures;
    //フェードの仕方を変えるルール画像の配列
    [SerializeField] Texture[] ruleTextures;
    //キャンバスのprefab
    [SerializeField] GameObject fadeCanvasprefab;
    //prefabからインスタンスしたものの入れ物
    private GameObject fadeCanvas;
    private Image fadeinImage;
    private Color myColor;
    private string nextScene;
    private float alpha;
    private float maxAlpha;
    public float addAlpha;
    public bool isFade;
    public bool isFadeIn;
    public bool isFadeOut;

    void Start()
    {
        maxAlpha = 1f;
        FadeIn();
        myColor = Color.white;
        myColor.a = 0;

    }



    public void FadeIn()
    {
        isFadeIn = true;
        //フェード用のキャンバスをインスタンスする
        fadeCanvas = GameObject.Instantiate(fadeCanvasprefab) as GameObject;
        //フェード用のテクスチャをランダムにするために取得
        fadeinImage = fadeCanvas.transform.GetChild(0).GetComponent<Image>();
        //メインのテクスチャを配列から選ぶ
        fadeinImage.material.mainTexture = mainTextures[SetTextureIndex(mainTextures.Length)];
        //消え方のルール画像を配列から選ぶ
        fadeinImage.material.SetTexture("_RuleTex", ruleTextures[SetTextureIndex(ruleTextures.Length)]);
        //スタート時点の透明度を設定
        alpha = 1f;
        //透明度を設定
        fadeinImage.material.SetFloat("_Slider", alpha);
    }

    public void FadeOut(string name)
    {
        isFadeOut = true;
        alpha = 0f;
        //フェード用のキャンバスをインスタンス
        fadeCanvas = GameObject.Instantiate(fadeCanvasprefab) as GameObject;
        //フェード用のテクスチャをランダムにするために取得
        fadeinImage = fadeCanvas.transform.GetChild(0).GetComponent<Image>();
        //メインのテクスチャを配列から選ぶ
        fadeinImage.material.mainTexture = mainTextures[SetTextureIndex(mainTextures.Length)];
        //ルール画像を配列から選ぶ
        fadeinImage.material.SetTexture("_RuleTex", ruleTextures[SetTextureIndex(ruleTextures.Length)]);
        //初期透明度を設定
        fadeinImage.material.SetFloat("_Slider", alpha);
        //次のシーンの名前を入れる
        nextScene = name;

    }

    void Update()
    {
        if(isFadeIn)
        {
            //フェードイン中はゲーム時間を止める
            Time.timeScale = 0f;
        }
        alpha = Mathf.Clamp(alpha, 0f, maxAlpha);
        if (isFadeIn)
        {
            //透明度を下げていく
            alpha -= addAlpha;
            if (alpha <= 0f)
            {
                //キャンバスを破棄し、見えるようにする
                isFadeIn = false;
                //終わったらゲーム時間をもとに戻す
                Time.timeScale = 1f;
                Destroy(fadeCanvas);
            }
            //透明度を変えていく
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

    private int SetTextureIndex(int length)
    {
        //ランダムに数値を返す
        int texIndex;
        texIndex = Random.Range(0, length);

        return texIndex;
    }
}

