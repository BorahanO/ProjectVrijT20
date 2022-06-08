using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMech : MonoBehaviour
{

    public bool isOn = true;
    public GameObject lightSource;
    public AudioSource clickSound;

    public bool failSafe = false;


    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            

            if (isOn == false && failSafe == false)
            {
                failSafe = true;

                lightSource.SetActive(true);
                
                isOn = true;
                clickSound.Play();
                StartCoroutine(FailSafe());

                Debug.Log("FLASHLIGHT ON");
            }

            if (isOn == true && failSafe == false)
            {
                failSafe = true;

                lightSource.SetActive(false);
                isOn = false;
                clickSound.Play();
                StartCoroutine(FailSafe());

                Debug.Log("FLASHLIGHT OFF");
            }

        }
    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }
}
