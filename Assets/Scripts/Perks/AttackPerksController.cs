using Assets.Scripts.Perks;
using System.Collections;
using UnityEngine;


public class AttackPerksController : SkillPerk<AttackPerkData>
{
  private void Awake()
  {
    CreateWeaponsFromPerks();
  }



  protected override void AddNewPerk(PerkData perkData)
  {
    CreateWeaponsFromPerks((AttackPerkData)perkData);
    base.AddNewPerk(perkData);
  }

  private void CreateWeaponsFromPerks(AttackPerkData newPerk)
  {    
      newPerk.weapon = newPerk.GetWeapon();
      newPerk.Setup();
  }

  private void CreateWeaponsFromPerks()
  {
    foreach (var perk in availablePerks.ConvertAll((c) => (AttackPerkData)c))
    {
      perk.weapon = perk.GetWeapon();
      perk.Setup();
    }
  }
}
