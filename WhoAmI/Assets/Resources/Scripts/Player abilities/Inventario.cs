using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private bool inventarioEnabled;

    private int allSlots;
    private int slotsOcupated;
    private GameObject[] slot;

    public GameObject slotHolder;
    public GameObject inventory;

    public void Start() 
    {
        allSlots = slotHolder.transform.childCount;
        slotsOcupated = 0;
        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }    

        inventory.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventarioEnabled = !inventarioEnabled;
            if(inventarioEnabled)
            {
                inventory.SetActive(true);
            }else{
                inventory.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Collectable"))
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItemToInv(itemPickedUp,item.id,item.description,item.icon);
        }
    }

    public void AddItemToInv(GameObject objectToAdd, int itemId, string description, Sprite icon)
    {
        if(slot[slotsOcupated].GetComponent<Slot>().empty)
        {
            
            objectToAdd.GetComponent<Item>().toglePickedUp();

            slot[slotsOcupated].GetComponent<Slot>().item = objectToAdd;
            slot[slotsOcupated].GetComponent<Slot>().id = itemId;
            slot[slotsOcupated].GetComponent<Slot>().description = description;
            slot[slotsOcupated].GetComponent<Slot>().icon = icon;

            objectToAdd.transform.parent = slot[slotsOcupated].transform;
            objectToAdd.SetActive(false);

            slot[slotsOcupated].GetComponent<Slot>().UpdateSlot();

            slot[slotsOcupated].GetComponent<Slot>().empty = false;

            slotsOcupated++;
        }
    }
}
