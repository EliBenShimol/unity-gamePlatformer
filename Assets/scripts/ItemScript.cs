using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : Button
{
    // Start is called before the first frame update
    public ShopScript s;
    public Sprite arImage;
    public Sprite pistolImage;
    public Sprite shotgunImage;
    public void buyGun()
    {
        Debug.Log(this.name);
        GameManegment.instace.playerGuns[GameManegment.instace.slot] = this.name;
        if (GameManegment.instace.playerGuns[0].Equals("ar"))
            s.slot0.transform.Find("weaponImage0").GetComponent<Image>().sprite = arImage;
        else if (GameManegment.instace.playerGuns[0].Equals("pistol"))
            s.slot0.transform.Find("weaponImage0").GetComponent<Image>().sprite = pistolImage;
        else if (GameManegment.instace.playerGuns[0].Equals("shotgun"))
            s.slot0.transform.Find("weaponImage0").GetComponent<Image>().sprite = shotgunImage;
        if (GameManegment.instace.playerGuns[1].Equals("ar"))
            s.slot1.transform.Find("weaponImage1").GetComponent<Image>().sprite = arImage;
        else if (GameManegment.instace.playerGuns[1].Equals("pistol"))
            s.slot1.transform.Find("weaponImage1").GetComponent<Image>().sprite = pistolImage;
        else if (GameManegment.instace.playerGuns[1].Equals("shotgun"))
            s.slot1.transform.Find("weaponImage1").GetComponent<Image>().sprite = shotgunImage;
        Debug.Log(GameManegment.instace.playerGuns[0] + " " + GameManegment.instace.playerGuns[1]);
    }
}
