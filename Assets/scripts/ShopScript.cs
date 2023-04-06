using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{
    public static Queue<gunScript> gunsForSale;
    public Sprite arImage;
    public Sprite pistolImage;
    public Sprite shotgunImage;
    public Image slot0;
    public Image slot1;
    public Queue<Button> shopItems=new Queue<Button>();
    public ItemScript itemButton;
    private float xCord = 100f;
    private float yCord = 60f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManegment.instace.playerGuns[0].Equals("ar"))
            slot0.transform.Find("weaponImage0").GetComponent<Image>().sprite = arImage;
        else if (GameManegment.instace.playerGuns[0].Equals("pistol"))
            slot0.transform.Find("weaponImage0").GetComponent<Image>().sprite = pistolImage;
        else if (GameManegment.instace.playerGuns[0].Equals("shotgun"))
            slot0.transform.Find("weaponImage0").GetComponent<Image>().sprite = shotgunImage;
        if (GameManegment.instace.playerGuns[1].Equals("ar"))
            slot1.transform.Find("weaponImage1").GetComponent<Image>().sprite = arImage;
        else if (GameManegment.instace.playerGuns[1].Equals("pistol"))
            slot1.transform.Find("weaponImage1").GetComponent<Image>().sprite = pistolImage;
        else if (GameManegment.instace.playerGuns[1].Equals("shotgun"))
            slot1.transform.Find("weaponImage1").GetComponent<Image>().sprite = shotgunImage;
        gunsForSale = new Queue<gunScript>();
        int count = GameManegment.instace.guns.Count;
        while (count > 0)
        {
            gunScript add = GameManegment.instace.guns.Dequeue();
            GameManegment.instace.guns.Enqueue(add);
            gunsForSale.Enqueue(add);
            count--;
        }
        while (gunsForSale.Count > 0)
        {
            string name = gunsForSale.Dequeue().name;
            ItemScript createdButton = Instantiate(itemButton);
            Button buyHeart = GameObject.Find("extraLives").GetComponent<Button>();
            createdButton.transform.SetParent(buyHeart.transform.parent);
            createdButton.transform.position = buyHeart.transform.position - new Vector3(xCord, yCord, 0);
            xCord -= 100f;
            createdButton.name = name;
            createdButton.s = this;
            createdButton.arImage = arImage;
            createdButton.pistolImage = pistolImage;
            createdButton.shotgunImage = shotgunImage;
            Text t = GameObject.Find(name).GetComponentInChildren<Text>();
            t.text = name;
            createdButton.onClick.AddListener(createdButton.buyGun);
            shopItems.Enqueue(createdButton);
        }

        slot0.color = Color.green;
        slot1.color = Color.white;
        GameManegment.instace.slot = 0;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot0.color = Color.green;
            slot1.color = Color.white;
            GameManegment.instace.slot = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot0.color = Color.white;
            slot1.color = Color.green;
            GameManegment.instace.slot = 1;
        }
    }

}
