using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class NumberPop : MonoBehaviour
{
    public string objname;
    //数値を出現させる場所
    private Vector3 init_pos;
    //表示させる数値
    private int point;
    //画像の大きさ
    private float size = 1f;
    //ソート方法
    private static int dam_sort = 0;
    //試行回数の最大
    private const int SORT_MAX = 30000;
    public bool testDraw;
    // Start is called before the first frame update
    void Start()
    {
        if(testDraw)
        {
            NumPop(60, transform.position, false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    //
    public void NumPop(int fpoint,Vector3 pos,bool multipleDrawFlag)
    {
        if (!multipleDrawFlag)
        {
            if (transform.childCount != 0)
            {
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
        Init(fpoint, pos);
    }

    public void Init(int fpoint,Vector3 pos)
    {
        point = fpoint;
        CreateNum(fpoint);
        init_pos = pos;
        GetComponent<SortingGroup>().sortingOrder = dam_sort;
        dam_sort++;
        if(dam_sort>SORT_MAX)
        {
            dam_sort = 0;
        }
    }

    private void CreateNum(int fpoint)
    {
        //桁を割り出す
        int digit = CheckDigit(fpoint);
        //描画するオブジェをプレハブから読み込み
        GameObject obj = LoadGObject("Number", objname);
        

        for(int i=0;i<digit;i++)
        {
            //読み込んだオブジェクトをインスタンスする
            GameObject numObj = Instantiate(obj) as GameObject;
            //作り出したオブジェを子として登録
            numObj.transform.parent = transform;

            //今チェックしている桁の数字を出す
            int digNum = GetPointDigit(fpoint, i + 1);
            //数値を画像に置き換える
            numObj.GetComponent<NumCtrl>().ChangeSprite(digNum);
            //サイズを取得
            float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;
            //被らないように位置をずらしていく
            float ajs_x = size_w * i - (size_w * digit) / 2;
            Vector3 pos = new Vector3(init_pos.x - ajs_x, init_pos.y, init_pos.z);
            numObj.transform.position = pos;
            numObj = null;
        }
    }

    public static int CheckDigit(int num)
    {
        //０の場合1桁として返す
        if (num == 0) return 1;
        //対数によって桁を割り出す
        return (num == 0) ? 1 : ((int)Mathf.Log10(num) + 1);
    }

    public static int GetPointDigit(int num,int digit)
    {
        int res = 0;
        int pow_dig = (int)Mathf.Pow(10, digit);
        if(digit==1)
        {
            res = num - (num / pow_dig) * pow_dig;
        }
        else
        {
            res = (num - (num / pow_dig) * pow_dig) / (int)Mathf.Pow(10, (digit - 1));
        }
        return res;
    }
    
    public static GameObject LoadGObject(string dir_name,string file_name)
    {
        GameObject retObj;
        //Resourcesフォルダにあるものから読み込む
        retObj = (GameObject)Resources.Load(dir_name + "/" + file_name);
        //nullだったらエラー
        if(retObj==null)
        {
            Debug.Log("読み込みエラー");
        }
        return retObj;
    }

}
