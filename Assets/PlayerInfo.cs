using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] health;
    public bool[] Collectibles = new bool[4];
    void Start()
    {
        Collectibles[0] = false;
        Collectibles[1] = false;
        Collectibles[2] = false;
        Collectibles[3] = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
