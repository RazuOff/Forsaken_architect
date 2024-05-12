using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class DetectionZone : MonoBehaviour
{
  public UnityEvent NoCollidersRemain, ColliderRemain, ColliderStay;
  public List<Collider2D> detectedColliders = new List<Collider2D>();
  Collider2D col;

  private void Awake()
  {
    col = GetComponent<Collider2D>();    
  }


  private void OnTriggerEnter2D(Collider2D collision)
  {    
    ColliderRemain.Invoke();
    detectedColliders.Add(collision);

  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    if(collision.gameObject.CompareTag("Player"))
      collision.gameObject.GetComponent<Rigidbody2D>().WakeUp();
    ColliderStay.Invoke();
  }


  private void OnTriggerExit2D(Collider2D collision)
  {
    if (detectedColliders.Contains(collision))
    {
      detectedColliders.Remove(collision);

      if (detectedColliders.Count <= 0)
      {
        NoCollidersRemain.Invoke();
      }
    }
  }

}
