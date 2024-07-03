using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkData", menuName = "Perk/CreationPerk")]
[Serializable]
public class CreationPerkData : PerkData
{
  [SerializeField]
  public GameObject prefab;
}
