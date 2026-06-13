using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] spawnCarPrefabs;
    public int spawnIndex;
    private float spawnRangeX = 17;
    private float spawnPosZ = 30;
    private float startDelay = 2;
    private float spawnInterval = 15.0f;
    private SpawnManager spawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", startDelay, spawnInterval);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomPrefab()
    {
        if (spawnManager.isGameActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int spawnIndex = Random.Range(0, spawnCarPrefabs.Length);
            Instantiate(spawnCarPrefabs[spawnIndex], spawnPos, spawnCarPrefabs[spawnIndex].transform.rotation);
        }
    }
}
