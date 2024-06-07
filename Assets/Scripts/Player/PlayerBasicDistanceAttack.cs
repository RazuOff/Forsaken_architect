using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicDistanceAttack : MonoBehaviour
{
  [SerializeField] private GameObject projectile;
  [SerializeField] private Transform spawnTransform;



  public void SpawnProjectile()
  {
    Instantiate(projectile, spawnTransform.position, projectile.transform.rotation);
  }
}
