using UnityEngine;

public class GroundMoveForward : MonoBehaviour
{
    private SpawnManager spawnManager;
    public float speed = 40.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
