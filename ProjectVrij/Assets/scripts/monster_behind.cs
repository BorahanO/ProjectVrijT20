using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_behind : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z-3f));

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Debug.Log(objectHit.name);

            // Do something with the object that was hit by the raycast.
        }
    }
}
