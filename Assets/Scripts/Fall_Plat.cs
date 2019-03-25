using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Plat : MonoBehaviour
{
    private bool Fall;
    private float fallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Fall = false;
        fallSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fall) {
            this.transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
            fallSpeed += Time.deltaTime;
            if (fallSpeed > 4f) {
                print("Destroyed");
                Destroy(this.gameObject);
                
            }
        }
    }

    public void OnCollisionExit(Collision coll) {
        Fall = true;
    }
}
