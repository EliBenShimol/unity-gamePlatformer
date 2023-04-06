using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManegment : MonoBehaviour
{

    public Queue<gunScript> guns;
    public string[] playerGuns;
    public static GameObject player;
    public gunScript pistol;
    public gunScript ar;
    public gunScript shotgun;
    public int slot = 0;
    public bool[] slotsActivation = { false, false };
    public static GameManegment instace=null;
    private Queue<enemyScript> enemies;
    public Button item;
    public Vector3 playerPosition=Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        guns = new Queue<gunScript>();
        playerGuns = new string[2];
        enemies = new Queue<enemyScript>();
        guns.Enqueue(ar);
        guns.Enqueue(pistol);
        guns.Enqueue(shotgun);
        playerGuns[0] = pistol.name;
        playerGuns[1] = ar.name;
        Debug.Log(playerGuns[0] + ' ' + playerGuns[1]);
    }
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }
    // Update is called once per frame
    public void changePlayerGuns(int i, GameObject gun)
    {
        playerGuns[i] = gun.name;
        Debug.Log(gun);
    }

    public void savePlayer()
    {
        playerPosition = player.transform.position;
    }
}
