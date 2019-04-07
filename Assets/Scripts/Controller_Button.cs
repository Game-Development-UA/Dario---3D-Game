using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Button : MonoBehaviour
{
  
    public float charSpeed;
    public bool stuckToPlat;
    public bool speedPowerUp;
    
    public Camera_Follow cam;
    // Start is called before the first frame update
    void Start()
    {
        speedPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(0f, 90f * Time.deltaTime, 0f);
        if (!cam.viewMode)
        {
            if (!stuckToPlat)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    // Move("Up");
                    if (cam.camDirection == "Forward")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, charSpeed * Time.deltaTime));
                    }
                    else if (cam.camDirection == "Right")
                    {
                        this.transform.Translate(new Vector3(charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Left")
                    {
                        this.transform.Translate(new Vector3(-charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Back")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, -charSpeed * Time.deltaTime));
                    }

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //Move("Down");
                    //this.transform.Translate(new Vector3(0f, 0f, -charSpeed * Time.deltaTime));
                    if (cam.camDirection == "Forward")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, -charSpeed * Time.deltaTime));
                    }
                    else if (cam.camDirection == "Right")
                    {
                        this.transform.Translate(new Vector3(-charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Left")
                    {
                        this.transform.Translate(new Vector3(charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Back")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, charSpeed * Time.deltaTime));
                    }
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    //  Move("Left");
                    // this.transform.Translate(new Vector3(-charSpeed * Time.deltaTime, 0f, 0f));
                    if (cam.camDirection == "Forward")
                    {
                        this.transform.Translate(new Vector3(-charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Back")
                    {
                        this.transform.Translate(new Vector3(charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Right")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, charSpeed * Time.deltaTime));
                    }
                    else if (cam.camDirection == "Left")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, -charSpeed * Time.deltaTime));
                    }
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    // Move("Right");
                    //this.transform.Translate(new Vector3(charSpeed * Time.deltaTime, 0f, 0f));
                    if (cam.camDirection == "Forward")
                    {
                        this.transform.Translate(new Vector3(charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    if (cam.camDirection == "Back")
                    {
                        this.transform.Translate(new Vector3(-charSpeed * Time.deltaTime, 0f, 0f));
                    }
                    else if (cam.camDirection == "Right")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, -charSpeed * Time.deltaTime));
                    }
                    else if (cam.camDirection == "Left")
                    {
                        this.transform.Translate(new Vector3(0f, 0f, charSpeed * Time.deltaTime));
                    }
                }

            }
        }
    }
   

    
}
