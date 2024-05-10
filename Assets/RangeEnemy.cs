using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class RangeEnemy : EnemyController
{
  [SerializeField] private GameObject bullet;
  [SerializeField] private float bulletSpeed;
  [SerializeField] private LayerMask hidePlayerMask;
  [SerializeField] private GameObject player;
  private bool playerInZone = false;


  private void Update()
  {
    Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
    float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
    Debug.DrawRay(transform.position, directionToPlayer);
  }

  protected override void FixedUpdate()
  {
    base.FixedUpdate();
    
    if (playerInZone)
    {
      animator.SetBool("CanMove", false);
      base.Attack();
    }
  }

  public override void Attack()
  {
    RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, hidePlayerMask);
    if (hit.collider != null)
    {    
      Debug.Log(hit.collider.gameObject.name);
      if (hit.collider.gameObject.tag == "Player")
      {
        playerInZone = true;        
      }
    }
  }
  public void OnPlayerExitZone()
  {
    playerInZone = false;
    animator.SetBool("CanMove", true);
  }

  public void OnShoot()
  {

    Instantiate(bullet, transform.position, bullet.transform.rotation);
    

  }

}
