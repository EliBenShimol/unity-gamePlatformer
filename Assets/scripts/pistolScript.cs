using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolScript : gunScript
{
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0.15f, 0);
        gun = GameObject.Find("pistol").gameObject;
        gun.SetActive(true);
        bulletClone = bullet;
        gunPlace = gun.transform;
        cooldown = 20;
        singleBullet = true;

    }

    private void Update()
    {
        if (gun.activeInHierarchy)
        {
            offset = new Vector3(0, 0.15f, 0);
            cooldown = 25;
        }
    }

}
