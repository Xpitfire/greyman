using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnitySampleAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject exitText;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject player;
    
    private Button startButton;
    private Button exitButton;
    private Canvas controlsCanvas;
    private Canvas hudCanvas;
    private ThirdPersonUserControl playerControls;

    private static Menu instance = null;

    public static Menu Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        playerControls = player.GetComponent<ThirdPersonUserControl>();
        controlsCanvas = controls.GetComponent<Canvas>();
        hudCanvas = hud.GetComponent<Canvas>();
        startButton = startText.GetComponent<Button>();
        exitButton = exitText.GetComponent<Button>();

        playerControls.MenuEnabled = true;
        controlsCanvas.enabled = false;
        hudCanvas.enabled = false;
    }
    
    public void StartLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        ResumeGame();
    }

    public void PauseGame()
    {
        playerControls.MenuEnabled = true;
        controlsCanvas.enabled = false;
        hudCanvas.enabled = false;
        GetComponent<Canvas>().enabled = true;
    }

    public void ResumeGame()
    {
        playerControls.MenuEnabled = false;
        controlsCanvas.enabled = true;
        hudCanvas.enabled = true;
        GetComponent<Canvas>().enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
