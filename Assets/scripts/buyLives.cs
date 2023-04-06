using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class buyLives : MonoBehaviour
{
    public Button buyHeart;
    public Button check;
    private Text t;
    void Start()
    {
        t = GameObject.Find("extraLives").GetComponentInChildren<Text>();
        buyHeart.onClick.AddListener(addHeart);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthCounter.health < 3 && moneyScript.coins>0)
            t.text = "+1 heart";
        else
            t.text = "can't buy hearts";


    }

    public void addHeart()
    {
        if (healthCounter.health < 3 &&moneyScript.coins>0)
        {
            healthCounter.health++;
            Debug.Log("heart added");
            moneyScript.coins--;
        }

    }
}
