using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool jumpPowerUp;
    public float jumpVelocity;
    public float fallMultiplier;
    private bool inAir;
    private float fallTime;
    public float slowFallLimit;
    private float fastFall;
    // Start is called before the first frame update
    void Start()
    {
        inAir = false;
        fallTime = 0f;
        fastFall = 0f;
        jumpPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!inAir)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpVelocity, 0f);
                inAir = true;
            }
            
        }
        if (inAir)
        {
            if (this.GetComponent<Rigidbody>().velocity.y < 0)
            {
                fallTime += Time.deltaTime; 
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f, Physics.gravity.y * fallMultiplier * Time.deltaTime, 0f);
                if (fallTime > slowFallLimit) {
                    fastFall += Physics.gravity.y * Time.deltaTime;
                    this.GetComponent<Rigidbody>().velocity = new Vector3(0f, fastFall, 0f);
                }

            }
        }
       
        //print(this.GetComponent<Rigidbody>().velocity.y);
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "floor") {
            this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0f, this.GetComponent<Rigidbody>().velocity.z);
            inAir = false;
            fallTime = 0f;
        }
        else if (collision.gameObject.tag == "platform") {
            this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0f, this.GetComponent<Rigidbody>().velocity.z);
            inAir = false;
        }

    }
}
