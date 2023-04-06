using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arScript : gunScript
{
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, -2f, 0);
        gun = GameObject.Find("ar").gameObject;
        gun.SetActive(true);
        bulletClone = bullet;
        gunPlace = gun.transform;
        singleBullet = true;
    }

    private void Update()
    {
        if (gun.activeInHierarchy)
        {
            offset = new Vector3(0, 0, 0);
            cooldown = 10;
        }
    }

}
