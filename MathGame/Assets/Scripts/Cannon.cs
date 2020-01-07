using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public CannonShotA payload;

    public GameObject cannonball;
    public GameObject ballSpawn;
    public int direction;

    public void Fire()
    {
        GameObject g = Instantiate(cannonball, ballSpawn.transform.position, Quaternion.identity);
        g.GetComponent<Cannonball>().power = payload.charcoal + payload.sulfur;
        g.GetComponent<Cannonball>().direction.x = direction;
        payload = null;
    }
}
