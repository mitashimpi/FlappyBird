using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //We can use this to reload the game
using UnityEngine.UI;

//We are using the singleton pattern here. So cannot instantiate class more than once
public class GameControl : MonoBehaviour
{

    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -2f;
    public Text scoreText;
    private int score = 0;
    
    //Awake is called before Start
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this) 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the active screen
        }
    }

    public void BirdScored()
    {
        if(gameOver == true)
        {
            return;
        } 
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
