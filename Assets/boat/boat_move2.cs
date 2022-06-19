using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//物理系統版

public class boat_move2 : MonoBehaviour
{
    public float boat_speed;
    public Rigidbody2D rigid2D;

    [SerializeField] float speeeed;

    float startY;

    void Start()
    {

        for (int i = 1; i < 6; i++)
        {
            GameObject a = GameObject.Find("fish" + i.ToString());
            a.GetComponent<Renderer>().enabled = false;
        }
        this.gameObject.transform.position = new Vector2(1.2f, 3.2f);
        print("start");
        startY = transform.position.y;
    }

    void Update()
    {
        speeeed = rigid2D.velocity.x;
        transform.position = new Vector2(transform.position.x, startY);
        if (Input.GetKey(KeyCode.RightArrow) && rigid2D.velocity.x <= 8.0f)
        {
            //this.gameObject.transform.position += new Vector3(boat_speed, 0 ,0);
            rigid2D.AddForce(new Vector2(boat_speed, 0), ForceMode2D.Force);
            print("right");
        }
        if (Input.GetKey(KeyCode.LeftArrow) && rigid2D.velocity.x >= -8.0f)
        {
            //this.gameObject.transform.position -= new Vector3(boat_speed, 0 ,0);
            rigid2D.AddForce(new Vector2(-boat_speed, 0), ForceMode2D.Force);
            print("left");
        }
        if (this.gameObject.transform.position.x < -7.5)
        {
            this.gameObject.transform.position = new Vector2(-7.5f, this.gameObject.transform.position.y);
            rigid2D.AddForce(new Vector2(boat_speed / 2, 0), ForceMode2D.Force);
        }
        if (this.gameObject.transform.position.x > 7.5)
        {
            this.gameObject.transform.position = new Vector2(7.5f, this.gameObject.transform.position.y);
            rigid2D.AddForce(new Vector2(-boat_speed / 2, 0), ForceMode2D.Force);
            // this.gameObject.transform.position = new Vector2(7.5f, thisgameObject.transform.position.y);
        }
    }


    public void Show(int type)
    {
        GameObject a = GameObject.Find("fish" + type.ToString());
        a.GetComponent<Renderer>().enabled = true;

    }
}
