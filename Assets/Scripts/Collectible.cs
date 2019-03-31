using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public int CollectibleNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider Coll)
    {


        Coll.gameObject.GetComponent<PlayerInfo>().Collectibles[CollectibleNum] = true;
        Destroy(this.gameObject);

    }
}
