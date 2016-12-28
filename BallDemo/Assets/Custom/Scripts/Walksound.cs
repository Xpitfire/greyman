using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Walksound : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var audio = GetComponents<AudioSource>()[2]; // footsteps
        if (IsGrounded && GetComponent<Rigidbody>().velocity.magnitude > 2f && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.4f, 0.7f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
    }

    bool IsGrounded;

    void OnCollisionStay(Collision collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
    }
}
