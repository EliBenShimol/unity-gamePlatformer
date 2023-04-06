using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject player;
    protected  GameObject gun;
    public static Transform gunPlace;
    public GameObject bullet;
    public static GameObject bulletClone;
    protected static Vector3 offset;
    public static bool isActive;
    public static int cooldown;
    public static bool singleBullet;
    void FixedUpdate()
    {
        gunPlace = gun.transform;
        Vector3 camPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                   Camera.main.ScreenToWorldPoint(Input.mousePosition).y, player.transform.position.z); 
        Vector2 direct = camPos - player.transform.position;
        float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
        Quaternion ang = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = ang;
        Vector3 charScale = gun.transform.localScale;
        if (direct.x < 0f)
        {
            gun.transform.position = player.transform.position + new Vector3(-0.5f, 0, player.transform.position.z);
            if(charScale.y > 0)
                charScale.y = -1*charScale.y;
            gun.transform.localScale = charScale;
        }
        else
        {
            gun.transform.position = player.transform.position + new Vector3(0.5f, 0, player.transform.position.z);
            if (charScale.y <0)
                charScale.y = -1 * charScale.y;
            gun.transform.localScale = charScale;
        }


    }


    public static Queue<GameObject> shooting(Quaternion ang)
    {
        Queue<GameObject> bullets = new Queue<GameObject>();
        if (singleBullet)
        {
            GameObject bull = Instantiate(bulletClone);
            bull.transform.position = gunPlace.position + offset;
            bull.SetActive(true);
            bull.transform.rotation = ang;
            bullets.Enqueue(bull);
        }
        else
        {
            GameObject bull1 = Instantiate(bulletClone);
            GameObject bull2 = Instantiate(bulletClone);
            GameObject bull3 = Instantiate(bulletClone);
            bull1.transform.position = gunPlace.position + offset;
            bull1.SetActive(true);
            bull2.transform.position = gunPlace.position + offset;
            bull2.SetActive(true);
            bull3.transform.position = gunPlace.position + offset;
            bull3.SetActive(true);
            bull1.transform.rotation = ang;
            if (ang.w > 0.2f && ang.w < 0.9f)
            {
                bull2.transform.rotation = new Quaternion(ang.x, ang.y, ang.z, ang.w + 0.2f);
                bull3.transform.rotation = new Quaternion(ang.x, ang.y, ang.z, ang.w - 0.2f);
            }
            else if(!(ang.w > 0.2f))
            {
                bull2.transform.rotation = new Quaternion(ang.x, ang.y, ang.z, ang.w+0.2f);
                bull3.transform.rotation = new Quaternion(ang.x, ang.y, ang.z, ang.w - 0.2f);
                Debug.Log(ang.w + 0.2f);
            }
            else if(!(ang.w < 0.9f))
            {
                bull2.transform.rotation = new Quaternion(ang.x, ang.y, ang.z+0.1f, ang.w - 0.2f);
                bull3.transform.rotation = new Quaternion(ang.x, ang.y, ang.z-0.1f, ang.w + 0.2f);
                Debug.Log(ang.w - 0.2f);
            }

            bullets.Enqueue(bull1);
            bullets.Enqueue(bull2);
            bullets.Enqueue(bull3);
        }
        return bullets;

    }

    public static void getPlayer(GameObject go)
    {
        player = go;
    }
}
