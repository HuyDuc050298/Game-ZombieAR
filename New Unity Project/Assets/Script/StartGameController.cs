using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{
    
    public Button easy;
    public Button normal;
    public Button hard;
    public GameObject menu;
    private GameController gc;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        easy.onClick.AddListener(SetEasySpeed);
        normal.onClick.AddListener(SetNormalSpeed);
        hard.onClick.AddListener(SetHardSpeed);
        //gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //gc.isRunGame = false;
    }

    // Update is called once per frame

    void SetEasySpeed()
    {
        //gc.speed = 1;
        //gc.isRunGame = true;
        //menu.SetActive(false);

        speed = 0.5f;
        PlayerPrefs.SetFloat("MoveSpeed", speed);
        PlayerPrefs.SetFloat("IsAttack", 0);
        PlayerPrefs.SetFloat("Damge", 1);
        SceneManager.LoadScene(1);
    }

    void SetNormalSpeed()
    {
        //gc.speed = 2;
        //gc.isRunGame = true;
        //menu.SetActive(false);
        speed = 1;
        PlayerPrefs.SetFloat("MoveSpeed", speed);
        PlayerPrefs.SetFloat("IsAttack", 0);
        PlayerPrefs.SetFloat("Damge", 3);
        SceneManager.LoadScene(1);
    }

    void SetHardSpeed()
    {
        //gc.speed = 100;
        //gc.isRunGame = true;
        //menu.SetActive(false);
        speed = 2;
        PlayerPrefs.SetFloat("MoveSpeed", speed);
        PlayerPrefs.SetFloat("IsAttack", 0);
        PlayerPrefs.SetFloat("Damge", 4);
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        
    }
}
