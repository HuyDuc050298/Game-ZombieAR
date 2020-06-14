
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //public GameObject menu;
    //public GameObject button;
    public Text txtPoint;
    public Text txtTime;
    public Text Bullet;
    //public float speed;
    public int currentPoint = 0;
    public int currentBullet = 20;
    public int maxcurrentBullet = 20;
    public float timeLeft = 90;
    public float time = 0;
    private TimeSpan timePlaying;
    public bool isRunGame;
    public Button buttonFire;
    public Image bloodScreen;
    public Image target;
    public ParticleSystem muzzleFlash;
    //[SerializeField] private GameObject img;
    //[SerializeField] private Image bloodScreen;
    //private int currentBullet = 100;
    private GameObject playerController;
    private PlayerController player;
    private GameObject Weapon;
    private GameObject Weapon1;
    //private ZombieController zb;
    public float currentTime = 0;
    private int ath;
    // Start is called before the first frame update
    void Start()
    {
        GetTime();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //Weapon = GameObject.FindGameObjectWithTag("Weapon");
        //Weapon.SetActive(false);
       // Weapon1 = GameObject.FindGameObjectWithTag("Weapon1");
       //Weapon1.SetActive(true);
        //zb = GameObject.FindGameObjectWithTag("ZombieController").GetComponent<ZombieController>();
        muzzleFlash.Stop();
        target.gameObject.SetActive(true);
        //bloodScreen.gameObject.SetActive(false);
        ath = 0;
    }


    void RunGame()
    {

    }
    public void GetTime()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            WinGame();
        }
        timePlaying = TimeSpan.FromSeconds(timeLeft);
        txtTime.text = timePlaying.ToString("mm") + ":" + timePlaying.ToString("ss");
    }

    public void GetPoint()
    {
        currentPoint += 1;
        txtPoint.text = "SCORE : " + currentPoint.ToString();
    }

    public void GetBullet()
    {
        //currentBullet --;
        if (currentBullet < 0) currentBullet = 0;
        Bullet.text = currentBullet.ToString() + "/" + maxcurrentBullet.ToString();
    }

    public void GetFire()
    {
        buttonFire.onClick.AddListener(player.Fire);

    }

    public IEnumerator WeaponEffect()
    {
        muzzleFlash.Play();
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();
    }
    public void Cance()
    {
        //bloodScreen.gameObject.SetActive(false);
        CancelInvoke("Image");
    }

    public void Invok()
    {
        InvokeRepeating("Image", 0, 0.2f);
    }

    public void Image()
    {
        bloodScreen.gameObject.SetActive(true);
    }


    void Update()
    {
        if (isRunGame)
        {
            GetBullet();
            GetTime();
            GetFire();
            ath = PlayerPrefs.GetInt("IsAttack");
            if(ath == 1)
            {
                bloodScreen.gameObject.SetActive(true);
                time += Time.deltaTime;
                if (time >= 0.2f)
                {
                    bloodScreen.gameObject.SetActive(false);
                    time = 0;
                }

            }
            else
            {

                bloodScreen.gameObject.SetActive(false);
            }
        }

    }

    public void EndGame()
    {
        //menu.SetActive(true);
        PlayerPrefs.SetInt("Score", currentPoint);
        SceneManager.LoadScene(2);

    }

    public void WinGame()
    {
        PlayerPrefs.SetInt("Score", currentPoint);
        SceneManager.LoadScene(3);
    }
}
