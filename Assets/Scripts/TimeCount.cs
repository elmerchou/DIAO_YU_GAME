using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCount : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject level;

    Text timeText;
    Session session;

    int second;
    int minute;
    float delta = 1;

    string mStr;
    string sStr;



    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        timeText.text = "01 : 00";
        session = FindObjectOfType<Session>();
        second = 0;
        minute = 1;

    }

    // Update is called once per frame


    void Update()
    {
        if (session.ReturnStop() != true)
        {
            delta -= Time.deltaTime;

            if (delta <= 0)
            {
                delta = 1;
                if (second == 0)
                {
                    if (minute == 0)
                    {
                        level.GetComponent<Level>().LoadOver();
                        FindObjectOfType<Session>().Stop();
                        return;
                    }
                    minute--;
                    second += 59;

                }
                else
                {
                    second--;
                }


                if (second < 10)
                {
                    if (second == 0)
                    {
                        sStr = "00";
                    }
                    else
                    {
                        sStr = "0" + second.ToString();
                    }

                }
                else
                {
                    sStr = second.ToString();
                }
                if (minute < 10)
                {
                    if (minute == 0)
                    {
                        mStr = "00";
                    }
                    else
                    {
                        mStr = "0" + minute.ToString();
                    }

                }
                else
                {
                    mStr = minute.ToString();
                }
                timeText.text = mStr + " : " + sStr;
            }

        }

    }



}



// scoreLength = session.GetScore().ToString().Length;
// scoreText.text = "SCORE : ";
// for (int i = 0; i < 9 - scoreLength; i++)
// {
//     scoreText.text += "0";
// }

// scoreText.text += session.GetScore().ToString();

