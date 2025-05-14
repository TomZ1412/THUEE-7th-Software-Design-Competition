
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����ϵͳ
public class WeaponSystem : MonoBehaviour
{
    private Weapon_List weaponlist;
    public int index = 0;
    public WeaponData weapondata;
    


    private void Awake()
    {
        weaponlist = Resources.Load<Weapon_List>(typeof(Weapon_List).Name);
         Debug.Log(weaponlist);
        if (weaponlist != null)
        {
            weapondata = weaponlist.list[0];
            Invoke("AimSystem.UpdateCurrentWeapon(weapondata)", 0.001f);
        }
           
    }

    private void Update()
    {
        //�л���һ������
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NextWeapon();
        }
        //�л���һ������
        if (Input.GetKeyDown(KeyCode.E))
        {
            LastWeapon();
        }
    }
    private void NextWeapon()
    {
        index++;
        if(index == weaponlist.list.Count)
        {
            index = 0;
        }
        weapondata= weaponlist.list[index];
        AimSystem.UpdateCurrentWeapon(weapondata);
    }


    private void LastWeapon()
    {
        index--;
        if(index<0)
        {
            index=weaponlist.list.Count-1;
        }

        weapondata= weaponlist.list[index];
        AimSystem.UpdateCurrentWeapon(weapondata);
    }
}
