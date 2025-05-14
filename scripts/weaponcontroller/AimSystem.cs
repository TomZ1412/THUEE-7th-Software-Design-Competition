using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    public static AimSystem Instance {  get; private set; }

    private void Awake()
    {
        //Instance = null;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject CurrentWeapon;
    public Vector3 mouseScreenPosition = Vector3.zero;
    public Vector3 Aim_Direction = Vector3.zero;
    private Camera mainCamera;
    private SpriteRenderer hero_spriterenderer;

    
    private void Start()
    {
        mainCamera = Camera.main;
        hero_spriterenderer = this.gameObject.transform.parent.GetComponent<SpriteRenderer>();
        CurrentWeapon=this.transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        Aim();
    }
    //Aim

    private void Aim()
    {
        mouseScreenPosition = Input.mousePosition;
        Aim_Direction = mouseScreenPosition - mainCamera.WorldToScreenPoint(CurrentWeapon.transform.position);
        Aim_Direction.z = 0;
        Aim_Direction.Normalize();
        float angle = Mathf.Atan2(Aim_Direction.y, Aim_Direction.x) * Mathf.Rad2Deg;
        CurrentWeapon.transform.eulerAngles = new Vector3(0, 0, angle);


        Weapon_flip(angle);
    }


    private void Weapon_flip(float angle)
    {
        if (angle < 90 && angle > -90) CurrentWeapon.GetComponent<SpriteRenderer>().flipY = false;
        else CurrentWeapon.GetComponent<SpriteRenderer>().flipY = true;
    }
       
    public static void UpdateCurrentWeapon(WeaponData weapondata)
    {
        if (Instance.gameObject.transform.childCount > 2)
            Instance.CurrentWeapon = Instantiate(weapondata.Weapon_prefab, Instance.gameObject.transform);
        else
        {
            Destroy(Instance.CurrentWeapon.gameObject);
            Instance.CurrentWeapon=Instantiate(weapondata.Weapon_prefab,Instance.gameObject.transform);
        }
    }
}