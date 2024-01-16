using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    private int SelectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        ChooseWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int PreviousSelectedWeapon = SelectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedWeapon = 1;
        }

        if (PreviousSelectedWeapon != SelectedWeapon)
        {
            ChooseWeapon();
        }
    }

    void ChooseWeapon()
    {
        int i = 0;

        foreach (Transform _weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                _weapon.gameObject.SetActive(true);
            }
            else
            {
                _weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }


}
