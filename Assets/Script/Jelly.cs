using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int jellyhealth;




    public void TakeDamage(int _damage)
    {
        jellyhealth -= _damage;



        if (jellyhealth <= 0)
        {

            gameObject.GetComponent<Animation>().enabled = false;
            gameObject.AddComponent<Rigidbody>();


            StartCoroutine(jelly());


        }
    }

    IEnumerator jelly()
    {
        yield return new WaitForSeconds(5f);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
