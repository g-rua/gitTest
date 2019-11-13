using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    public AudioSource a;
    public float v;
    public bool isplay;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        v = a.volume;
        isplay = a.isPlaying;
        if(Input.GetKeyDown(KeyCode.M))
        {
            a.Play();
        }
    }
}
