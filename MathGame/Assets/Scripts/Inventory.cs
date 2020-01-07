using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Available payloads")]
    public List<CannonShotA> ammo = new List<CannonShotA>();
    public List<Button> ammoSelect = new List<Button>();
    public GameObject inventory;

    [Header("Current payloads")]
    public Cannon cannonOne;
    public Cannon cannonTwo;
    public Cannon cannonThree;

    [Header("Payload selection")]
    public Button payloadOne;
    public Button payloadTwo;
    public Button payloadThree;
    public int selected;

    private void Start()
    {
        UpdateInventory();
    }

    public void SelectCannon(int i)
    {
        if(selected != i)
        {
            inventory.SetActive(true);
            selected = i;
        }
        else
        {
            inventory.SetActive(false);
            selected = 0;
        }

        UpdateInventory();
    }

    public void SetPayload(int i)
    {
        if(selected == 1)
        {
            if(cannonOne != null)
            {
                ammo.Add(cannonOne.payload);
                cannonOne.payload = null;
            }
            cannonOne.payload = ammo[i];
            ammo.Remove(ammo[i]);
        }

        if(selected == 2)
        {
            if(cannonTwo.payload != null)
            {
                ammo.Add(cannonTwo.payload);
                cannonTwo.payload = null;
            }
            cannonTwo.payload = ammo[i];
            ammo.Remove(ammo[i]);
        }

        if (selected == 3)
        {
            if (cannonThree.payload != null)
            {
                ammo.Add(cannonThree.payload);
                cannonThree.payload = null;
            }
            cannonThree.payload = ammo[i];
            ammo.Remove(ammo[i]);
        }

        UpdateInventory();
    }

    public void SelectPayload()
    {
        ammoSelect.FindIndex()
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < ammoSelect.Count; i++)
        {
            if(ammo[i] != null)
            {
                ammoSelect[i].GetComponentInChildren<Text>().text = ammo[i].sulfur.ToString() + "," + ammo[i].charcoal.ToString();
            }
            else
            {
                ammoSelect[i].gameObject.SetActive(false);
            }
        }

        if(cannonOne.payload != null)
        {
            payloadOne.GetComponentInChildren<Text>().text = cannonOne.payload.sulfur.ToString() + "," + cannonOne.payload.charcoal.ToString();
        }
        else
        {
            payloadOne.GetComponentInChildren<Text>().text = "Empty";
        }

        if (cannonTwo.payload != null)
        {
            payloadTwo.GetComponentInChildren<Text>().text = cannonTwo.payload.sulfur.ToString() + "," + cannonTwo.payload.charcoal.ToString();
        }
        else
        {
            payloadTwo.GetComponentInChildren<Text>().text = "Empty";
        }

        if (cannonThree.payload != null)
        {
            payloadThree.GetComponentInChildren<Text>().text = cannonThree.payload.sulfur.ToString() + "," + cannonThree.payload.charcoal.ToString();
        }
        else
        {
            payloadThree.GetComponentInChildren<Text>().text = "Empty";
        }
    }
}
