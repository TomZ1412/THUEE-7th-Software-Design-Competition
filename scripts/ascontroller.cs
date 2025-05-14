using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ascontroller : MonoBehaviour
{
    public int maxhealth = 10;
    float speed ;
    public float timeInvincible = 2.0f;
    public int health { get { return currenthealth; } }
    int currenthealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public AudioClip[] weapon,step;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    bool isInvincible;
    float invincibleTimer;
    
    public GameObject self;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject bulletPrefab;
    public GameObject riflebulletPrefab;
    public GameObject Rocketprefab;
    GameObject pos;
    GameObject weaponSystem;

    private AimSystem aim;
    GameObject posfire;
    Transform ts;
    Vector3 rocketfocus = Vector3.zero;

    public static float Gtimer=0;
    public float Gfiretime;
    public static float Rtimer=0;
    public float Rfiretime;
    private float Ftimer = 0;
    public float Ffiretime=2;
    bool is_fired1=false;
    bool is_fired2=false;
    bool is_fired3=false;
    public static float magnitude1 =0;
    float temp1;
    public static float magnitude2 =0;
    float temp2;
    
    public int rocketNum = 3;
    public int rocketAngle = 15;

    public GameObject player;
    public GameObject[] enemy;
    public GameObject[] spot;
    bool isPlaying;
    float PlayingTimer;
    public float timePlaying = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        audioSource2.volume = 1.0f;
        player.transform.position = new Vector2(-22, -15);

        rigidbody2d = GetComponent<Rigidbody2D>();
        currenthealth = maxhealth;
        animator = GetComponent<Animator>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        weaponSystem = GameObject.Find("WeaponSystem");

        aim = AimSystem.Instance;
        
    }

   
    void Update()
    {
        if (currenthealth < 0.5f)
        {
            animator.SetTrigger("died");
            Invoke("playerDie", 1f);
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6.0f;
               if(!isPlaying)
                {audioSource2.PlayOneShot(step[0]);
                    isPlaying = true;PlayingTimer = timePlaying*0.8F;
                }
                
            }
            else
            { 
                speed = 3.0f;
                if (!isPlaying)
                {
                    audioSource2.PlayOneShot(step[1]);
                    isPlaying = true; PlayingTimer = timePlaying;
                }
            }
        }
        else
        {
            speed = 0.0f;
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", speed);
                                 
       if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;

        }
        if (isPlaying)
        {
            PlayingTimer -= Time.deltaTime;
            if (PlayingTimer < 0)
                isPlaying = false;

        }


    }
    void FixedUpdate()
    {

        Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
            rigidbody2d.MovePosition(position);
            WeaponSystem weaponScript=weaponSystem.GetComponent<WeaponSystem>();

        posfire = aim.CurrentWeapon.transform.Find("FirePos").gameObject;
        if (posfire != null)
        {
           ts= posfire.transform;
           
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (weaponScript.index == 2)
            {
                Rocket rocket = Rocketprefab.GetComponent<Rocket>();
                if (0 <= rocket.Lerp && rocket.Lerp <= 1.5) rocket.Lerp = rocket.Lerp + Input.GetAxis("Mouse ScrollWheel");
                if (rocket.Lerp < 0) rocket.Lerp = 0;
                if (rocket.Lerp > 1.5) rocket.Lerp = 1.5f;
            }

        }

        if (magnitude1 >= 8)
        {
            temp1 = Gfiretime;
            Gfiretime = 3;
            magnitude1 = 0;
        }
        if(magnitude2 >= 30) 
        {
            temp2 = Rfiretime;
            Rfiretime = 5;
            magnitude2 = 0;
        }
        if (is_fired1 == true)
        {
            Gtimer += Time.deltaTime;
            if (Gtimer >=Gfiretime)
            {
                Gtimer = 0;
                is_fired1 = false;
                if (Gfiretime == 3) Gfiretime = temp1;
            }
        }
        if (is_fired2 == true)
        {
            Rtimer += Time.deltaTime;
            if (Rtimer >= Rfiretime)
            {
                Rtimer = 0;
                is_fired2 = false;
                if (Rfiretime == 5) Rfiretime = temp2;
            }
        }
        if (is_fired3 == true)
        {
            Ftimer += Time.deltaTime;
            if (Ftimer >= Ffiretime)
            {
                Ftimer = 0;
                is_fired3 = false;
                
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponScript.index == 0)
            {
               if(is_fired1==false)
                {
                    LaunchBulletgun();
                    magnitude1 += 1;
                    is_fired1 = true;
                    
                }
               
            }
            if (weaponScript.index == 1)
            {
                if(is_fired2==false) 
                {
                    LaunchBulletrifle();
                    magnitude2 += 1;
                    is_fired2 = true;
                }
            }
            if(weaponScript.index == 2)
            {
                if (is_fired3 == false)
                {
                    rocketfocus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    rocketfocus.z = 0;
                    LaunchRocket();
                    is_fired3 = true;
                }
            }
          
            
        }
        if(weaponScript.index==2)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                if (rocketNum <= 5) rocketNum++;
                if (rocketNum > 5) rocketNum = 3;
            }  
        }
        
          
        
    }

     public void ChangeHealth(int amount)
     {
         if (amount < 0)
         {


             if (isInvincible)
                 return;
            animator.SetTrigger("hit");
             isInvincible = true;
             invincibleTimer = timeInvincible;

        }
        currenthealth = Mathf.Clamp(currenthealth + amount, 0, maxhealth);
        UIHealthbar.instance.SetValue((float)currenthealth / (float)maxhealth);

     }
                                              
    //change weapons
    void LaunchBulletgun()
    {
        pos = GameObject.Find("Weapon_Pos");
        AimSystem aimSystem = pos.GetComponent<AimSystem>();
        audioSource.clip =weapon[0];
        audioSource.Play();


        GameObject bulletObject1 = Instantiate(bulletPrefab,ts.position, Quaternion.identity);
        Bullet bullet = bulletObject1.GetComponent<Bullet>();
        bullet.transform.eulerAngles = aimSystem.CurrentWeapon.transform.eulerAngles;
        bullet.Launch(aimSystem.Aim_Direction,300);
    }

    void LaunchBulletrifle()
    {
        pos = GameObject.Find("Weapon_Pos");
        AimSystem aimSystem = pos.GetComponent<AimSystem>();
        audioSource.clip = weapon[1];
        audioSource.Play();
        GameObject bulletObject2 = Instantiate(riflebulletPrefab, ts.position, Quaternion.identity);
        rifleBullet riflebullet = bulletObject2.GetComponent<rifleBullet>();
        riflebullet.transform.eulerAngles = aimSystem.CurrentWeapon.transform.eulerAngles;
        riflebullet.Launch(aimSystem.Aim_Direction, 300);
        
    }

    void LaunchRocket()
    {
        audioSource.clip = weapon[2];
        audioSource.Play();
        StartCoroutine(DelayFire(.2f));       
    }

    IEnumerator DelayFire(float delay)
    {
        yield return new WaitForSeconds(delay);

        pos = GameObject.Find("Weapon_Pos");
        AimSystem aimSystem = pos.GetComponent<AimSystem>();
        for (int i = 1; i < rocketNum + 1; i++)
        {
            GameObject Rocket = Instantiate(Rocketprefab, ts.position, Quaternion.identity);
            if (rocketNum % 2 == 1)
            {
                Rocket.transform.Rotate(0, 0, Mathf.Atan2(aimSystem.Aim_Direction.y, aimSystem.Aim_Direction.x) * Mathf.Rad2Deg - 90 + 180 * i / (rocketNum + 1));
            }
            else
            {
                Rocket.transform.Rotate(0, 0, Mathf.Atan2(aimSystem.Aim_Direction.y, aimSystem.Aim_Direction.x) * Mathf.Rad2Deg - 90 + 180 * i / (rocketNum + 1));            
            }
            Rocket.GetComponent<Rocket>().SetTarget(rocketfocus);
        }
        transform.position = transform.position - aimSystem.Aim_Direction*0.01f;
    }
    void playerDie()
    {
        //以下为返回复活点
        UIHealthbar.instance.SetValue((float)currenthealth / (float)maxhealth);
        animator.SetBool("revival", true);

        if (GlobalScript.Instance.stage == 1)
        {
            currenthealth = maxhealth;
            player.transform.position = new Vector2(-22, -15);
            for (int i = 0; i < 13; i++)
            {
                enemy[i].SetActive(true);
            }
        }


        else if (GlobalScript.Instance.stage == 3)
        {
            currenthealth = maxhealth;
            player.transform.position = new Vector2(20, 13);
            for (int i = 0; i < 13; i++)
            {
                enemy[i].SetActive(true);
            }

        }

        else if (GlobalScript.Instance.stage == 5)
        {
            currenthealth = maxhealth;
            player.transform.position = new Vector2(-66, 33);
            GlobalScript.Instance.num = SpotController.Num+1;

            for (int i = 0; i < 13; i++)
            {
                enemy[i].SetActive(true);
            }

            for (int i = 0; i < 11; i++)
            {
                spot[i].SetActive(true);
            }
        }


    }
}
