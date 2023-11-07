using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;
    private int acum = 0;
    public int time = 1000;
    private System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (acum > time)
        {
            rnd = new System.Random();
            // clips = Resources.LoadAll<AudioClip>("Clips");
            // Debug.Log(clips.Length);
            source.clip = clips[rnd.Next(0, clips.Length)];
            source.Play();
            acum = 0;


        }
        else
        {
            acum++;
        }

    }
}
