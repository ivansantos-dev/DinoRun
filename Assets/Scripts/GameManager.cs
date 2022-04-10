using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI distanceText;

    private Vector3 originalPosition;
    private long distance;

    void Awake()
    {
        originalPosition = player.transform.position;
        Application.targetFrameRate = 60;
        Play();
    }

    public void Play()
    {
        foreach (var obs in FindObjectsOfType<Obstacle>())
        {
            Destroy(obs.gameObject);
        }

        player.transform.position = originalPosition;
        gameOver.SetActive(false);
        Time.timeScale = 1;
        InvokeRepeating(nameof(IncreaseScore), 0f, .1f);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        CancelInvoke(nameof(IncreaseScore));
        distance = 0;
    }

    public bool isGameOver()
    {
        return Time.timeScale == 0;
    }

    private void IncreaseScore() {
        distance++;
        distanceText.text = distance.ToString();
    }

}
