using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IHealthController
{
  [SerializeField] private float health;
  private Animator animator;
  [SerializeField] private float scoreCost;
  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  public void Heal(float healAmount)
  {
    
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    animator.SetTrigger("Hit");
    if (health <= 0)
    {
      Death();
    }
  }

  private void Death()
  {
    Destroy(gameObject);

  }

  private void OnDestroy()
  {
    UIController.instance.ChangeScore(scoreCost);
  }
}
