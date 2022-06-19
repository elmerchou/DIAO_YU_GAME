using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    Text scoreText;
    Session session;

    int scoreLength;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        session = FindObjectOfType<Session>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreLength = session.GetScore().ToString().Length;
        scoreText.text = "SCORE : ";
        for (int i = 0; i < 9 - scoreLength; i++)
        {
            scoreText.text += "0";
        }

        scoreText.text += session.GetScore().ToString();
    }
}
