using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LayerMask clickMask;
    public Vector3 targetLocation;
    public Camera_Follow cam;
    private Vector3 startPosition;
    private float timeVal;
    public float charSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextPosition();
    }


    public void MoveToNextPosition()
    {
        if (!cam.viewMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPosition = this.transform.position;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 50f, clickMask))
                {
                    Vector3 mouseLoc = hit.point;
                    targetLocation = mouseLoc;
                }
                //mouseLoc.y = 0f;

            }
            if (this.transform.position != targetLocation)
            {
                Interpolate();
            }
        }
    }


    public void Interpolate() {

        if (timeVal <= 1f)
        {
            float f = (Mathf.Pow(timeVal, 2) * (3f - (2f * timeVal)));
            this.transform.position = (1 - f) * startPosition + f * targetLocation;
            timeVal += Time.deltaTime * charSpeed;
        }
        else {
            this.transform.position = targetLocation;
            startPosition = targetLocation;
            timeVal = 0f;
        }
    }
}
