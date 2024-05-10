using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHealthController
{
  [SerializeField] private float maxHealh = 100f;
  private float currentHealth;

  private void Awake()
  {
    currentHealth = maxHealh;
  }
  public void Heal(float healAmount)
  {
    currentHealth += healAmount;
  }

  public void TakeDamage(float damage)
  {
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      Death();
    }
  }

  private void Death()
  {
    Destroy(gameObject);
  }

  

}
