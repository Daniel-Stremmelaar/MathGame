using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public CannonShotA payload;

    public GameObject cannonball;
    public GameObject ballSpawn;
    public int direction;

    public virtual void Fire()
    {
        if (payload != null)
        {
            GameObject g = Instantiate(cannonball, ballSpawn.transform.position, Quaternion.identity);
            g.GetComponent<Cannonball>().power = payload.charcoal + payload.sulfur;
            g.GetComponent<Cannonball>().direction.x = direction;
            payload = null;
        }
    }
}
