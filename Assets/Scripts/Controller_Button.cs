using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Button : MonoBehaviour
{
    public float jumpVelocity;
    public float charSpeed;
    public Camera_Follow cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            // Move("Up");
            this.transform.Translate(new Vector3(0f, 0f, charSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move("Down");
            this.transform.Translate(new Vector3(0f, 0f, -charSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //  Move("Left");
            this.transform.Translate(new Vector3(-charSpeed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move("Right");
            this.transform.Translate(new Vector3(charSpeed * Time.deltaTime, 0f, 0f));
        }
    }
    public void Jump()
    { 
        this.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpVelocity, 0f);
    }

    
}
