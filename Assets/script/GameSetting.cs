using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    static int playerCount=0;
    //プレイヤー人数用のインデックス
    public int playerIndex;
    public int lastPlayerIndex;
    //今どこの設定をしているかのインデックス
    public int settingIndex;
    //どう遊ぶかを決めるインデックス
    public int gameStyleIndex;
    //何回遊ぶかを決めるインデックス
    public int gamePlaySettingIndex;
    //今どの画像を描画させるかのインデックス
    public int drawSettingImageIndex;

    public float rot;
    public int stopTime;
    private Color initImageColor;
    private Color initTextColor;
    private float addAlpha = 0.03f;
    [SerializeField] Transform[] humanPoppers;
    [SerializeField] Transform[] humanDest;
    [SerializeField] Transform cameraInitPos;
    [SerializeField] Transform cameraNextPos;
    [SerializeField] GameObject[] fallFloor;
    [SerializeField] Transform playerCountImages;
    [SerializeField] GameObject fader;
    [SerializeField] Text settingText;
    [SerializeField] Text[] checkTexts;

    [SerializeField] Transform settingImages;
    [SerializeField] RectTransform blinkPanel;
    [SerializeField] NumberPop numberPop;
    [SerializeField] Image initDrawImage;
    [SerializeField] Text initDrawText;
    [SerializeField] TitleImageControll[] tic;
    [SerializeField] Transform[] blinkpos;
    [SerializeField] Sprite[] playerCountSprits;
    [SerializeField] Sprite[] gameStyleSprits;
    [SerializeField] Transform checkImageParent;
    [SerializeField] Transform checkCountParent;
    [SerializeField] Transform checkStyleParent;
    [SerializeField] Transform checkGameCountParent;
    [SerializeField] GameObject sonota;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraInitPos.position;
        initImageColor = new Color(255, 255,255, 0);
        initTextColor = new Color(0, 0,0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTime-- < 0)
        {
            foreach(var a in tic)
            { 
                a.enabled = true;
            }
            initImageColor.a += addAlpha;
            initTextColor.a += addAlpha;
            initDrawImage.color = initImageColor;
            initDrawText.color = initTextColor;
            Vector3 vec = cameraNextPos.position - transform.position;
            if (vec.magnitude <= 0f)
            {
                vec = Vector3.zero;
                transform.position = cameraNextPos.position;
                transform.rotation = cameraNextPos.rotation;

            }
            else
            {

                transform.position += (vec * 2) * Time.deltaTime;
                if (transform.rotation.x <= cameraNextPos.rotation.x)
                {
                    rot = 0f;
                    transform.rotation = cameraNextPos.rotation;
                }
                transform.Rotate(Vector3.right, rot);
            }
        }
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
            playerCount = playerIndex+1;
            checkTexts[0].text = playerCount.ToString();
            for (int i = 0; i <= playerIndex; i++)
            {
                humanPoppers[i].GetComponent<SettingHumanPop>().HumanPop(humanDest[i]);
            }
            if(lastPlayerIndex>playerIndex)
            {
                for(int i=playerIndex+1;i<=lastPlayerIndex;i++)
                {
                    fallFloor[i].GetComponent<FallFloorMove>().BoShoot();
                }
            }
            else
            {
                for (int i = playerIndex; i <= lastPlayerIndex; i++)
                {
                    humanPoppers[i].GetComponent<SettingHumanPop>().HumanPop(humanDest[i]);
                }
            }
            //次の段階へ行くためにインクリメント
            settingIndex++;
        }
        LimitIndex(ref playerIndex, 0, 1);


        ActiveImage(playerIndex,ref playerCountImages);
        //Debug.Log("playerCountSetting");
    }

    private void GameStyleSetting()
    {
       
        //ランダムで遊ぶか、自分で選んで遊ぶかを選ぶ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //if(gameStyleIndex==0)
            //{
                settingIndex++;
                //checkTexts[1].text = "ランダム";
                numberPop.gameObject.SetActive(true);
            //}
            //if (gameStyleIndex==1)
            //{
            //    settingIndex += 2;
            //    checkTexts[1].text = "自分で選択";
            //    checkTexts[2].text = "自由";

            //    DrawCheckText();
            //    checkImageParent.gameObject.SetActive(true);

            //}
            for (int i = 0; i <= playerIndex; i++)
            {
                humanPoppers[i].GetComponent<SettingHumanPop>().HumanPop(humanDest[i]);
            }

        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            for (int i = 0; i <= playerIndex; i++)
            {
                fallFloor[i].GetComponent<FallFloorMove>().BoShoot();
            }
            lastPlayerIndex = playerIndex;


            settingIndex--;
        }
        //直前のインデクスの取り出し
        int lastIndex = gameStyleIndex;       
        LimitIndex(ref gameStyleIndex, 0, 1);
        //直前のインデクスと今のインデクスが違ったら透明度を１にしてから再点滅させる
        if (gameStyleIndex !=lastIndex)
        {
           blinkPanel.GetComponent<ImageBlink>().alpha = 1f;
        }
        blinkPanel.position = blinkpos[gameStyleIndex].position;
        //if (gameStyleIndex==0)
        //{ 
        //    blinkPanel.position = new Vector3(136f, 176.5f, 0f);
 
        //}
        //if(gameStyleIndex==1)
        //{
        //    blinkPanel.position = new Vector3(415f, 176.5f, 0f);
        //}

        //Debug.Log("GameStyleSetting");

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
            numberPop.gameObject.SetActive(false);
            sonota.SetActive(true);
            checkImageParent.gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            gamePlaySettingIndex = 0;
            numberPop.gameObject.SetActive(false);


            settingIndex--;
        }
        LimitIndex(ref gamePlaySettingIndex, 0, 5);
        numberPop.NumPop(gamePlaySettingIndex, new Vector3(6.7f, 8, -44), false);
        //Debug.Log("PlayCountSetting");
    }

    private void CheckGameSetting()
    {
        //この設定でよいかを確認する場面
        //Debug.Log("CheckGameSetting");
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameResultControll.gameStyle = gameStyleIndex;
            if (gameStyleIndex == 0)
            {
                ActiveFader("gameCelecter");
            }

            if(gameStyleIndex==1)
            {
                ActiveFader("gameCelecter");
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            settingImages.gameObject.SetActive(true);
            numberPop.gameObject.SetActive(true);

            //if (gameStyleIndex == 0)
            //{
            settingIndex--;
            //}
            //if (gameStyleIndex == 1)
            //{
            //    settingIndex -= 2;
            //}
            sonota.SetActive(false);
            checkImageParent.gameObject.SetActive(false);
        }
        ActiveImage(playerIndex, ref checkCountParent);
        ActiveImage(gameStyleIndex, ref checkStyleParent);
        ActiveImage(gamePlaySettingIndex, ref checkGameCountParent);
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



}
