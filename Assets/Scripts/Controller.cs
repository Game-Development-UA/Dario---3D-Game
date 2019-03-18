using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Click_Controller clickPlane;
    public Vector3 targetLocation;
    public Camera_Follow cam;
    private Vector3 startPosition;
    private float timeVal;
    public float jumpVelocity;
    public float charSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        targetLocation = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextPosition();
        Jump();
    }

    public void MoveToNextPosition()
    {
        if (!cam.viewMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPosition = this.transform.position;
                timeVal = 0f;
                clickPlane.GetNextLocation();
                targetLocation = clickPlane.targetLocation;
                targetLocation.y += 0.5f;
                //mouseLoc.y = 0f;
                print(targetLocation);
            }
            if (this.transform.position != targetLocation)
            {
                Interpolate();
            }
        }
    }

    public void Interpolate()
    {
        if (timeVal <= 1f)
        {
            float f = (Mathf.Pow(timeVal, 2) * (3f - (2f * timeVal)));
            this.transform.position = (1 - f) * startPosition + f * targetLocation;
            timeVal += Time.deltaTime * charSpeed;
        }
        else
        {
            this.transform.position = targetLocation;
            startPosition = targetLocation;
            timeVal = 0f;
        }
    }

    public void Jump()
    {

    }

    }
