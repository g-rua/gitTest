using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CelectDebugMode : MonoBehaviour
{
    //自機たち
    [SerializeField] GameObject[] characters;
    //飛びたいデバッグゲームフィールド
    [SerializeField] GameObject[] debugField;
    //メインカメラ
    [SerializeField] GameObject cam;
    //prefabにあるポーズキャンバス
    [SerializeField] GameObject pauseInstance;
    //キャンバスをいれるオブジェ
    [SerializeField] GameObject pausePanel;
   
    [SerializeField] Slider slider;
    [SerializeField] Button button;
    public bool pouse;
    public int debugGameIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExcutePause();
        CelectDebugGame();
    }

    public void CelectDebugGame()
    {
        if (!pouse) return;
        //スライダーの値で行先が決まるため代入
        debugGameIndex = (int)slider.value;
        Debug.Log("k");
        for (int i = 0; i < characters.Length; i++)
        {
            //それぞれの位置に対応した場所に飛ばす
            characters[i].transform.position = debugField[debugGameIndex].transform.GetChild(i).position;
        }
        //カメラも同様
        cam.transform.position = debugField[debugGameIndex].transform.GetChild(2).position;
        cam.transform.rotation = debugField[debugGameIndex].transform.GetChild(2).rotation;
        ////ゲーム時間をもとに戻す
        //Time.timeScale = 1;
        //pouse = false;
        ////キャンバスの破棄
        //Destroy(pausePanel);



    }



    private void ExcutePause()
    {
        //エスケープキーでメニューを開く
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pouse)
            {
                //ポーズ中は止めってほしいからゲーム時間を止める
                Time.timeScale = 0;
                pouse = true;
                //キャンバスを作る
                if (pausePanel == null)
                {
                    //prefabからインスタンス
                    pausePanel = GameObject.Instantiate(pauseInstance) as GameObject;
                    //スライダーの値を見るため取得
                    slider = pausePanel.transform.Find("Slider").GetComponent<Slider>();
                    //ボタンを押したときの処理を追加するために取得
                    button = pausePanel.transform.Find("startButton").GetComponent<Button>();
                    //ボタンを押したときの処理を入れる
                    //button.onClick.AddListener(()=>
                    //{
                    //    CelectDebugGame();
                    //});
                }
            }
            else
            {
                //ポーズを解くのでゲーム時間をもとに戻す
                Time.timeScale = 1;
                pouse = false;
                //キャンバスの破棄
                Destroy(pausePanel);
            }
            Debug.Log(pouse);
        }
    }
}
