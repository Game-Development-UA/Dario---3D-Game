﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerToReset;
    public Vector3 resetPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player")
        {
            playerToReset.transform.position = resetPosition;
        }
    }
}
