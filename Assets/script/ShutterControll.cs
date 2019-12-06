using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterControll : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject save;
    static GameObject[] award;
    private Vector3 vel;
    public Vector3 initPos;
    public Vector3 endPos;
    public bool moveFlag;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShutterClose()
    {

            initPos = new Vector3(0, 960, 0);
            vel = new Vector3(0, -10, 0);

            endPos = new Vector3(0,0, 0);
        if (transform.position.y <= endPos.y)
        {
            vel = Vector3.zero;
            ScoreSort();
            GetComponent<sceneMove>().NoFadeChange();
        }
        transform.position += vel;

    }

    public void ShutterOpen()
    {
        if (Mathf.Abs(transform.position.y) >= endPos.y)
        {


            vel = Vector3.zero;
        }
        initPos = Vector3.zero;
        vel = new Vector3(0, 10, 0);
        //transform.position = initPos;
        endPos = new Vector3(0, 960, 0);
        transform.position += vel;
        Debug.Log(award[0]);

    }

    private void ScoreSort()
    {

            award = players;
        
        for (int i = 0; i < award.Length; i++)
        {
            if (i + 1 < award.Length)
            {
                if (award[i].GetComponent<GameScoreManage>().gamePoint <
                    award[i + 1].GetComponent<GameScoreManage>().gamePoint)
                {
                    save = award[i];
                    award[i] = award[i + 1];
                    award[i + 1] = save;
                    i = -1;
                }
            }
        }
        Debug.Log(award[0]);
        //for (int i = 0; i < st.Length; i++)
        //{
        //    if (i + 1 < st.Length)
        //    {
        //        if (st[i] <
        //            st[i + 1])
        //        {
        //            s = st[i];
        //            st[i] = st[i + 1];
        //            st[i + 1] = s;
        //            i = -1;
        //        }

        //    }
        //}
    }
}

