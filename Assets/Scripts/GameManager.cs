using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text livesText;
    public int lives = 3;
    public Text gameOver;
    public SnakeMovment player;
    public GameObject button;
    AudioSource gameOverSound;

    private void Start()
    {
        gameOverSound = gameObject.GetComponent<AudioSource>();
        button.SetActive(false);
    }

    private void Update()
    {
       if (lives <= 0)
        {
            player.GameOver();
            gameOver.text = "Game Over";
            gameOverSound.Play();
            button.SetActive(true);
        }
    }

    public void Damage() 
    {
        lives--;
        livesText.text = lives.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GameOver();
        gameOver.text = "You Win";
        button.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }
}
