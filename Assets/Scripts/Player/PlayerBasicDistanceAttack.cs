using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicDistanceAttack : MonoBehaviour
{
  [SerializeField] private GameObject projectile;
  [SerializeField] private Transform spawnTransform;

  private Vector2 worldPosition, direction;

  private void Update()
  {
    //HandleWeaponRotation();
  }

  private void HandleWeaponRotation()
  {
    worldPosition = Camera.main.ScreenToWorldPoint (Mouse.current.position.ReadValue());
    direction = (worldPosition - (Vector2)spawnTransform.position).normalized;
    spawnTransform.right = direction;
  }

  public void SpawnProjectile()
  {
    Instantiate(projectile, spawnTransform.position, projectile.transform.rotation);
  }
}
