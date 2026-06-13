using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public float currentAngle;
    public float time = 1;
    private SpawnManager spawnManager;
    public Light flashlight;
    public AudioClip FlashSound;
    private AudioSource FlashAudio;
    private bool flashLightOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAngle = 50f;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        FlashAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAngle >= 170 && currentAngle <= 360)
        {
            if (!flashLightOn)
            { 
                FlashAudio.PlayOneShot(FlashSound);
                flashLightOn = true;
            }

            flashlight.gameObject.SetActive(true);
        }

        else
        {
            if (flashLightOn)
            {
                FlashAudio.PlayOneShot(FlashSound);
                flashLightOn = false;
            }

            flashlight.gameObject.SetActive(false);
        }


        if (spawnManager.isGameActive == true)  
        {
            currentAngle += (rotationSpeed * Time.deltaTime);
            currentAngle = Mathf.Repeat(currentAngle, 360f);

            transform.rotation = Quaternion.Euler(currentAngle, 0, 0);
        }
    }

    
}
