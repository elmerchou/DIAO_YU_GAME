using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

  GameObject hook;
  bool keepFollow = false;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  //   void FixedUpdate()
  //   {
  //     if (keepFollow)
  //     {
  //       FollowHook();
  //     }
  //   }

  //   /// <summary>
  //   /// Sent when an incoming collider makes contact with this object's
  //   /// collider (2D physics only).
  //   /// </summary>
  //   /// <param name="other">The Collision2D data associated with this collision.</param>
  //   void OnCollisionEnter2D(Collision2D other)
  //   {
  //     if (other.gameObject.tag == "Hook")
  //     {

  //       hook = other.gameObject;
  //       Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
  //       Destroy(rigidbody);
  //       keepFollow = true;
  //     }
  //   }

  //   void FollowHook()
  //   {
  //     transform.position = hook.transform.position;
  //   }
}
