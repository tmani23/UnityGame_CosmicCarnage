using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour   
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 17;
    public float zRangeForward = 9;
    public float zRangeBackward = -14;
    public Transform firePoint;
    public GameObject projectilePrefab;
    private Rigidbody playerRb;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public int maxHealth = 3;
    public int currentHealth;
    private SpawnManager spawnManager;
    public GameObject lazar;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image dead;
    public AudioClip shootSound;
    public AudioClip dieSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -9.8f * gravityModifier, 0);

        currentHealth = maxHealth;

        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > 0 && spawnManager.isGameActive == true)
        {
            // Prevents the player from moving out of bound in the -x position
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            // Prevents the player from moving out of bound in the x position
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            // Prevents the player from moving out of bound in the z position
            if (transform.position.z > zRangeForward)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRangeForward);
            }

            // Prevents the player from moving out of bound in the z position
            if (transform.position.z < zRangeBackward)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRangeBackward);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
               playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
               isOnGround = false;
               playerAudio.PlayOneShot(jumpSound, 1.0f);
                
            }

            if (Input.GetMouseButtonDown(0))
            {
                // Launch a projectile from player
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                playerAudio.PlayOneShot(shootSound, 1.0f);
            }

            if (Input.GetMouseButton(1))
            {
                lazar.SetActive(true);  
            }

            else
            {
                lazar.SetActive(false);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        

        if (collision.gameObject.CompareTag("Obstacle"))
        {      
            Destroy(collision.gameObject);
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        
        UpdateHearts();

        if (currentHealth <= 0)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + 1, transform.position.z);
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            playerAudio.PlayOneShot(dieSound, 1.0f);
            spawnManager.GameOver();
            dead.gameObject.SetActive(true);
            
   
        }
    }

    private void UpdateHearts()
    {
        heart3.gameObject.SetActive(currentHealth >= 3);
        heart2.gameObject.SetActive(currentHealth >= 2);
        heart1.gameObject.SetActive(currentHealth >= 1);
    }

}
