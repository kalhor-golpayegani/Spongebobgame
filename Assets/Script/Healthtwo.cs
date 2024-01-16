using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthtwo : MonoBehaviour
{
    public int Health;
    public void TakeDamage(int _damage)
    {
        Health -= _damage;



        if (Health <= 0)
        {

            gameObject.AddComponent<Rigidbody>();

            StartCoroutine(falling());


        }
    }
    IEnumerator falling()
    {
        yield return new WaitForSeconds(5f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
