using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public int power;
    public Vector3 direction;
    public float speed;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "AIball")
        {
            LosePower(collision.gameObject.GetComponent<Cannonball>().power, collision.gameObject);
        }

        if(collision.gameObject.tag == "Ship" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ShipHealth>().Damage(power);
            Destroy(gameObject);
        }
    }

    public void LosePower(int i, GameObject g)
    {
        if(i > power)
        {
            g.GetComponent<Cannonball>().power -= power;
            Destroy(gameObject);
        }
        else
        {
            power -= i;
            if(power <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(g);
        }
    }
}
