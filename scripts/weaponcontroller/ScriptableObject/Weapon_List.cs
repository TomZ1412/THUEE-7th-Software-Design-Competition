using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�����б�
[CreateAssetMenu(menuName ="ScriptableObject/Weapon/Waponlist/NewWeaponlist",fileName ="NewWeaponlist")]
public class Weapon_List :ScriptableObject
{
    public List<WeaponData> list = new List<WeaponData>();
}
