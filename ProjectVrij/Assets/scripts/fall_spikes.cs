using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_spikes : MonoBehaviour
{

    public GameObject[] spikes;
    public AudioSource spike_falling;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spike in spikes)
        {
            spike.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Name of the object: " + other.gameObject.name);
        if (other.gameObject.name == "player_body")
        {
            spike_falling.Play();
            StartCoroutine(timer());
            


            

        }

    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.9f);
        spike_fall();

    }
    private void spike_fall()
    {
        foreach (GameObject spike in spikes)
        {
            spike.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
