using UnityEngine;

public class CharacterWalkingAnimation : MonoBehaviour
{
    public Transform leftArm;
    public Transform rightArm;
    public Transform leftLeg;
    public Transform rightLeg;

    public bool animateRightArm;

    public float rotationSpeed = 10f;
    public float currentAngle;

    private SpawnManager spawnManager;
    
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive == true)
        {
            float t = Time.time * rotationSpeed;

            currentAngle = Mathf.Sin(t) * 50;

            leftArm.localRotation = (Quaternion.Euler(currentAngle, 0, 0));
            leftLeg.localRotation = (Quaternion.Euler(-currentAngle, 0, 0));
            rightLeg.localRotation = (Quaternion.Euler(currentAngle, 0, 0));

            if (animateRightArm)
            {
                rightArm.localRotation = (Quaternion.Euler(-currentAngle, 0, 0));
            }
        }
    }
}
