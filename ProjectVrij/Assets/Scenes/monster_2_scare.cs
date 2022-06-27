using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class monster_2_scare : MonoBehaviour
{

    private Animator anim;

    

    public GameObject monster;
    private CharacterController controller;
    private int battle_state = 0;
    public float speed = 6.0f;
    public float runSpeed = 3.0f;
    public float turnSpeed = 60.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    private float w_sp = 0.0f;
    private float r_sp = 0.0f;

    public bool isTriggered = false;
    public bool has_triggered = false;

    public AudioSource scare_sound;


    public Animator anim_scare_monster;
    public AudioSource flash_sound;
    public GameObject flash_camera;
    public GameObject player;

    public Animator monster_walk;
    public Animation monster_walk_anim;



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        w_sp = speed; //read walk speed
        r_sp = runSpeed; //read run speed
        battle_state = 0;
        runSpeed = 1;

        anim.SetInteger("battle", 1);
        battle_state = 1;
        runSpeed = r_sp;
        anim.SetInteger("moving", 15);
        anim_scare_monster.SetInteger("battle", 1);
        anim_scare_monster.SetInteger("moving", 0);


        flash_camera.SetActive(false);
        player.SetActive(true);

        monster_walk.SetBool("has_triggered_anim", false);

    }


    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("battle", 1);

        moveDirection.y -= gravity * Time.deltaTime;
        //controller.Move(moveDirection * Time.deltaTime);

        if (isTriggered)
        {
            moveDirection = transform.forward * speed * runSpeed;
            monster_walk.SetBool("has_triggered_anim", true);
            monster_walk.SetTrigger("box");
            anim.SetInteger("moving", 1);//walk/run/moving

            scare_sound.Play();
            Debug.Log(scare_sound.isPlaying);
            isTriggered = false;

        }
    }





}
