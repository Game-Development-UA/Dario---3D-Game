using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpVelocity, 0f);
        }
        print(this.GetComponent<Rigidbody>().velocity);
    }
}
