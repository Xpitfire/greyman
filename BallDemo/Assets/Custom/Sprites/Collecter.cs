using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(AudioSource))]
public class Collecter : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private ThirdPersonCharacter character;
    private Behaviour glow;
    private AudioSource audio;

    void Start()
    {
        glow = (Behaviour)GetComponent("Halo");
        playerHealth = GetComponent<PlayerHealth>();
        character = GetComponent<ThirdPersonCharacter>();
        audio = GetComponents<AudioSource>()[1];
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            CollectItem(other);
            ScoreManager.Score += 1;
        }

        if (other.gameObject.CompareTag("LifeUp"))
        {
            CollectItem(other);
            playerHealth.RestoreLife();
        }

        if (other.gameObject.CompareTag("PowerUpJump"))
        {
            CollectItem(other);
            character.JumpPower = 15;
            glow.enabled = true;
            StartCoroutine(StopSuperJumpMode());
        }
    }

    IEnumerator StopSuperJumpMode()
    {
        yield return new WaitForSeconds(40);
        for (var i = 0; i < 50; i++)
        {
            glow.enabled = false;
            yield return new WaitForSeconds(0.2f);
            glow.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        glow.enabled = false;
        character.JumpPower = 10;
    }

    void CollectItem(Collider other)
    {
        other.gameObject.SetActive(false);
        audio.Play();
    }
}
