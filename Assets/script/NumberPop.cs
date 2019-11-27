using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class NumberPop : MonoBehaviour
{
    private Vector3 init_pos;

    private int point;
    private float size = 1f;
    private static int dam_sort = 0;
    private const int SORT_MAX = 30000;
    // Start is called before the first frame update
    void Start()
    {
        Init(125, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            if(transform.childCount!=0)
            {
                for(int i=transform.childCount-1;i>=0;i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
            Init(Random.Range(0, 500), new Vector3(0, 0, 0));
        }
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
        int digit = CheckDigit(fpoint);

        GameObject obj = LoadGObject("Number", "prefNum");
        Debug.Log(obj);
        for(int i=0;i<digit;i++)
        {
            GameObject numObj = Instantiate(obj) as GameObject;

            numObj.transform.parent = transform;

            int digNum = GetPointDigit(fpoint, i + 1);

            numObj.GetComponent<NumCtrl>().ChangeSprite(digNum);

            float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;

            float ajs_x = size_w * i - (size_w * digit) / 2;

            Vector3 pos = new Vector3(numObj.transform.position.x - ajs_x, numObj.transform.position.y, numObj.transform.position.z);
            numObj.transform.position = pos;
            numObj = null;
        }
    }

    public static int CheckDigit(int num)
    {
        if (num == 0) return 1;
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
        retObj = (GameObject)Resources.Load(dir_name + "/" + file_name);
        if(retObj==null)
        {
            Debug.Log("読み込みエラー");
        }
        return retObj;
    }

}
