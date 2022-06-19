using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook_move : MonoBehaviour
{
    public Transform point = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //讓魚鉤跟隨魚線
        this.gameObject.transform.position = new Vector3(point.position.x,point.position.y,this.gameObject.transform.position.z);
    }
}
