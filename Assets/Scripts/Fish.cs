using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb2D;
    private float maxTime = 6;
    private float minTime = 4;

    private float thrust = 500f;

    //current time
    private float time;
    //The time to spawn the object
    private float changeTime;

    private bool firstRun;

    private bool isFromRight;

    GameObject hook;
    bool keepFollow = false;

    [SerializeField] AudioClip Ohhhh;

    [SerializeField] [Range(0, 1)] float soundVolume = 0.3f;

    [SerializeField] int score;

    [SerializeField] int fishType;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        firstRun = true;
        isFromRight = rb2D.transform.position.x > 8f;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        time = changeTime;
    }
    void FixedUpdate()
    {
        if (keepFollow)
        {
            FollowHook();
            return;
        }
        // transform.Rotate(0, 5, 0, Space.Self);
        //Counts up
        time += Time.deltaTime;
        if (rb2D.velocity.x > 0)
        {
            // right
            Vector3 newRotation = new Vector3(transform.eulerAngles.x, 0, 0);
            transform.eulerAngles = newRotation;
        }
        else
        {
            // left
            Vector3 newRotation = new Vector3(transform.eulerAngles.x, 180, 0);
            transform.eulerAngles = newRotation;
        }

        //Check if its the right time to spawn the object
        if (time >= changeTime)
        {

            time = 0;
            int direction = Random.Range(0, 2) * 2 - 1;
            if (firstRun)
            {
                if (isFromRight)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }
                firstRun = false;
            }
            Debug.Log(firstRun);
            Debug.Log(direction);
            rb2D.AddForce(transform.right * direction * thrust * Random.Range(0f, 1f));
            rb2D.AddForce(transform.up * direction * thrust / 10 * Random.Range(0f, 1f));
            SetRandomTime();
        }


    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    //   /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {

        Destroy(gameObject);

        FindObjectOfType<boat_move2>().Show(fishType);


        AudioSource.PlayClipAtPoint(Ohhhh, Camera.main.transform.position, soundVolume);
        FindObjectOfType<Session>().AddScore(score);
        Debug.Log("Tag: " + other.gameObject.CompareTag("Hook"));
        Debug.Log("objecttag" + other.gameObject.tag);
        // if (other.gameObject.CompareTag("Hook"))
        // {
        // Debug.Log("onCollision and tag is hook");
        // hook = other.gameObject;

        // if (keepFollow) return;

        // Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        // Destroy(rigidbody);
        // Destroy(GetComponent<BoxCollider2D>());
        // Destroy(gameObject);

        // keepFollow = true;
        // }
    }

    //   void OnTriggerEnter(Collider other)
    //   {
    //     Debug.Log("onCollision and tag is hook");
    //     hook = other.gameObject;

    //     if (keepFollow) return;
    //     //   Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
    //     // Destroy(rb2D);
    //     // Destroy(GetComponent<BoxCollider2D>());

    //     keepFollow = true;
    //   }

    void FollowHook()
    {
        Debug.Log("follow hook");
        transform.position = hook.transform.position;
    }

    void SetRandomTime()
    {
        changeTime = Random.Range(minTime, maxTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
