using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] health;
    public bool[] Collectibles = new bool[3];
    public Image[] UIImages = new Image[3];
    public Sprite Collected;
    public Sprite UIImage;
    void Start()
    {
        Collectibles[0] = false;
        Collectibles[1] = false;
        Collectibles[2] = false;
     

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateUI(int num) {
        print("We in there, doug");
        Collectibles[num] = true;
        UIImages[num].overrideSprite = Collected;
        //GameObject.Find("Collectible " + (num + 1)).GetComponent<UnityEngine.UI.Image>().overrideSprite = Collected;
        

    }
}
