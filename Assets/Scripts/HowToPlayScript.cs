using UnityEngine;
using UnityEngine.UI;

public class HowToPlayScript : MonoBehaviour
{
    public Button HTPButton;
    public Button ControlsButton;
    public Button InstructionsButton;
    public Button HTPBackButton;
    public Button ControlsBackButton;
    public Button InstructionsBackButton;

    public GameObject ControlsText;
    public GameObject InstructionsText;
    public GameObject titleScreen;

    private GameObject mainCamera;
    public Vector3 cameraPos;
    public float rotationSpeed = 2.0f;
    private Quaternion targetRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        HTPButton.onClick.AddListener(HowToPlay);
        ControlsButton.onClick.AddListener(Controls);
        InstructionsButton.onClick.AddListener(Instructions);

        HTPBackButton.onClick.AddListener(MainMenu);
        ControlsBackButton.onClick.AddListener(HowToPlay);
        InstructionsBackButton.onClick.AddListener(HowToPlay);

        mainCamera = GameObject.FindWithTag("MainCamera");

        targetRotation = mainCamera.transform.rotation;

        cameraPos = new Vector3(40, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainMenu()
    {
        titleScreen.gameObject.SetActive(true);
        HTPBackButton.gameObject.SetActive(false);

        ControlsButton.gameObject.SetActive(false);
        ControlsText.gameObject.SetActive(false);
        ControlsButton.gameObject.SetActive(false);

        InstructionsButton.gameObject.SetActive(false);
        InstructionsText.gameObject.SetActive(false);
        InstructionsBackButton.gameObject.SetActive(false);


        mainCamera.transform.rotation = (Quaternion.Euler(cameraPos));
    }
    void HowToPlay()
    {
        ControlsButton.gameObject.SetActive(true);
        ControlsBackButton.gameObject.SetActive(false);
        ControlsText.gameObject.SetActive(false);

        InstructionsButton.gameObject.SetActive(true);
        InstructionsText.gameObject.SetActive(false);
        InstructionsBackButton.gameObject.SetActive(false);

        HTPBackButton.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        
        
        

        mainCamera.transform.rotation = (Quaternion.Euler(cameraPos));


    }

    void Controls()
    {
        ControlsButton.gameObject.SetActive(false);
        ControlsText.gameObject.SetActive(true);
        ControlsBackButton.gameObject.SetActive(true);

        InstructionsButton.gameObject.SetActive(false);

        HTPBackButton.gameObject.SetActive(false);
        

        mainCamera.transform.rotation = (Quaternion.Euler(-40, 0, 0));
    }

    void Instructions()
    {
        InstructionsText.gameObject.SetActive(true);
        InstructionsButton.gameObject.SetActive(false);
        InstructionsBackButton.gameObject.SetActive(true);

        HTPBackButton.gameObject.SetActive(false);

        ControlsButton.gameObject.SetActive(false);
        ControlsText.gameObject.SetActive(false);

        mainCamera.transform.rotation = (Quaternion.Euler(-40, 0, 0));
    }
}
