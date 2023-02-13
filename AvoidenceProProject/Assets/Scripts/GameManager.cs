using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded;
    public float restartDelay;
    public GameObject player;
    public GameObject startMenu;
    public GameObject winText;
    public Button stasrtButton;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            player.SetActive(false);
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.GetComponent<PlayerController>().gameStart = false;
        startMenu.SetActive(true);
        player.transform.localScale = new Vector3(2, 2, 2);
        player.GetComponent<PlayerController>().score = 0;
        player.SetActive(true);
        winText.SetActive(false);
        gameHasEnded = false;
    }

    public void OnStartButton()
    {
        player.GetComponent<PlayerController>().gameStart = true;
        startMenu.SetActive(false);
    }

    public void Win()
    {
        winText.SetActive(true);
        Invoke("Restart", restartDelay);
    }
}
