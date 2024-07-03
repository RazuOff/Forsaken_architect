using UnityEngine;


public class DefaultWeapon : MonoBehaviour, IWeapon
{

  public GameObject projectile;
  private Transform spawnTransform;
  private PlayerEnergyController energyController;
  private PlayerController playerController;

  private void Awake()
  {
    spawnTransform = gameObject.transform.GetChild(0);
    energyController = gameObject.GetComponent<PlayerEnergyController>();
    playerController = gameObject.GetComponent<PlayerController>();
  }


  private void SpawnProjectile()
  {
    Instantiate(projectile, spawnTransform.position, projectile.transform.rotation);
    energyController.ChangeEnergyOnAttack();
  }

  public void Attack()
  {
    if (playerController.IsGrounded && energyController.CanAttack)
    {
      playerController.animator.SetTrigger("DistanceAttack");
    }

  }
  public void OnAnimateAttack()
  {
    SpawnProjectile();
  }
}
