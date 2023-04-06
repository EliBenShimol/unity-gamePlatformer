using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactble : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isInRange;
    public KeyCode key = KeyCode.E;
    public UnityEvent interactAction=new UnityEvent();
    public GameObject interactKey;
    void Start()
    {
        interactKey = GameObject.Find("Canvas").transform.Find("shopKey").gameObject;
        interactKey.SetActive(false);
        isInRange = false;
        interactAction.AddListener(openShop);
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange)
        {
            interactKey.SetActive(true);
            if (Input.GetKeyDown(key))
            {
                interactAction.Invoke();
            }
        }
        else
            interactKey.SetActive(false);

    }


    public void openShop()
    {
        GameManegment.instace.savePlayer();
        Debug.Log("switching scenes");
        SceneManager.LoadScene(1);

    }
}
