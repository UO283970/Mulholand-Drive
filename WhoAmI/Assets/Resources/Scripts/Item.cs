using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string description;
    public Sprite icon;

    private bool pickedUp;

    private void Start() {
        pickedUp = false;
    }

    public void toglePickedUp(){
        pickedUp = !pickedUp;
    }

}
