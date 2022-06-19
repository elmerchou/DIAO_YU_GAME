using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float maxSpeed;
    Material myMaterial;
    Vector2 offset;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }

    public void SpeedUp()
    {
        if (speed >= maxSpeed)
        {
            return;
        }
        speed += 0.01f;
        offset = new Vector2(speed, 0);

    }
}
