using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript Instance;
    public int stage=0;
    public int num = 1;
    AudioSource audioSource;
    public AudioClip[] Music;
    public AudioClip[] Step;
    void Start()
    {  audioSource = GetComponent<AudioSource>();
      Sound();
    }
    private void Awake()
    {
      
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Sound()
    {
        audioSource.clip = Music[stage];
        audioSource.Play();
    }
    public void PerformGlobalAction()
    {
        // 执行全局操作  
    }
}
