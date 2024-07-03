using UnityEngine;

namespace Assets.Scripts.Perks
{
  [CreateAssetMenu(fileName = "PerkData", menuName = "Perk/AttackPerk/JumpAttack")]
  public class JumpAttackPerkData : AttackPerkData
  {
    public float fallForce;
    public GameObject damageZone;
    public override void Setup()
    {
      ((JumpWeapon)weapon).fallForce = fallForce;
      ((JumpWeapon)weapon).damageZone = damageZone;
    }

    public override IWeapon GetWeapon()
    {
      return GameObject.FindGameObjectWithTag("Player").AddComponent<JumpWeapon>();
    }


  }
}