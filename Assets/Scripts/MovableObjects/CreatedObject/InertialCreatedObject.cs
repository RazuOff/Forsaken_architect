using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


public class InertialCreatedObject : CreatedObject, IThrowable
{

  [SerializeField] private LayerMask platformMask;
  [SerializeField] GameObject damageZone;

  private bool isReleased = false;


  public override void MoveObject(Vector2 positionToMove)
  {
    rb.sharedMaterial.bounciness = 0f;
    base.MoveObject(positionToMove);
    isReleased = false;

    
  }

  public void ReleaseObject(Vector3 throwForce)
  {
    rb.sharedMaterial.bounciness = 1f;
    rb.AddForce(throwForce, ForceMode2D.Impulse);
    
    isReleased = true;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if ((platformMask.value & (1 << collision.gameObject.layer)) != 0)
    {
      if (isReleased)
      {
        Instantiate(damageZone, transform.position, Quaternion.identity);
      }
      else
      {
        rb.velocity = Vector3.zero;
      }
      
    }
  }
 




}
