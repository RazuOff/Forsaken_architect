using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class HealthDamager : MonoBehaviour
{

  [SerializeField] private bool isTrigger;
  [SerializeField] private int damage;
  [SerializeField] private bool knockBack;
  [SerializeField] private float knockBackForce;


  //public static Action<Vector2> OnPlayerKnockBack;
  private void Awake()
  {
    
  }

 


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(isTrigger)
    DealDamage(collision.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(!isTrigger) 
      DealDamage(collision.gameObject);
  }



  private void DealDamage(GameObject objectToDealDamage)
  {
    if (objectToDealDamage.TryGetComponent(out IHealthController healthController))
    {
      if (knockBack && objectToDealDamage.TryGetComponent(out IKnockBackable unitController))
      {     
        unitController.OnKnockBack(transform.position, objectToDealDamage.transform.position, knockBackForce);
      }

      healthController.TakeDamage(damage);
    }
  }
}

