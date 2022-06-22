using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_falling : MonoBehaviour
{

    public bool isTriggered = false;
    private bool has_been_triggered = false;

    public AudioSource rock_sound;
    public AudioSource scare_sound;
    public GameObject[] rocks;

    public Transform camTransform;
    public float shakeAmount = 0.05f;
    public float decreaseFactor = 1.0f;
    public float shakeDuration = 1f;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject rock in rocks)
        {
            rock.SetActive(false);
        }
        originalPos = camTransform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && !has_been_triggered)
        {
            
            foreach (GameObject rock in rocks)
            {
                rock.SetActive(true);
            }
            rock_sound.Play();
            scare_sound.Play();
            
            has_been_triggered = true;


        }
        if (isTriggered) { 
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {

                isTriggered = false;
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Name of the object: " + other.gameObject.name);
        if (other.gameObject.name == "player_body")
            isTriggered = true;


    }


}
