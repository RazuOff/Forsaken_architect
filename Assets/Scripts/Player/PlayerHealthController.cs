using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHealthController
{
  public static Action OnPlayerHit, OnPlayerDied;
  private int maxHealh = 8;
  private int healthOnStartGame = 3;
  private int currentHealth;

  private void Start()
  {
    Setup();
  }

  private void Setup()
  {
    currentHealth = healthOnStartGame;
    UIPlayerHealth.OnSetupUI.Invoke(healthOnStartGame);
  }

  public void Heal(int healAmount)
  {
    if (currentHealth < maxHealh)
    {
      currentHealth += healAmount;
      UIPlayerHealth.OnHeal.Invoke(healAmount);
    }
  }

  public void TakeDamage(int damage)
  {    
    currentHealth -= damage;    
    UIPlayerHealth.OnTakeDamage.Invoke(damage);
    OnPlayerHit?.Invoke();   
    if (currentHealth <= 0)
    {
      OnPlayerDied?.Invoke();
    }
  }
}
