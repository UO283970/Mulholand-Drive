using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int GradosDeRotacion = 0;
    private AudioSource audioSource;
    public AudioClip openning;
    public AudioClip closing;
    public bool isOpen;

    private void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Transform transformPuerta = gameObject.transform;
            transformPuerta.Rotate(new Vector3(0, GradosDeRotacion, 0), Space.Self);
            GradosDeRotacion = -GradosDeRotacion;

            audioSource.Stop();

            if(isOpen){
                audioSource.clip = closing;
            } else{
                audioSource.clip = openning;
            }

            audioSource.Play();
        }
    }
}
