using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="ScriptableObject/Weapon/NewWeapon",fileName ="NewWeapon")]
//ÎäÆ÷Êý¾ÝÄ£°å
public class WeaponData : ScriptableObject
{
    public Sprite weapon_sprite;
    public string weapon_name;
    [TextArea]public string weapon_info;
    public GameObject Weapon_prefab;

    public float Firetimer;
}
