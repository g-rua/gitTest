using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotterySphere : MonoBehaviour
{
    private int lotteryIndex;
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
        lotteryIndex = Random.Range(0, 4);
        LotteryIndexChangeColor(lotteryIndex);
    }

    private void LotteryIndexChangeColor(int index)
    {
        Color col;
        switch (index)
        {
            case 0:
                col = Color.yellow;
                break;
            case 1:
                col = Color.red;
                break;
            case 2:
                col = Color.blue;
                break;
            case 3:
                col = Color.white;
                break;
            default:
                col = Color.white;
                break;
        }
        GetComponent<MeshRenderer>().materials[0].color = col;

    }

}
