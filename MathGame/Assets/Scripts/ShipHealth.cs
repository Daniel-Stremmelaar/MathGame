using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public Text health;
    public int hp;
    public Text end;

    private void Start()
    {
        health.text = hp.ToString() + " hp";
    }

    public void Damage(int damage)
    {
        hp -= damage;
        health.text = hp.ToString() + " hp";
        if(hp <= 0)
        {
            end.gameObject.SetActive(true);
            if(gameObject.tag == "Player")
            {
                end.text = "You lose!";
            }
            else
            {
                end.text = "You win!";
            }
        }
    }
}
