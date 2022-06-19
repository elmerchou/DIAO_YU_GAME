using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_floor : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] AudioClip SFX;

    float soundVolume = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        speed = FindObjectOfType<EnemyController>().Speed2();
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Gun gun = other.GetComponent<Gun>();
        if (!gun)
        {
            return;
        }
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position, soundVolume);
    }
}
