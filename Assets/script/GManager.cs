using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    bool playable = false;
    bool paused = false;

    public GameObject score;
    public GameObject start;
    public GameObject pause;

    public bool playing()
    {
        return playable;
    }
    public bool pausing()
    {
        return paused;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playable)
            {
                if (paused)
                {
                    resume();
                }
                else
                {
                    showpause();
                }
            }
        }
    }

    void showpause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    void resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    //starting game
    public void playit()
    {
        playable = true;
        start.SetActive(false);
        score.SetActive(true);
    }

    //game over
    public void gameover()
    {
        if (playable) {
            playable = false;

            Debug.Log("gameover");
            //show total score and restart option

            Invoke("restart", 2);
        }
    }

    //restart the game
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
