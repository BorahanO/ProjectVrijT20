using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_1_trigger : MonoBehaviour
{
    public monster_1_scare script;
    public bool has_triggered = false;
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
        if (!has_triggered)
        {
            //Debug.Log("Name of the object: " + other.gameObject.name);
            script.isTriggered = true;
            has_triggered = true;
        }

    }
}
