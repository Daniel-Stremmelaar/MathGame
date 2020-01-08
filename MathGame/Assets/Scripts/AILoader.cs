using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AILoader : MonoBehaviour
{
    public GameObject AIInventory;
    public Text text;
    private int active;

    public List<CannonShotA> cannonOnePayloads = new List<CannonShotA>();
    public List<CannonShotA> cannonTwoPayloads = new List<CannonShotA>();
    public List<CannonShotA> cannonThreePayloads = new List<CannonShotA>();

    public List<Cannon> cannons = new List<Cannon>();


    private void Start()
    {
        Load();
    }
    public void Load()
    {
        if(cannonOnePayloads.Count > 0)
        {
            cannons[0].payload = cannonOnePayloads[0];
            cannonOnePayloads.Remove(cannonOnePayloads[0]);
        }

        if (cannonTwoPayloads.Count > 0)
        {
            cannons[1].payload = cannonTwoPayloads[0];
            cannonTwoPayloads.Remove(cannonTwoPayloads[0]);
        }

        if (cannonThreePayloads.Count > 0)
        {
            cannons[2].payload = cannonThreePayloads[0];
            cannonThreePayloads.Remove(cannonThreePayloads[0]);
        }
    }

    public void ShowLoads(int i)
    {
        if(i == active)
        {
            AIInventory.SetActive(false);
            active = 0;
        }
        else
        {
            AIInventory.SetActive(true);
            text.text = "";
            if (i == 1)
            {
                active = 1;
                text.text = text.text + cannons[0].payload.sulfur.ToString() + "," + cannons[0].payload.charcoal.ToString() + "; ";
                foreach(CannonShotA c in cannonOnePayloads)
                {
                    text.text = text.text + c.sulfur.ToString() + "," + c.charcoal.ToString() + "; ";
                }
            }
            if (i == 2)
            {
                active = 2;
                text.text = text.text + cannons[1].payload.sulfur.ToString() + "," + cannons[1].payload.charcoal.ToString() + "; ";
                foreach (CannonShotA c in cannonTwoPayloads)
                {
                    text.text = text.text + c.sulfur.ToString() + "," + c.charcoal.ToString() + "; ";
                }
            }
            if (i == 3)
            {
                active = 3;
                text.text = text.text + cannons[2].payload.sulfur.ToString() + "," + cannons[2].payload.charcoal.ToString() + "; ";
                foreach (CannonShotA c in cannonThreePayloads)
                {
                    text.text = text.text + c.sulfur.ToString() + "," + c.charcoal.ToString() + "; ";
                }
            }
        }
    }
}
