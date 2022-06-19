using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed_2;
    [SerializeField] float maxSpeed_2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float Speed1()
    {
        return Random.Range(minSpeed, maxSpeed);
    }

    public float Speed2()
    {
        return Random.Range(minSpeed_2, maxSpeed_2);
    }

    public void SpeedUp()
    {
        if (minSpeed > 18)
        {
            return;
        }

        minSpeed += 1f;
        maxSpeed += 1f;

        minSpeed_2 += 1f;
        maxSpeed_2 += 1f;
    }
}
