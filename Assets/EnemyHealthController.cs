using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IHealthController
{
  [SerializeField] private float health;
  public void Heal(float healAmount)
  {
    
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Death();
    }
  }

  private void Death()
  {
    Destroy(gameObject);
  }


}