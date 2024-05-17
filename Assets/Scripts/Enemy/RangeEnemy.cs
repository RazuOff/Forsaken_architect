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
  private bool canHitPlayer = false, playerTooClose = false;




  protected override void FixedUpdate()
  {
    base.FixedUpdate();
    
    if (canHitPlayer )
    {
      if(player.transform.position.x > transform.position.x)
      {
        if (direction < 0)
        {
          ChangeDirection();
        }
      }
      else
      {
        if (direction > 0)
        {
          ChangeDirection();
        }
      }
      if (!playerTooClose)
        base.Attack();
      else
        ChangeDirection();
    }
    
  }

  public override void Attack()
  {
    RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, hidePlayerMask);
    if (hit.collider != null)
    {     
      if (hit.collider.gameObject.tag == "Player")
      {
        canHitPlayer = true;        
      }
      else
      {
        canHitPlayer = false;
        animator.SetBool("CanMove", true);
      }
    }
  }
  public void OnPlayerExitZone()
  {
    canHitPlayer = false;
    animator.SetBool("CanMove", true);
  }
  public void OnPlayerTooClose()
  {
    playerTooClose = true;      
    animator.SetBool("CanMove", true);
    
  }
  public void OnPlayerExitCloseZone()
  {   
    playerTooClose = false;     

  }

  public void OnShoot()
  {

    Instantiate(bullet, transform.position, bullet.transform.rotation);
    

  }

}
