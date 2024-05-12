using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CorruptedSprite : MonoBehaviour
{
  [SerializeField] PlayerBasicDistanceAttack player;

  public void OnAnimatePerformAttack()
  {
    player.SpawnProjectile();
  }

}
