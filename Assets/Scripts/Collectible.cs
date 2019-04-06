using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public int CollectibleNum;


    public void OnTriggerEnter(Collider Coll)
    {


        Coll.gameObject.GetComponent<PlayerInfo>().UpdateUI(CollectibleNum);
        if (Coll.gameObject.GetComponent<PlayerInfo>().Collectibles[CollectibleNum]) {
            Destroy(this.gameObject);
        }
    }


}
