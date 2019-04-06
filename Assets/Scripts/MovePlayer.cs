using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Direction;
    public GameObject Player;
    public float platSpeed;
    public bool playerOn;
    
    void Start()
    {
        playerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOn)
        {
            TranslatePlayer();
        }
    }

    public void OnCollisionEnter(Collision col) {
        col.gameObject.GetComponent<Controller_Button>().stuckToPlat = true;
        col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        
        playerOn = true;
        print("playerOn: " + playerOn);
        //Player = col.gameObject;
    }
    public void TranslatePlayer() {
        Player.transform.Translate(new Vector3(Direction.x * Time.deltaTime * platSpeed, Direction.y * Time.deltaTime * platSpeed, Direction.z * Time.deltaTime * platSpeed));
    }

    public void OnCollisionExit(Collision col) {
        col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        playerOn = false;
        col.gameObject.GetComponent<Controller_Button>().stuckToPlat = false;
    }
  
}
