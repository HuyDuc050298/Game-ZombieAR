using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    public GameObject menu;
    public Button button;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(0);
        menu.SetActive(true);
        //Button btn = button.GetComponent<Button>();
        button.onClick.AddListener(LoadGame);
        //btn.onClick.AddListener(LoadGame);
        score.text = "YOUR SCORE : " + PlayerPrefs.GetInt("Score").ToString();
    }

    void LoadGame()
    {
        SceneManager.LoadScene(0);
        //Time.timeScale = 1
        //Debug.Log("shjdshfsdh");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
