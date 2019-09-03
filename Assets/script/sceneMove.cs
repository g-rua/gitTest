using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneMove : MonoBehaviour
{
    [SerializeField] GameObject fader;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //シーン遷移の実行
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneChange();
        }
    }

    public void SceneChange()
    {
        Debug.Log("p");
        fader.SetActive(true);
        fader.GetComponent<FadeController>().FadeOut(sceneName, Color.white);
    }

    public void OnClick()
    {
        Debug.Log("p");
        fader.SetActive(true);
        fader.GetComponent<FadeController>().FadeOut(sceneName,Color.white);
    }
}
