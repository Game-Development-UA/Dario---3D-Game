using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Click_Controller : MonoBehaviour
{

    public Vector3 targetLocation;
    private Plane plane; 

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetLocation = new Vector3(0f, 0f, 0f);
        plane = new Plane(Vector3.up, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetNextLocation() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                targetLocation = ray.GetPoint(distanceToPlane);
            }
            
        }
       
    }
}
