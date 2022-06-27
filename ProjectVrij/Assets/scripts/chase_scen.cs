using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_scen : MonoBehaviour
{
    public float min_speed = 0.3f;
    public float speed_add = 0f;
    public int run_anim = 0;


    public bool has_prev_chase;
    public GameObject prev_chase;
    public GameObject current_chase;
    public Transform end_position;
    public GameObject player;
    public GameObject monster;
    public bool isTriggered = false;
    public bool has_triggered = false;

    public AudioSource chase_music;

    public Animator anim_movement;
    public Animator anim_body;

    private float monster_speed = 1f;

    public AudioSource monster_noise;


    // Start is called before the first frame update
    void Start()
    {
        //current_chase.SetActive(false);
        anim_body.SetInteger("battle", run_anim);
        anim_body.SetInteger("moving", 1); //walk/run/moving
        //anim_body.SetInteger("moving", 15);

        anim_body.speed = 1f;
        anim_movement.speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {


        float dist_player = Vector3.Distance(end_position.position, player.transform.position);
        float dist_monster = Vector3.Distance(end_position.position, monster.transform.position);
        float rel_dist = dist_monster - dist_player;
        //Debug.Log("Distance to player: " + dist_player);
        //Debug.Log("Distance to monster: " + dist_monster);

        if (isTriggered)
        {
            anim_movement.SetTrigger("box");
            Debug.Log("speed: " + anim_movement.speed);
            if(rel_dist < 6f)
            {
                //monster_speed = 0.1f;
                anim_body.speed = min_speed;
                anim_movement.speed = min_speed;
            }
            else if(rel_dist > 12f)
            {
                anim_movement.speed = 1.4f;
                anim_body.speed = 1.4f + 0.3f;
            }
            else
            {
                anim_body.speed = (-((-rel_dist + 12f) / 5.5f)) + 1.4f + 0.3f + speed_add;
                anim_movement.speed = (-((-rel_dist + 12f) / 5.5f)) + 1.4f + speed_add;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (!has_triggered && other.name == "player_body")
        {
            if (has_prev_chase)
            {
                prev_chase.SetActive(false);
            }
            
            current_chase.SetActive(true);
            monster_noise.Play();
            anim_body.SetInteger("battle", run_anim);
            anim_body.SetInteger("moving", 1); //walk/run/moving
            has_triggered = true;
            isTriggered = true;
            if (!chase_music.isPlaying)
            {
                chase_music.Play();
            }

        }


    }
}
