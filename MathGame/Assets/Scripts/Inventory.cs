using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Available payloads")]
    public List<CannonShotA> ammo = new List<CannonShotA>();
    public GameObject button;
    public GameObject inventory;
    private int buttonCount;

    [Header("Current payloads")]
    public Cannon cannonOne;
    public Cannon cannonTwo;
    public Cannon cannonThree;
    public List<Cannon> cannons = new List<Cannon>();

    [Header("Payload selection")]
    public Button payloadOne;
    public Button payloadTwo;
    public Button payloadThree;
    public List<Button> payloads = new List<Button>();
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
            selected = -1;
        }

        UpdateInventory();
    }

    public void SetPayload(int i)
    {
        if (cannons[selected].payload != null)
        {
            ammo.Add(cannons[selected].payload);
            cannons[selected].payload = null;
        }
        cannons[selected].payload = ammo[i];
        ammo.Remove(ammo[i]);

        SelectCannon(selected);
    }

    public void UpdateInventory()
    {
        buttonCount = 0;

        foreach(Transform child in inventory.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(CannonShotA c in ammo)
        {
            GameObject g = Instantiate(button);
            g.transform.parent = inventory.transform;
            g.GetComponentInChildren<Text>().text = c.sulfur.ToString() + "," + c.charcoal.ToString();
            g.GetComponent<ButtonTracker>().index = buttonCount;
            g.GetComponent<Button>().onClick.AddListener(delegate { SetPayload(g.GetComponent<ButtonTracker>().index); });
            buttonCount++;
        }

        for(int i = 0; i < cannons.Count; i++)
        {
            if(cannons[i].payload != null)
            {
                payloads[i].GetComponentInChildren<Text>().text = cannons[i].payload.sulfur.ToString() + "," + cannons[i].payload.charcoal.ToString();
            }
            else
            {
                payloads[i].GetComponentInChildren<Text>().text = "Empty";
            }
        }
    }
}
