using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    public int zombieHeath = 3;
    public int maxZombieHeath = 3;
    private Animator anim;
    public bool isAttack = false;
    public float attackTime = 5;
    private float lastAttackTime = 0;
    //private bool isDead = false;
    private AudioSource audioSource;
    public AudioClip audioDeathSound;
    private GameObject player;
    private float damge;
    public float time = 0;
    public int attack;
    private GameController gamecontroller;
    private GameObject sp;
    public Slider healthBarEnemy;
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isDead", false);
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sp = GameObject.FindGameObjectWithTag("spawn");
        healthBarEnemy.maxValue = maxZombieHeath;
        healthBarEnemy.value = zombieHeath;
        healthBarEnemy.minValue = 0;
        damge = PlayerPrefs.GetFloat("Damge");
    }

    
    public void GetHit(int damge)
    {
        audioSource.Play();
        zombieHeath -= damge;
        healthBarEnemy.value = zombieHeath;
        if(zombieHeath <= 0)
        {
            
            isAttack = false;
            Dead();
            
        }
    }

    void AttackAnim(bool isAttack)
    {
        anim.SetBool("isAttack", isAttack);
    }
    
    public void Attack()
    {
        if (Time.time >= lastAttackTime + attackTime)
        {
            player.GetComponent<PlayerController>().GetHit(damge);
            PlayerPrefs.SetInt("IsAttack", 1);
            AttackAnim(true);
            UpdateAttackTime();
        }
        else
        {
            attack = 0;
            PlayerPrefs.SetInt("IsAttack", attack);
            //isAttack = false;
            AttackAnim(false);
        }
    }

    void UpdateAttackTime()
    {
        lastAttackTime = Time.time;
    }

    void Dead()
    {
        attack = 0;
        PlayerPrefs.SetInt("IsAttack", attack);
        gamecontroller.GetComponent<GameController>().GetPoint();
        audioSource.clip = audioDeathSound;
        audioSource.Play();
        anim.SetBool("isDead", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject,1f);
    }
    // Update is called once per frame
    void Update()
    {

        if (isAttack)
        {
            Attack();
            //gamecontroller.GetComponent<GameController>().Invok();
    //        time += Time.deltaTime;
    //        if (time >= 0.03)
    //        {
    //            gamecontroller.GetComponent<GameController>().Cance();
    //            time = 0;
    //        }
        }
        //else
    //    {
            //gamecontroller.GetComponent<GameController>().Cance();
    //    }
    }
}
