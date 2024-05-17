using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHealthController
{ 


  private int maxHealh = 8;
  private int healthOnStartGame = 3;
  private int currentHealth;
  
  [SerializeField] private Animator animator;
  [SerializeField] private float bloodSpawnDistance;
  [SerializeField] private GameObject blood;



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

  public void Heal(int healAmount)
  {
    if (currentHealth < maxHealh)
    {
      currentHealth += healAmount;
      UIPlayerHealth.OnHeal.Invoke((int)healAmount);
    }
  }

  public void TakeDamage(int damage)
  {
    
    currentHealth -= damage;    
    UIPlayerHealth.OnTakeDamage.Invoke(damage);
    gameObject.GetComponent<ParticleSystem>().Play();
    animator.SetTrigger("Hit");
    GameObject newBlood = Instantiate(blood, transform.position + Vector3.down * bloodSpawnDistance, blood.transform.rotation);
    newBlood.transform.localScale = gameObject.transform.localScale;    
    if (currentHealth <= 0)
    {
      GetComponent<Collider2D>().enabled = false;
      GetComponent<PlayerController>().enabled = false;
      GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
      animator.SetTrigger("Death");
    }
    
   
  }

  //private void Death()
  //{
  //  Destroy(gameObject);
  //}

  

}
