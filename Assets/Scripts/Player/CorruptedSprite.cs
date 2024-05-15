using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CorruptedSprite : MonoBehaviour
{
  [SerializeField] PlayerBasicDistanceAttack playerAttack;
  [SerializeField] GameObject player;
  public void OnAnimatePerformAttack()
  {
    playerAttack.SpawnProjectile();
  }

  public void OnDeath()
  {
    Destroy(player);
  }

}
