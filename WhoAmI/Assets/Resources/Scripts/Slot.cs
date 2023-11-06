using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int id;
    public string description;
    public Sprite icon;

    public bool empty;
    public Transform sloticonGameObject;

    private void Start() {
        sloticonGameObject = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        sloticonGameObject.GetComponent<Image>().sprite = icon;
    }
}
