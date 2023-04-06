using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthCounter : MonoBehaviour
{
    public static int health = 3;
    TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "hearts: " + health;
        if (health <= 0)
            playerScript.gameOver();
    }
}
