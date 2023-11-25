using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouseObjective : MonoBehaviour
{
    public GameObject puerta;
    public float rx;
    public float ry;
    public float rz;
    private bool update = false;

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            Transform transformPuerta = puerta.transform;
            transformPuerta.Rotate(new Vector3(rx, ry, rz), Space.Self);
            update = false;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            update = true;
        }
    }
}