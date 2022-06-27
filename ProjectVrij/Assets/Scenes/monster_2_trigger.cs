using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_2_trigger : MonoBehaviour
{
    public monster_2_scare script;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (!script.has_triggered && other.name == "player_body")
        {
            script.has_triggered = true;
            script.isTriggered = true;
            
        }
        if(other.tag == "monster")
        {

            StartCoroutine(timer());

        }

    }

    IEnumerator timer()
    {

        script.anim_scare_monster.SetInteger("moving", 4);
        script.flash_camera.SetActive(true);
        script.player.SetActive(false);
        script.flash_sound.Play();
        yield return new WaitForSeconds(0.75f);

        script.flash_camera.SetActive(false);
        script.player.SetActive(true);

        script.monster.SetActive(false);
    }
}
