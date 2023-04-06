using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public static Transform target;
    public float speed = 1f;


    private void Start()
    {
        transform.position= new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }


}
