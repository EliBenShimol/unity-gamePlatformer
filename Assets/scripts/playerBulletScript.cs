using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletScript :shotScript
{
    // Start is called before the first frame update
    public static GameObject player;
    void Start()
    {
        whoShot = player;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shooting();
        
    }
}
