using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.ComponentModel;
using System;
public class CSVLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        string csvFilePath = Application.dataPath + @"/CSVFile/playerpoint.csv";
        Debug.Log(System.IO.File.Exists(csvFilePath));

        string[] texts = File.ReadAllText(csvFilePath).Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);

        foreach(var text in texts)
        {
            Debug.Log(text);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
