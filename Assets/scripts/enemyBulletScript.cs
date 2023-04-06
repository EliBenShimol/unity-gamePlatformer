using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : shotScript
{
    public GameObject enemy;
    void Start()
    {
        whoShot = enemy;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shooting();

    }
}
