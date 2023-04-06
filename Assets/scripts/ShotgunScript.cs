using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : gunScript
{
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, -2f, 0);
        gun = GameObject.Find("shotgun").gameObject;
        gun.SetActive(true);
        bulletClone = bullet;
        gunPlace = gun.transform;
        singleBullet = false ;
    }

    private void Update()
    {
        if (gun.activeInHierarchy)
        {
            offset = new Vector3(0, 0, 0);
            cooldown = 30;
        }
    }

}
