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
        if(collision.gameObject.tag == "Cannonball")
        {
            LosePower(collision.gameObject.GetComponent<Cannonball>().power);
        }
    }

    public void LosePower(int i)
    {
        power -= i;
        if (power <= 0)
        {
            Destroy(gameObject);
        }
    }
}
