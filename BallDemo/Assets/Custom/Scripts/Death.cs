using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;

    private Animator anim;
    private AudioSource playerAudio;
    private ThirdPersonUserControl playerMovement;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponents<AudioSource>()[0];
        playerMovement = GetComponent<ThirdPersonUserControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(DelayedRestart());
    }

    IEnumerator DelayedRestart()
    {
        playerMovement.enabled = false;
        anim.SetTrigger("Dead");
        playerAudio.Play();
        GameOverUI.GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds(5);
        GameOverUI.GetComponent<Canvas>().enabled = false;
        RestartLevel();
    }

    public void RestartLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    
}
