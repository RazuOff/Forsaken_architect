using System;
using System.Collections;
using UnityEngine;



public abstract class AttackPerkData : PerkData
{
  public IWeapon weapon;


  public virtual void Setup()
  {

  }

  public virtual IWeapon GetWeapon()
  {
    return null;
  }
}
