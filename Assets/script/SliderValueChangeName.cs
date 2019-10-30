using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderValueChangeName : MonoBehaviour
{
    [SerializeField] Slider slider;
    private Text text;
    public int val;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ボタン内のテキストを変えるためにスライダーの数値を取得
        val = (int)slider.value;
        ChangeText(val);
    }

    public void ChangeText(int value)
    {
        //スライダーの数値に応じてテキストを変える
        switch (value)
        {
            case 0:
                text.text = "carryItem";
                break;
            case 1:
                text.text = "ChangeColorTile";
                break;
            case 2:
                text.text = "PanelChnageAction";
                break;
            case 3:
                text.text = "RaseTest";
                break;
            case 4:
                text.text = "EffectTest";
                break;
            case 5:
                text.text = "MazeTest";
                break;
            case 6:
                text.text = "RandomDoors";
                break;
            case 7:
                text.text = "ダルマ落とし";
                break;
            case 8:
                text.text = "ぶっとばし";
                break;
            case 9:
                text.text = "大砲";
                break;
            case 10:
                text.text = "運試しブロック";
                break;
            case 11:
                text.text = "ベルトコンベア";
                break;
            case 12:
                text.text = "福引";
                break;
            case 13:
                text.text = "ブラックジャック";
                break;
            case 14:
                text.text = "タイミングゲーム";
                break;
            case 15:
                text.text = "落ちてくるのを回収";
                break;
            case 16:
                text.text = "持ってる間にげろ";
                break;
            case 17:
                text.text = "謎";
                break;
            default:
                text.text = "????????";
                break;



        }

    }
}
