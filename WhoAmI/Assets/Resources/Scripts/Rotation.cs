using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float RotationSpeed = 10;
    private bool rotation = false;
    public GameObject subject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(rotation && subject.transform.eulerAngles.z == 0 || subject.transform.eulerAngles.z >= 270){
            subject.transform.Rotate(Vector3.back * Time.deltaTime * RotationSpeed);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            rotation = true;
        }
    }
}
