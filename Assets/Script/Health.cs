using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;
    public RectTransform healthbar;
    private float Originalhealthbarsize;
   

    [Header("UI")]
    public TextMeshProUGUI healthText;


    private void Start()
    {
        Originalhealthbarsize = healthbar.sizeDelta.x;
    }

    public void Update()
    {
       // Healthbar.sizeDelta = new Vector2(originalhealthbarsize * health / 100f, Healthbar.sizeDelta.y);  
    }
    public void TakeDamage(int _damage) {
        health -= _damage;

        healthbar.sizeDelta = new Vector2(Originalhealthbarsize * health / 100f, healthbar.sizeDelta.y);

        healthText.text = health.ToString();

        if (health <= 0) {
            

                Destroy(gameObject);
          
            

        }
    }
}
