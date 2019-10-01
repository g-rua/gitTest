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
                text.text = "ぶっ飛ばし";
                break;
            default:
                text.text = "????????";
                break;



        }

    }
}
