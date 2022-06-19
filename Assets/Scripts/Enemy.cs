using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed;

    [SerializeField] float durationOfExplosion = 1f;


    [SerializeField] GameObject VFX;

    [SerializeField] AudioClip SFX;

    float soundVolume = 0.4f;



    void Start()
    {
        speed = FindObjectOfType<EnemyController>().Speed1();
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerLaser laser = other.GetComponent<PlayerLaser>();
        Enemy_floor floor = other.GetComponent<Enemy_floor>();
        Gun gun = other.GetComponent<Gun>();
        if (!laser && !floor && !gun)
        {
            return;
        }
        else if (!floor)
        {
            FindObjectOfType<Session>().AddScore(100);
        }
        Destroy(gameObject);
        GameObject explosion = Instantiate(VFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position, soundVolume);
    }

}

