using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector3 targetLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextPosition();
    }


    public void MoveToNextPosition()
    {
        if (this.transform.position != targetLocation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseLoc.y = 0f;
                print(mouseLoc);


                this.transform.Translate(mouseLoc);
            }
        }
    }
}
