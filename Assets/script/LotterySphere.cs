using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotterySphere : MonoBehaviour
{
    public int a;
    private int lotteryIndex;
    private Color sphereCol;
    // Start is called before the first frame update
    void Start()
    {
        LotteryRandomIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LotteryRandomIndex()
    {
        //福引ででる玉の色を変える
        lotteryIndex = Random.Range(0, 6);
        LotteryIndexChangeColor(lotteryIndex);
    }

    private void LotteryIndexChangeColor(int index)
    {
        Color col=default(Color);
        string colorCode;
        switch (index)
        {
            case 0:
                col = Color.yellow;
                break;
            case 1:
                colorCode = "#FFA500";
                ColorUtility.TryParseHtmlString(colorCode, out col);
                break;
            case 2:
                colorCode = "#FF9BB9";
                ColorUtility.TryParseHtmlString(colorCode, out col);
                break;
            case 3:
                colorCode = "#DA70D6";
                ColorUtility.TryParseHtmlString(colorCode, out col);
                break;
            case 4:
                colorCode = "#00FFFF";
                ColorUtility.TryParseHtmlString(colorCode, out col);
                break;
            case 5:
                colorCode = "#00FF00";
                ColorUtility.TryParseHtmlString(colorCode, out col);
                break;
            case 6:
                col = Color.white;
                break;
            default:
                col = Color.white;
                break;
        }
        
        GetComponent<MeshRenderer>().materials[0].color = col;
       
    }

private void ColorChange(float r,float g,float b,ref Color col)
{
    col.r = r;
    col.g = g;
    col.b = b;
}

}



