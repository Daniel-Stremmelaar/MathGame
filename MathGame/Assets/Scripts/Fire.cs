using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public AILoader AIloader;
    public Inventory inventory;
    public float cooldownTime;
    private float cooldown;
    [SerializeField] private List<Cannon> cannons = new List<Cannon>();
    private Button self;

    private void Start()
    {
        cooldown = 0;

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Cannon"))
        {
            cannons.Add(g.GetComponent<Cannon>());
        }

        self = this.gameObject.GetComponent<Button>();

        self.onClick.AddListener(Shoot);
    }

    public void Shoot()
    {
        if (cooldown <= 0)
        {
            foreach (Cannon c in cannons)
            {
                if (c != null)
                {
                    c.Fire();
                }
            }
            cooldown = cooldownTime;
        }

        AIloader.Load();
        inventory.UpdateInventory();
    }

    private void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
