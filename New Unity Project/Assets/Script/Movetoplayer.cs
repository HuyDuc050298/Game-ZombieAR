using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetoplayer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;

    GameObject lookAtTarget;
    public float moveSpeed;
    private float attackRange = 3;
    private GameController gameController;
    private StartGameController gameStart;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        lookAtTarget = GameObject.FindGameObjectWithTag("LookAt");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //gameStart = GameObject.FindGameObjectWithTag("StartGameController").GetComponent<StartGameController>();
        moveSpeed = PlayerPrefs.GetFloat("MoveSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    void Move()
    {
        if (player == null || lookAtTarget == null)
            return;
        if (Vector3.Distance(transform.position, player.transform.position) > attackRange)
        {
            transform.LookAt(lookAtTarget.transform.position);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            //gameObject.GetComponent<Animator>().SetBool("isIdle", true);
            gameObject.GetComponent<ZombieController>().isAttack = true;
            PlayerPrefs.SetInt("IsAttack", 1);
            gameObject.GetComponent<Movetoplayer>().enabled = false;
        }
    }
}
