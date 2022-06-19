using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//普通版

public class boat_move : MonoBehaviour
{
    public float boat_speed = 0.05f;

    void Start()
    {
        this.gameObject.transform.position = new Vector2(0.53f, 3.95f);
        print("start");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(boat_speed, 0, 0);
            print("right");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= new Vector3(boat_speed, 0, 0);
            print("left");
        }
    }
}
