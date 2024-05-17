using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IHealthController
{
  [SerializeField] private int health;
  private Animator animator;
  [SerializeField] private float scoreCost;
  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  public void Heal(int healAmount)
  {
    
  }

  public void TakeDamage(int damage)
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
