using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_sounds : MonoBehaviour
{
    public AudioSource sound;
    private bool has_triggered;



    private void OnTriggerEnter(Collider other)
    {
        if (!has_triggered && other.name == "player_body")
        {
            has_triggered = true;
            sound.Play();

        }

    }
}
