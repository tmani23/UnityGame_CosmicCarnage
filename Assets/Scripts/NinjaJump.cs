using UnityEngine;

public class NinjaJump : MonoBehaviour
{
    public bool isOnGround = true;
    private Rigidbody enemyRb;
    public float gravityModifier;
    public float jumpForce = 10f;
    private float jumpDelay = 1f;
    private float jumpInterval = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        InvokeRepeating("Jump", jumpDelay, jumpInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void Jump()
    {
        if (isOnGround)
        {
            enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
}
