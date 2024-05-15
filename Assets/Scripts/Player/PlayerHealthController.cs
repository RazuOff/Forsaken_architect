using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour, IHealthController
{ 


  private float maxHealh = 8f;
  private float healthOnStartGame = 3f;
  private float currentHealth;
  
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
    gameObject.GetComponent<ParticleSystem>().Play();
    animator.SetTrigger("Hit");
    GameObject newBlood = Instantiate(blood, transform.position + Vector3.down * bloodSpawnDistance, blood.transform.rotation);
    newBlood.transform.localScale = gameObject.transform.localScale;
    UIPlayerHealth.OnTakeDamage.Invoke((int)damage);
    if (currentHealth <= 0)
    {
      GetComponent<Collider2D>().enabled = false;
      GetComponent<PlayerController>().enabled = false;
      GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
      animator.SetTrigger("Death");
    }
    
   
  }

  private void Death()
  {
    Destroy(gameObject);
  }

  

}
