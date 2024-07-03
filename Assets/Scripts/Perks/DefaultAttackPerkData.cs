using Assets.Scripts.Perks;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkData", menuName = "Perk/AttackPerk/DefaultAttack")]
public class DefaultAttackPerkData : AttackPerkData
{
  public GameObject projectile;

  public override void Setup()
  {
    ((DefaultWeapon)weapon).projectile = projectile;
  }

  public override IWeapon GetWeapon()
  {
    return GameObject.FindGameObjectWithTag("Player").AddComponent<DefaultWeapon>();
  }


}
