using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float xSpeed = 10;
    public float ySpeed = 10;
    public float zSpeed = 10;
    public bool isRotating = false;

    // Update is called once per frame
    void Update()
    {
        if(isRotating){
            gameObject.transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            isRotating = true;
        }
    }
}
