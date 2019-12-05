using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneMove : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChange()
    {
        GetComponent<FadeController>().FadeOut(sceneName);
    }

    public void NoFadeChange()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClick()
    {
        GetComponent<FadeController>().FadeOut(sceneName);
    }
}
