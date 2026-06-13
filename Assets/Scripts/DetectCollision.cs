using UnityEngine;


public class DetectCollision : MonoBehaviour
{
    private SpawnManager spawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (spawnManager.isGameActive)
        {
            if (other.CompareTag("Car"))
            {
                Destroy(gameObject);
            }

            if (other.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                spawnManager.UpdateScore(other.GetComponent<ScoreValue>().scoreAmount);
            }
        }
    }
}
