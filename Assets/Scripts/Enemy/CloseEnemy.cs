using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemy : EnemyController
{

  
  [SerializeField] private LayerMask hidePlayerMask;
  [SerializeField] private GameObject attack;


  private bool SeeEnemy()
  {    
    RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, hidePlayerMask);
    if (hit.collider != null)
    {
      if (hit.collider.gameObject.tag == "Player")
      {
        return true;
      }
      else
      {
        return false;
        
      }
    }
    return false;
  }

  private void ChangeDirectionToPlayer()
  {
    if (player.transform.position.x > transform.position.x)
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
  }


  
    

  public void PlayerInTrigger()
  {    
    if (SeeEnemy())
    {
      ChangeDirectionToPlayer();      
      
    }
  }
  public void PlayerInAttackRange()
  {    
     Attack();
  }

  public void OnAttackPerform()
  {
    attack.SetActive(true);
    animator.SetBool("CanMove", false);
  }
  public void OnAttackEnd()
  {
    attack.SetActive(false);
    animator.SetBool("CanMove", true);
  }


}
