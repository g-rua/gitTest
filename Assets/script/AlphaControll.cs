using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlphaControll : MonoBehaviour
{
    public Image/*[]*/ img;
    public Color/*[]*/ col;
    public bool initErase;
    public bool eraseFlag;
    public bool AppearFlag;
    // Start is called before the first frame update
    void Start()
    {
        //col = new Color[img.Length];
        //for(int i=0;i<col.Length;i++)
        //{
            col/*[i] */= img/*[i]*/.color;
        //}
        if (initErase)
        {
            //for (int i = 0; i < img.Length; i++)
            //{
                img/*[i]*/.color = new Color(0, 0, 0, 0);
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(eraseFlag)
        {
            Loop(0,/* col.Length,*/ 0, -0.06f,true,ref eraseFlag);
            //for(int i=0;i<col.Length;i++)
            //{
            //    if (img[i].color.a >= 0f)
            //    {
            //        col[i].a += -0.03f;
            //        img[i].color = col[i];
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}
            //eraseFlag = false;
        }
        if(AppearFlag)
        {
            Loop(0, /*col.Length,*/ 1, 0.03f, false, ref AppearFlag);

        }
    }

    private void Loop(int initval,/*int length,*/float maxalpha,float addalpha,bool erace,ref bool flag)
    {
        
        //for (int i = initval; i < length; i++)
        //{
            if (erace)
            {
                if (img/*[i]*/.color.a >= maxalpha)
                {
                    col/*[i]*/.a += addalpha;
                    img/*[i]*/.color = col/*[i]*/;
                }
                else
                {
                flag = false;

            }
        }
            else
            {
                if (img/*[i]*/.color.a <= maxalpha)
                {
                    col/*[i]*/.a += addalpha;
                    img/*[i]*/.color = col/*[i]*/;
                }
                else
                {
                flag = false;
            }
            }
        //}

    }

    public void Erase()
    {
        eraseFlag = true;
    }

    public void Appear()
    {
        AppearFlag = true;


    }

}
