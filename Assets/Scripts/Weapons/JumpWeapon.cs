using UnityEngine;


public class JumpWeapon : MonoBehaviour, IWeapon
{
  public float fallForce;
  public GameObject damageZone;
  private PlayerEnergyController energyController;
  private PlayerController playerController;
  private Rigidbody2D rb;
  private float oldAnimSpeed;

  private void Awake()
  {    
    energyController = gameObject.GetComponent<PlayerEnergyController>();
    playerController = gameObject.GetComponent<PlayerController>();
    rb = gameObject.GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (playerController.animator.speed  != 0)
    {
      oldAnimSpeed = playerController.animator.speed;
    }
    if (playerController.animator.speed == 0  && playerController.IsGrounded)
    {
      playerController.animator.speed = oldAnimSpeed;      
    }
  }


  public void Attack()
  {
    if ( energyController.CanAttack)
    {
      playerController.animator.SetTrigger("JumpAttack");
    }
    rb.velocity = new Vector2(0f, -fallForce);
  }

  public void OnAnimateAttack()
  {
    Instantiate(damageZone, playerController.transform.position, Quaternion.identity);
  }
}
