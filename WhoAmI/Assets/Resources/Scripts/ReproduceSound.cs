using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproduceSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            audioSource.PlayOneShot(audioClip);
        }
    }
}
