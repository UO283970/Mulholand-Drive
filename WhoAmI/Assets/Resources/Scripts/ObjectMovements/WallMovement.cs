using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float xDisplacement = 0f;
    public float xDisplacementLimit = 0f;
    public float yDisplacement = 0f;
    public float yDisplacementLimit = 0f;
    public float zDisplacement = 0f;
    public float zDisplacementLimit = 0f;
    private bool isPlaying = false;
    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localPosition.x <= xDisplacementLimit && gameObject.transform.localPosition.y <= yDisplacementLimit
        && gameObject.transform.localPosition.z <= zDisplacementLimit){
            gameObject.transform.Translate(xDisplacement * Time.deltaTime,
            yDisplacement * Time.deltaTime, zDisplacement * Time.deltaTime);
            if(!isPlaying){
                audio.Play();
                isPlaying = true;
            }
        }
        else{
            audio.Stop();
            isPlaying = false;
        }
    }
}
