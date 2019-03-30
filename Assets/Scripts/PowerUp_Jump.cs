using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision Coll) {


        Coll.gameObject.GetComponent<Jump>().jumpVelocity = 1.5f * Coll.gameObject.GetComponent<Jump>().jumpVelocity;
        Coll.gameObject.GetComponent<Jump>().jumpPowerUp = true;

        Destroy(this.gameObject);

    }
}
