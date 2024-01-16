using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public int damage;

    public float fireRate;

    public Camera camera;

    private float nextFire;

    [Header("Ammo")]
    public int mag = 5;
    public int ammo = 30;
    public int magAmmo = 30;

    [Header("VFX")]
    public GameObject hitVFX;

    [Header("UI")]
    public TextMeshProUGUI magText;
    public TextMeshProUGUI ammoText;

    AudioSource shootingsound;


    void Start()
    {
        shootingsound = GetComponent<AudioSource>();
        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && nextFire <= 0 && ammo > 0)
        {
            nextFire = 1 / fireRate;
            shootingsound.Play();
            ammo--;

            magText.text = mag.ToString();
            ammoText.text = ammo + "/" + magAmmo;

            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        if (mag > 0)
        {
            mag--;

            ammo = magAmmo;
        }

        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;
    }

    void Fire()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        RaycastHit hit;
        Debug.DrawRay(camera.transform.position, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f))
        {

            Instantiate(hitVFX, hit.point, Quaternion.identity);
            

            if (hit.transform.gameObject.GetComponent<Healthtwo>())
            {
                hit.transform.gameObject.GetComponent<Healthtwo>().TakeDamage(damage);
            }
            if (hit.transform.gameObject.GetComponent<Jelly>())
            {
                hit.transform.gameObject.GetComponent<Jelly>().TakeDamage(damage);
            }

        }
    }
}
