using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Direction;
    public GameObject Player;
    public float platSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void OnTriggerEnter(Collider col) {
        col.gameObject.GetComponent<Controller_Button>().stuckToPlat = true;
        col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        Player = col.gameObject;
    }
    public void MovePlayer() {
        Player.transform.translate(new Vector3(Direction.x * Time.deltaTime * platSpeed, Direction.y * Time.deltaTime * platSpeed, Direction.z * Time.deltaTime * platSpeed));
    }

    public void OnTriggerExit(Collider col) {
        col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
    }
}
