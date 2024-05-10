using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamager : MonoBehaviour
{
  [SerializeField] private float damage;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    DealDamage(collision.gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    DealDamage(collision.gameObject);
  }

  private void DealDamage(GameObject objectToDealDamage)
  {
    if (objectToDealDamage.TryGetComponent(out IHealthController healthController))
    {
      healthController.TakeDamage(damage);
    }
  }
}
