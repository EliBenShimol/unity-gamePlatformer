using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject coin;
    public GameObject enemy;
    public GameObject player;
    public LayerMask groundLayer;
    public GameObject bullet;
    private Vector2 offSet = new Vector2(0.2f, 0.2f);
    // Start is called before the first frame update
    // Update is called once per frame
    int cooldown = 0;
    public Queue<GameObject> bullets = new Queue<GameObject>();
    void Start()
    {
        enemy.SetActive(true);
        player = GameObject.Find("player(Clone)");
    }

    void Update()
    {
        if (cooldown == 0 && distanceFromPlayer())
        {
            GameObject bull = Instantiate(bullet);
            Vector3 playerPos = player.transform.position;
            bull.transform.position = transform.position;
            bull.SetActive(true);
            Vector2 direct = playerPos - transform.position;
            float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            Quaternion ang = Quaternion.AngleAxis(angle, Vector3.forward);
            bull.transform.rotation = ang;
            enemyBulletScript.bullet = bull;
            bullets.Enqueue(bull);
            cooldown = 50;
        }


    }

    private bool distanceFromPlayer()
    {
        bool ans = true;
        float distance1 = (transform.position.x - player.transform.position.x) * (transform.position.x - player.transform.position.x) +
                (transform.position.y - player.transform.position.y) * (transform.position.y - player.transform.position.y);
        float distance = Mathf.Sqrt(distance1) - 15f;
        if (distance > 0)
        {
            ans = false;
        }
        return ans;
    }

    private void FixedUpdate()
    {
        int count = bullets.Count;
        while (count > 0)
        {
            bool destroyed = false;
            GameObject bul = bullets.Dequeue();
            if (bul != null)
            {
                if (!bul.activeInHierarchy)
                {
                    Destroy(bul);
                    destroyed = true;
                }
                shotScript.toFar(enemy, bul, destroyed);
                if (!destroyed)
                    bullets.Enqueue(bul);
            }
            count--;
        }

        if (cooldown > 0)
            cooldown--;
        if (distanceFromPlayer())
        {
            if (transform.position.y - 2f <= player.transform.position.y)
            {
                Vector3 direct = new Vector3(transform.position.x, transform.position.y, transform.position.z) - player.transform.position;
                transform.position -= direct * Time.deltaTime;
                if (transform.position.y < player.transform.position.y)
                {
                    transform.position += new Vector3(0, 5, 0) * Time.deltaTime;
                    if (transform.position.x < player.transform.position.x)
                        transform.position += new Vector3(0.5f, 0, 0) * Time.deltaTime;
                    else
                        transform.position += new Vector3(-0.5f, 0, 0) * Time.deltaTime;
                }
            }
        }
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("bullet"))
        {
            if (shotScript.cameFrom().Equals(player.name))
            {
                GameObject cur = Instantiate(coin);
                cur.transform.position = transform.position;
                cur.SetActive(true);
                Destroy(enemy);
                collision.gameObject.SetActive(false);
                while (bullets.Count > 0)
                {
                    GameObject bul = bullets.Dequeue();
                    Destroy(bul);
                }
            }
        }

    }
}
