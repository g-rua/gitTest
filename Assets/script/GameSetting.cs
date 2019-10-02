using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    static int playerCount=0;
    [SerializeField] GameObject[] playerCountButton;
    [SerializeField] Image buttonImage;
    [SerializeField] Image[] setImage;
    [SerializeField] GameObject playCountSetting;
    [SerializeField] GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SoloPlay()
    {
        //操作人数を1人にして遊ぶ回数の設定へ
        playerCount = 1;
        PlayCountSetting(0,2);
        setImage[0].sprite = buttonImage.sprite;
        setImage[0].color = Color.white;
    }

    public void DuoPlay()
    {
        //操作人数を2人にして遊ぶ回数の設定へ
        playerCount = 2;
        PlayCountSetting(0,2);
        setImage[0].sprite = buttonImage.sprite;
        setImage[0].color = Color.white;
    }

    public void ThreePlay()
    {
        //遊ぶ回数を3回に設定し、ゲーム選択へ
        GameControll.SetCount(3);
        PlayCountSetting(2, playerCountButton.Length);
        ActiveFader("gamecelecter", Color.white);

    }
    public void FivePlay()
    {
        //遊ぶ回数を５回に設定し、ゲーム選択へ
        GameControll.SetCount(5);
        PlayCountSetting(2, playerCountButton.Length);
        ActiveFader("gamecelecter", Color.white);


    }
    public void FreePlay()
    {
        //遊ぶ回数を自由に選べるようにする（あとで）
        GameControll.SetCount(3);
        PlayCountSetting(2, playerCountButton.Length);
        ActiveFader("gamecelecter", Color.white);

    }

    private void ActiveFader(string name,Color color)
    {
        //フェードイン、アウトの実行
        GetComponent<FadeController>().FadeOut(name,color);

    }

    private void PlayCountSetting(int minCount,int maxCount)
    {
        //指定したボタンを消す
        for(int i=minCount;i<maxCount;i++)
        {
            playerCountButton[i].SetActive(false);
        }
        //遊ぶ回数を選ぶボタンを呼ぶ
        playCountSetting.SetActive(true);
    }
}
