using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public int spawnIndex;
    private float spawnRangeX = 17;
    private float spawnPosZ = 30;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public AudioSource song1;
    public AudioSource song2;
    public AudioSource song3;
    public GameObject titleScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void SpawnRandomPrefab()
    {
        if (isGameActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int spawnIndex = Random.Range(0, spawnPrefabs.Length);
            Instantiate(spawnPrefabs[spawnIndex], spawnPos, spawnPrefabs[spawnIndex].transform.rotation);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

        StartCoroutine(FadeOutMusic(2f));
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(PlayMusicPlaylist());
       
        spawnInterval /= difficulty;
        InvokeRepeating("SpawnRandomPrefab", startDelay, spawnInterval);
        score = 0;
        UpdateScore(0);

        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator FadeOutMusic(float fadeTime)
    {
        AudioSource currentSong = null;

        if (song1.isPlaying)
        {
            currentSong = song1;
        }

        else if (song2.isPlaying)
        {
            currentSong = song2;
        }

        else if (song3.isPlaying)
        {
            currentSong = song3;
        }

        if (currentSong == null)
        {
            yield break;
        }

        float startVolume = currentSong.volume;

        while (currentSong.volume > 0)
        {
            currentSong.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        currentSong.Stop();
        currentSong.volume = startVolume;
    }

    IEnumerator PlayMusicPlaylist()
    {
        song1.Play();

        yield return new WaitForSeconds(song1.clip.length - 2.0f);

        song2.Play();

        yield return new WaitForSeconds(song2.clip.length - 2.0f);

        song3.Play();
    }
}
