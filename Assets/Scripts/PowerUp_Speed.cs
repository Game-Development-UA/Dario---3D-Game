using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision Coll)
    {


        Coll.gameObject.GetComponent<Controller_Button>().charSpeed = 1.5f * Coll.gameObject.GetComponent<Controller_Button>().charSpeed;
        Coll.gameObject.GetComponent<Controller_Button>().speedPowerUp = true;

        Destroy(this.gameObject);

    }
}
