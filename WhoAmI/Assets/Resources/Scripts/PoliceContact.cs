using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class PoliceContact : MonoBehaviour
{
    public GameObject finalText;
    public string sceneToBeRestarted;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            finalText.SetActive(true);
            StartCoroutine(DelayThenFall(5f));
        }
    }

    IEnumerator DelayThenFall(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToBeRestarted);
    }
}
