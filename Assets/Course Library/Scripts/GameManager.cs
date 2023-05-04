using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    private int score;
    private float spawnRate = 1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targetObjects;
    public Button restartButton;
    public GameObject titleScreen;
    public Slider musicSlider;
    private AudioSource musicSource;
    public GameObject pousePanel;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicValue();
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pousePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pousePanel.SetActive(true);
        }
    }



    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetObjects.Count);
            Instantiate(targetObjects[index]);
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        scoreText.text = "Score " + score;
        spawnRate /= difficulty;

        titleScreen.gameObject.SetActive(false);
    }



    public void SetMusicValue()
    {
        musicSource.volume = musicSlider.value;
    }
}
