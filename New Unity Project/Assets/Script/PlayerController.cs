using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int damge = 1;
    public float fireTime = 0.1f;
    public float lastFireTime = 0;
    private Animator anim;
    private AudioSource audioS;
    public bool effect = false;
    //public float playerHealth = 10;
    public float playerCurrentHealth = 50;
    private float maxplayerCurrentHealth = 50;
    private GameObject gameController;
    //public int bullet;
    public float time = 0;
    public Button buttonFire;
    public Text Hp;
    void Start()
    {
        buttonFire.gameObject.SetActive(true);
        audioS = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        GetHp();
        UpdateFireTime();   
    }

    void UpdateFireTime()
    {
        lastFireTime = Time.time;
    }    

 
    void SetFireAnim(bool isFire)
    {
        anim.SetBool("isShoot", isFire);    
    }    
    void SetIdle(bool isIdle)
    {
        anim.SetBool("isShoot", true);
        anim.SetBool("isIdle", isIdle);
        
    }
    void SetReload(bool isReload)
    {
        anim.SetBool("isReload", isReload);
    }
    public void Fire()
    {
        if (gameController.GetComponent<GameController>().currentBullet > 0)
        {
            if (Time.time >= lastFireTime + fireTime)
            {
                RaycastHit hit;
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 100))
                {
                    if (hit.transform.tag.Equals("Zombie") || hit.transform.tag.Equals("ZombieGirl"))
                    {
                        gameController.GetComponent<GameController>().currentBullet--;
                        gameController.GetComponent<GameController>().GetBullet();
                        audioS.Play();
                        StartCoroutine(WeaponFire());
                        hit.transform.gameObject.GetComponent<ZombieController>().GetHit(damge);
                        StartCoroutine(gameController.GetComponent<GameController>().WeaponEffect());
                    }
                }
                UpdateFireTime();
            }
            else
            {
                //SetFireAnim(false);
            }
        }
    }

    public IEnumerator WeaponFire()
    {
        SetFireAnim(true);
        yield return new WaitForEndOfFrame();
        SetFireAnim(false);
    }
    public void GetHit(float damge)
    {
        playerCurrentHealth -= damge;
        GetHp();
        if(playerCurrentHealth <= 0)
        {
            gameController.GetComponent<GameController>().EndGame();
        }
    }
   
    public void GetHp()
    {
        if (playerCurrentHealth < 0)
            playerCurrentHealth = 0;
        Hp.text = playerCurrentHealth.ToString() + "/" + maxplayerCurrentHealth.ToString();
    }    

    // Update is called once per frame
    void Update()
    {
        GameController gs = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        if (gs.isRunGame)
        {
            if (gameController.GetComponent<GameController>().currentBullet <= 0)
            {
                SetReload(true);
                time += Time.deltaTime;
                if (time >= 1)
                {
                    SetReload(false);
                    gameController.GetComponent<GameController>().currentBullet = gameController.GetComponent<GameController>().maxcurrentBullet;
                    gameController.GetComponent<GameController>().GetBullet();
                    time = 0;
                }
            }
            //if(!gs.buttonFire.enabled)
            //{
            //    SetFireAnim(false);
            //}
        }

    }


}
