using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject laserPrefab;

    [SerializeField] GameObject Gun;
    [SerializeField] float laserSpeed = 10f;

    [SerializeField] bool fire;

    [SerializeField] bool fireUpdate;

    [SerializeField] float fireBetween = 0.5f;
    float fireBetweenInside;

    [SerializeField] bool pauseBool = false;
    [SerializeField] float durationOfExplosion = 1f;

    [SerializeField] GameObject VFX;

    [SerializeField] AudioClip SFX;

    [SerializeField] [Range(0, 1)] float soundVolume = 0.7f;

    [SerializeField] bool stop = true;


    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        fire = true;
        fireBetweenInside = fireBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)
        {
            return;
        }

        Jump();

        if (fire == true && fireUpdate == true)
        {
            FireUpdate();

        }
        else if (fire == true)
        {
            Fire();
        }
        else
        {
            fireBetweenInside -= Time.deltaTime;
            if (fireBetweenInside <= 0)
            {
                fire = true;
                fireBetweenInside = fireBetween;
            }
        }

        Check();

    }

    void Check()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (fireUpdate == false)
            {
                fireUpdate = true;
                Debug.Log("Change Mode");

            }
            else if (fireUpdate == true)
            {
                fireUpdate = false;
                Debug.Log("Change Mode");

            }

        }

    }


    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);

        }

    }


    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject laser = Instantiate(laserPrefab, transform.position + new Vector3(1, -0.25f, 0), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
            fire = false;
        }

    }

    void FireUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject laser = Instantiate(Gun, transform.position + new Vector3(1, -0.25f, 0), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
            fire = false;
        }


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
        GameObject explosion = Instantiate(VFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position, soundVolume);
        FindObjectOfType<Session>().Stop();
        if (other.tag == "END1")
        {
            FindObjectOfType<Level>().LoadOver();
        }
        else if (other.tag == "END2")
        {
            FindObjectOfType<Level>().LoadOver2();
        }
        else if (other.tag == "END3")
        {
            FindObjectOfType<Level>().LoadOver3();
        }
        else if (other.tag == "END4")
        {
            FindObjectOfType<Level>().LoadOver4();
        }
    }

    // private void Pause()
    // {

    //     if (Input.GetKeyDown(KeyCode.P))
    //     {
    //         if (pauseBool == false)
    //         {
    //             Debug.Log("Pause");
    //             Time.timeScale = 0;
    //             pauseBool = true;
    //         }
    //         else if (pauseBool == true)
    //         {
    //             Time.timeScale = 1;
    //             pauseBool = false;
    //         }

    //     }
    // }


    public void Stop()
    {
        rigid.Sleep();
        stop = true;
    }

    public void ReStart()
    {
        rigid.WakeUp();
        stop = false;

    }
}
