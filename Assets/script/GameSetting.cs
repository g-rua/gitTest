using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    static int playerCount=0;
    //プレイヤー人数用のインデックス
    public int playerIndex;
    //今どこの設定をしているかのインデックス
    public int settingIndex;
    //どう遊ぶかを決めるインデックス
    public int gameStyleIndex;
    //何回遊ぶかを決めるインデックス
    public int gamePlaySettingIndex;
    //今どの画像を描画させるかのインデックス
    public int drawSettingImageIndex;
    //-----------------------------------
    [SerializeField] GameObject[] playerCountButton;
    [SerializeField] GameObject[] playerCountButtonObj;

    [SerializeField] Image buttonImage;
    [SerializeField] Image[] setImage;
    [SerializeField] Sprite playCountImage;
    [SerializeField] GameObject playCountSetting;
    //-------------------------------------

    [SerializeField] Transform playerCountImages;
    [SerializeField] GameObject fader;
    [SerializeField] Text settingText;
    [SerializeField] Text[] checkTexts;
    [SerializeField] Transform checkTextParent;
    [SerializeField] Transform settingImages;
    [SerializeField] RectTransform blinkPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //今何段階目かのインデクスによって分岐
        switch (settingIndex)
        {
            case 0:
                settingText.text = "何人で遊ぶか";
                drawSettingImageIndex = 0;
                PlayerCountSetting();
                break;
            case 1:
                settingText.text = "どうやって遊ぶか";
                drawSettingImageIndex = 1;
                GameStyleSetting();
                break;
            case 2:
                settingText.text = "何回遊ぶか";
                drawSettingImageIndex = 2;
                GameCountSetting();
                break;
            case 3:
                settingText.text = "これで問題ないか";
                settingImages.gameObject.SetActive(false);
                CheckGameSetting();
                break;

        }
        ActiveImage(drawSettingImageIndex, ref settingImages);
    }

    private void PlayerCountSetting()
    {
        //何人で遊ぶかを選択
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //人数の決定
            playerCount = playerIndex;
            checkTexts[0].text = playerCount.ToString();

            //次の段階へ行くためにインクリメント
            settingIndex++;
        }
        LimitIndex(ref playerIndex, 0, 3);


        ActiveImage(playerIndex,ref playerCountImages);
        Debug.Log("playerCountSetting");
    }

    private void GameStyleSetting()
    {
       
        //ランダムで遊ぶか、自分で選んで遊ぶかを選ぶ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(gameStyleIndex==0)
            {
                settingIndex++;
                checkTexts[1].text = "ランダム";
            }
            if(gameStyleIndex==1)
            {
                settingIndex += 2;
                checkTexts[1].text = "自分で選択";
                checkTexts[2].text = "自由";
                DrawCheckText();
            }
            
        }
        //直前のインデクスの取り出し
        int lastIndex = gameStyleIndex;       
        LimitIndex(ref gameStyleIndex, 0, 1);
        //直前のインデクスと今のインデクスが違ったら透明度を１にしてから再点滅させる
        if (gameStyleIndex !=lastIndex)
        {
           blinkPanel.GetComponent<ImageBlink>().alpha = 1f;
        }
        if (gameStyleIndex==0)
        { 
            blinkPanel.position = new Vector3(136f, 176.5f, 0f);
 
        }
        if(gameStyleIndex==1)
        {
            blinkPanel.position = new Vector3(415f, 176.5f, 0f);
        }

        Debug.Log("GameStyleSetting");

    }

    private void GameCountSetting()
    {
        //何回遊ぶかを選ぶ
        if (Input.GetKeyDown(KeyCode.Return))
        {

            SwitchForGamePlaySettingIndex(gamePlaySettingIndex);
            checkTexts[2].text = gamePlaySettingIndex.ToString();
            //PlayCountSetting(2, playerCountButton.Length);
            //ChangeSprite();
            settingIndex++;
            DrawCheckText();
        }
        LimitIndex(ref gamePlaySettingIndex, 0, 5);

        Debug.Log("PlayCountSetting");
    }

    private void CheckGameSetting()
    {
        //この設定でよいかを確認する場面
        Debug.Log("CheckGameSetting");
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (gameStyleIndex == 0)
            {
                ActiveFader("RandomGameCelecter");
            }

            if(gameStyleIndex==1)
            {
                ActiveFader("gamecelecter");
            }
        }
    }

    private void LimitIndex(ref int index,int min,int max)
    {
        //左右を押されたときに数値を加減
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index--;
        }
        //それぞれの最大最小を超えたら入れ替える
        if(index>max)
        {
            index = min;
        }
        if(index<min)
        {
            index = max;
        }
    }

    private void SwitchForGamePlaySettingIndex(int index)
    {
        switch(index)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }

            
    }

    private void DrawCheckText()
    {
        for(int i=0;i<checkTextParent.childCount;i++)
        {
            checkTextParent.GetChild(i).GetComponent<Text>().color =new Color(0,0,0,255);
        }
    }


    private void ActiveImage(int index,ref Transform obj)
    {
        //選んでいるインデクスによって表示する絵を変更
        for(int i=0;i<obj.childCount;i++)
        {
            bool flag = false;
            if(i==index)
            {
                flag = true;
            }
            //今選んでいるもの以外は表示しない
            obj.GetChild(i).gameObject.SetActive(flag);
        }
    }


    private void ActiveFader(string name)
    {
        //フェードイン、アウトの実行
        GetComponent<FadeController>().FadeOut(name);

    }

    //private void ChangeSprite()
    //{
    //    for (int i = 0; i < playerCountButtonObj.Length; i++)
    //    {
    //        Destroy(playerCountButtonObj[i]);
    //    }
    //    //画像を差し替える
    //    setImage[settingIndex].sprite = buttonImage.sprite;
    //    setImage[settingIndex].color = Color.white;
    //    buttonImage.sprite = playCountImage;
    //}


}
