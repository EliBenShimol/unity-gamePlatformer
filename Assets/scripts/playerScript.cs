using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    public Rigidbody2D player;
    public BoxCollider2D box;
    public GameObject bullet;
    public Vector3 move;
    private GameManegment instructions;
    private GameObject[] guns=new GameObject[2];
    public LayerMask groundLayer;
    // Update is called once per frame
    bool side;
    int countSide = 0;
    int cooldown = 0;
    public Queue<GameObject> bullets=new Queue<GameObject>();

    private void Start()
    {
        instructions = GameManegment.instace;
        guns[0] = GameObject.Find(instructions.playerGuns[0]);
        guns[1] = GameObject.Find(instructions.playerGuns[1]);
        GameObject.Find("ar").SetActive(false);
        GameObject.Find("pistol").SetActive(false);
        GameObject.Find("shotgun").SetActive(false);
        if (instructions.playerPosition != Vector3.zero)
            transform.position = instructions.playerPosition;

    }

    private void Update()
    {
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("space")|| Input.GetKeyDown("w")) &&(isGrounded()|| isAgainstWall()))
        {
           
            if (isAgainstWall())
            {
                float sumForce = 0f;
                if (side)
                {
                    sumForce = -0.7f;
                    countSide = 1;
                }
                if (!side)
                {
                    sumForce = 0.7f;
                    countSide = -1;
                }
               player.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
               player.AddForce(new Vector2(sumForce, 0), ForceMode2D.Impulse);
            }
            if (isGrounded())
                countSide = 0;
            player.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if (cooldown == 0&&(guns[0].activeInHierarchy||guns[1].activeInHierarchy))
            {
                Vector2 camPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                Vector2 direct = camPos - player.position;
                float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
                Quaternion ang = Quaternion.AngleAxis(angle, Vector3.forward);
                Queue<GameObject>bull = gunScript.shooting(ang);
                while(bull.Count>0)
                    bullets.Enqueue(bull.Dequeue());
                cooldown = gunScript.cooldown;
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!guns[0].activeInHierarchy)
            {
                guns[0].SetActive(true);
                guns[1].SetActive(false);
                Debug.Log("1");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!guns[1].activeInHierarchy)
            {
                guns[0].SetActive(false);
                guns[1].SetActive(true);
                Debug.Log("2");
            }
        }

      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("shop"))
        {

            if (guns[0].activeInHierarchy)
                instructions.slot = 0;
            else
                instructions.slot = 1;
            Debug.Log("in shop");
            Interactble.isInRange = true;
        }

        else if (collision.gameObject.name.Contains("coin"))
        {
            moneyScript.coins++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("Bullet")) 
        {
            if (shotScript.cameFrom().Contains("enemy"))
            {
                healthCounter.health--;
                collision.gameObject.SetActive(false);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("shop"))
        {
            Debug.Log("exit shop");
            Interactble.isInRange = false;
        }

    }

    void FixedUpdate()
    {
        int count = bullets.Count;
        while (count > 0)
        {
            bool destroyed = false;
            GameObject bul = bullets.Dequeue();
            if (bul != null)
            {
                shotScript.toFar(player.gameObject, bul, destroyed);
                if (!bul.activeInHierarchy)
                {
                    Destroy(bul);
                    destroyed = true;
                }
                if (!destroyed)
                    bullets.Enqueue(bul);
            }
            count--;

        }
        if (cooldown > 0)
            cooldown--;
        move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        player.transform.position += move * 5 * Time.deltaTime;
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private bool isGrounded()
    {
        bool ground = false;
        ground=Physics2D.OverlapArea(new Vector2(transform.position.x - 0.10f, transform.position.y - 0.26f),
           new Vector2(transform.position.x + 0.10f, transform.position.y - 0.26f), groundLayer);
        return ground;
    }

    private bool isAgainstWall()
    {
        bool wall1 = false;
        wall1 = Physics2D.OverlapArea(new Vector2(transform.position.x + 0.26f, transform.position.y - 0.15f),
          new Vector2(transform.position.x + 0.26f, transform.position.y + 0.15f), groundLayer);
        bool wall2 = false;
        wall2=Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y - 0.15f),
          new Vector2(transform.position.x - 0.3f, transform.position.y + 0.15f), groundLayer);
        if (wall1)
            side = true;
        else if(wall2)
            side = false;
        if (wall1 && side && countSide == 1)
            wall1 = false;
        else if (wall2 && !side && countSide == -1)
            wall2 = false;
        return wall1|| wall2;

    }


    public static void gameOver()
    {
        Debug.Log("switching scenes");
        SceneManager.LoadScene(1);
    }

}
