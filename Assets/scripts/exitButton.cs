using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class exitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button exit;
    void Start()
    {
        exit.onClick.AddListener(closeShop);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void closeShop()
    {
        Debug.Log("switching scenes");
        SceneManager.LoadScene(0);

    }
}
