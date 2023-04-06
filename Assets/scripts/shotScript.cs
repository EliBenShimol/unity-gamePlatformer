using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotScript : MonoBehaviour
{
    public float bulletSpeed;
    public static GameObject whoShot;
    public static GameObject bullet;
    public Color bulletColor;
    protected void shooting()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    public static string cameFrom()
    {
        return whoShot.name;
    }

    public static void toFar(GameObject shooter, GameObject bull, bool destroyed)
    {
        if (bull != null)
        {
            float distance1 = (shooter.transform.position.x - bull.transform.position.x) * (shooter.transform.position.x - bull.transform.position.x) +
                (shooter.transform.position.y - bull.transform.position.y) * (shooter.transform.position.y - bull.transform.position.y);
            float distance = Mathf.Sqrt(distance1)-15f;
            if (distance > 0)
            {
                Destroy(bull);
                destroyed = true;
            }
        }

    }


}
