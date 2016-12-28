using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Finish : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            var finishedMenu = GameObject.FindGameObjectWithTag("Finish");
            finishedMenu.GetComponent<Canvas>().enabled = true;

            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<ThirdPersonUserControl>().MenuEnabled = true;
        }
    }
}
