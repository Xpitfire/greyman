using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject player;
    
    private Canvas controlsCanvas;
    private Canvas hudCanvas;
    private ThirdPersonUserControl playerControls;
    
    // Use this for initialization
    void Start()
    {
        playerControls = player.GetComponent<ThirdPersonUserControl>();
        controlsCanvas = controls.GetComponent<Canvas>();
        hudCanvas = hud.GetComponent<Canvas>();

        PauseGame();
    }
    
    public void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResumeGame();
    }

    public void PauseGame()
    {
        foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            e.GetComponent<EnemyMovement>().MenuEnabled = true;
        }
        playerControls.MenuEnabled = true;
        controlsCanvas.enabled = false;
        hudCanvas.enabled = false;
    }

    public void ResumeGame()
    {
        foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            e.GetComponent<EnemyMovement>().MenuEnabled = false;
        }
        playerControls.MenuEnabled = false;
        controlsCanvas.enabled = true;
        hudCanvas.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
