using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CelectDebugMode : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    [SerializeField] GameObject[] debugField;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject pauseInstance;
    [SerializeField] GameObject pausePanel;
    [SerializeField] Slider slider;
    public bool pouse;
    public int debugGameIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExcutePause();
        SelectDebugGame();
    }

    private void SelectDebugGame()
    {
        if (!pouse) return;
        debugGameIndex = (int)slider.value;
        if(Input.GetKeyDown(KeyCode.Return))
        {
           for(int i=0;i<characters.Length;i++)
            {
                characters[i].transform.position = debugField[debugGameIndex].transform.GetChild(i).position;
            }
            cam.transform.position = debugField[debugGameIndex].transform.GetChild(2).position;
            cam.transform.rotation = debugField[debugGameIndex].transform.GetChild(2).rotation;
            Time.timeScale = 1;
            pouse = false;
            Destroy(pausePanel);
        }


    }



    private void ExcutePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pouse)
            {
                Time.timeScale = 0;
                pouse = true;
                if (pausePanel == null)
                {
                    pausePanel = GameObject.Instantiate(pauseInstance) as GameObject;
                    slider = pausePanel.transform.Find("Slider").GetComponent<Slider>();
                }
            }
            else
            {
                Time.timeScale = 1;
                pouse = false;
                Destroy(pausePanel);
            }
            Debug.Log(pouse);
        }
    }
}
