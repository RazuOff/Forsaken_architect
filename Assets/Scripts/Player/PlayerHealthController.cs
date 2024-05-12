using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHealthController
{
  private float maxHealh = 8f;
  private float healthOnStartGame = 3f;
  private float currentHealth;
  

  private void Start()
  {
    Setup();
  }
  private void Setup()
  {
    currentHealth = healthOnStartGame;
    Debug.Log("Awake");
    UIPlayerHealth.OnSetupUI.Invoke((int)healthOnStartGame);
  }

  public void Heal(float healAmount)
  {
    if (currentHealth < maxHealh)
    {
      currentHealth += healAmount;
      UIPlayerHealth.OnHeal.Invoke((int)healAmount);
    }
  }

  public void TakeDamage(float damage)
  {
    
    currentHealth -= damage;
    UIPlayerHealth.OnTakeDamage.Invoke((int)damage);
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
