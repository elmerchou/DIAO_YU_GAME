using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrl_hook : MonoBehaviour
{
    //public GameObject FishLine = null;
    public Transform FishLineT = null;
    public Transform FishHook = null;
    public float moVe = 0.1f;

    void Start()
    {
        //FishLineT = GameObject.Find("魚線").GetComponent<Transform>();
        //FishLineT.localScale = new Vector3(2.0f, 2.0f ,0f);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
            //判斷已是最長長度
            if (FishLineT.localScale.y < 17.0f)
            {
                //延長魚線
                FishLineT.localScale += new Vector3(0f, 0.3f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("down");
            //判斷是否已是最短
            if (FishLineT.localScale.y > 1.0f)
            {
                //縮短魚線
                FishLineT.localScale -= new Vector3(0f, 0.3f, 0f);
            }
        }
    }
}
