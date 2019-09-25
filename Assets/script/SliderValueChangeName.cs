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
        val = (int)slider.value;
        ChangeText(val);
    }

    public void ChangeText(int value)
    {
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
            default:
                text.text = "????????";
                break;



        }

    }
}
