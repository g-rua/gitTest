using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBlockJudge : MonoBehaviour
{
    [SerializeField] GameObject shutter;
    [SerializeField] CharaCon[] characterControll;
    [SerializeField] NumberPop gameCount;
    [SerializeField] NumberPop team1Count;
    [SerializeField] NumberPop team2Count;
    [SerializeField] GameObject[] goals;
    [SerializeField] int[] counts;
    public int teamCount;
    public int gameTime;
    public int drawTime;
    public bool gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime++;
        if(gameTime>60)
        {
            gameTime = 0;
            drawTime--;
        }
        if(drawTime<0)
        {
            gameEnd = true;
        }
        if(gameEnd)
        {
            foreach(var chara in characterControll)
            {
                chara.enabled = false;
            }
            shutter.GetComponent<ShutterControll>().ShutterClose();
        }
        gameCount.NumPop(drawTime, new Vector3(0.96f, 8.6f, -1.2f), false);
        gameCount.gameObject.transform.rotation = Quaternion.Euler(45f,0,0);
        for(int i=0;i<teamCount;i++)
        {
            counts[i] = goals[i].GetComponent<OnBlockCounter>().GetCount();
        }
    }
}
