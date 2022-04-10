using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    [SerializeField] private Player player;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Play();

    }

    public void Play()
    {
        Debug.Log("start game");
        foreach (var obs in FindObjectsOfType<Obstacle>())
        {
            Destroy(obs.gameObject);
        }

        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game over!");
    }

    public bool isGameOver()
    {
        return Time.timeScale == 0;
    }

}
