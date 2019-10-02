using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    static int playerCount=0;
    public int playerIndex;
    public int settingIndex;
    [SerializeField] GameObject[] playerCountButton;
    [SerializeField] GameObject[] playerCountButtonObj;
    [SerializeField] GameObject playerCountImages;
    [SerializeField] Image buttonImage;
    [SerializeField] Image[] setImage;
    [SerializeField] Sprite playCountImage;
    [SerializeField] GameObject playCountSetting;
    [SerializeField] GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (settingIndex)
        {
            case 0:
                PlayerCountSetting();
                break;
        }

    }

    private void PlayerCountSetting()
    {
        playerIndex = Mathf.Clamp(playerIndex, 0, 4);
        if(Input.GetKeyDown(KeyCode.Return))
        {
            settingIndex++;
            playerCount = playerIndex;
            PlayCountSetting(0, 2);
            ChangeSprite();
        }
        if(playerIndex>3)
        {
            playerIndex = 0;
        }
        if(playerIndex<0)
        {
            playerIndex = 3;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerIndex++;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerIndex--;
        }
        ActivePlayerCountImage(playerIndex);
    }

    private void ActivePlayerCountImage(int index)
    {
        for(int i=0;i<playerCountImages.transform.childCount;i++)
        {
            bool flag = false;
            if(i==index)
            {
                flag = true;
            }
            playerCountImages.transform.GetChild(i).gameObject.SetActive(flag);
        }
    }

    public void SoloPlay()
    {
        //操作人数を1人にして遊ぶ回数の設定へ
        playerCount = 1;
        PlayCountSetting(0,2);
        //画像を変える用のオブジェクトを消す
        ChangeSprite();
    }

    public void DuoPlay()
    {
        //操作人数を2人にして遊ぶ回数の設定へ
        playerCount = 2;
        PlayCountSetting(0,2);
        ChangeSprite();
    }

    public void ThreePlay()
    {
        //遊ぶ回数を3回に設定し、ゲーム選択へ
        GameControll.SetCount(3);
        PlayCountSetting(2, playerCountButton.Length);
        ActiveFader("gamecelecter");

    }
    public void FivePlay()
    {
        //遊ぶ回数を５回に設定し、ゲーム選択へ
        GameControll.SetCount(5);
        PlayCountSetting(2, playerCountButton.Length);
        ActiveFader("gamecelecter");


    }
    public void FreePlay()
    {
        //遊ぶ回数を自由に選べるようにする（あとで）
        GameControll.SetCount(3);
        PlayCountSetting(2, playerCountButton.Length);
        ActiveFader("gamecelecter");

    }

    private void ActiveFader(string name)
    {
        //フェードイン、アウトの実行
        GetComponent<FadeController>().FadeOut(name);

    }

    private void ChangeSprite()
    {
        for (int i = 0; i < playerCountButtonObj.Length; i++)
        {
            Destroy(playerCountButtonObj[i]);
        }
        //画像を差し替える
        setImage[0].sprite = buttonImage.sprite;
        setImage[0].color = Color.white;
        buttonImage.sprite = playCountImage;
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
