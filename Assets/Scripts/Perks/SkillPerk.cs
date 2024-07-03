using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SkillPerk<T> : MonoBehaviour where T: PerkData
{
  
  public List<T> availablePerks;
  public T currentPerk { get; protected set; }

  public static Action<List<PerkData>, PerkData> OnUpdataPerks;


  private void OnEnable()
  {
    UIPerksMenuController<T>.OnChangeActivePerk += ChangeActivePerk;
  }
  private void OnDisable()
  {
    UIPerksMenuController<T>.OnChangeActivePerk -= ChangeActivePerk;
  }
  private void Start()
  {
    SetDefaultPerk();    
    OnUpdataPerks?.Invoke(availablePerks.ConvertAll((c) => (PerkData)c), currentPerk);
  }

  private void ChangeActivePerk(PerkData perkData)
  {    
    currentPerk = (T)perkData;
    
    OnUpdataPerks?.Invoke(availablePerks.ConvertAll((c) => (PerkData)c), currentPerk);
  }

  protected virtual void AddNewPerk(PerkData perkData)
  {
    availablePerks.Add((T)perkData);
    OnUpdataPerks?.Invoke(availablePerks.ConvertAll((c) => (PerkData)c), currentPerk);
  }

  private void SetDefaultPerk()
  {
    ChangeActivePerk(availablePerks[0]);
  }











}
