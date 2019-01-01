using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Handling various game mechanics
public class GameController : MonoBehaviour
{

    public GameObject Hazard;
    public Vector3 HazardPosition;
    public int HazardCount;

    public float HazardDelay;//wait this second before spawning next hazard
    public float StartDelay;//wait this seconds before the game starts 
    public float WaveDelay;//wait this seconds before starting next wave

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private int score;
    private bool restart;
    private bool gameOver;

    private void Start()
    {
        StartCoroutine(SpawnHazard());
        score = 0;
        UpdateScoreText();

        restart = false;
        RestartText.text = "";

        gameOver = false;
        GameOverText.text = "";
    }

    private void Update()
    {
        if (restart && Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void IncrementScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverText.text = "Game Over";
    }

    private IEnumerator SpawnHazard()
    {
        yield return new WaitForSeconds(StartDelay);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                Vector3 position = new Vector3(Random.Range(-HazardPosition.x, HazardPosition.x), HazardPosition.y, HazardPosition.z);
                Quaternion rotation = Quaternion.identity;
                Instantiate(Hazard, position, rotation);
                yield return new WaitForSeconds(HazardDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
            if (gameOver)
            {
                RestartText.text = "Press [R] to Restart";
                restart = true;
                break;
            }
        }
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score;
    }
}
