using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPerksMenuController<T> : MonoBehaviour  where T: PerkData
{
  [SerializeField] private GameObject perkButtonsHolder, perkButton, skillButton;

  private List<PerkData> availableCreationPerks;
  private PerkData currentPerk;

  public static Action<PerkData> OnChangeActivePerk;

  private void OnEnable()
  {
    SkillPerk<T>.OnUpdataPerks += UpdatePerks;
  }

  private void OnDisable()
  {
    SkillPerk<T>.OnUpdataPerks -= UpdatePerks;
  }

  private void UpdatePerks(List<PerkData> availableCreationPerks, PerkData currentPerk)
  {
    this.availableCreationPerks = availableCreationPerks;
    this.currentPerk = currentPerk;    
    UpdateUIPerks();
  }
  private void UpdateUIPerks()
  {
    ClearAvaliablePerksUI();
    CreatePerksPanel();
  }

  private void CreatePerksPanel()
  {
    foreach (PerkData perk in availableCreationPerks)
    {
      GameObject currentButton;
      currentButton = Instantiate(perkButton, perkButtonsHolder.transform);
      if (currentPerk == perk)
      {
        currentButton.GetComponent<Button>().interactable = false;
      }
      currentButton.GetComponent<Image>().sprite = perk.icon;
      currentButton.GetComponent<Button>().onClick.AddListener(() => OnChoosePerk(perk));

      UIPerkInfo buttonInfo = currentButton.GetComponent<UIPerkInfo>();
      buttonInfo.SetupUI(perk.perkName,perk.description);
    }
  }

  private void ClearAvaliablePerksUI()
  {
    for (int i = 0; i < perkButtonsHolder.transform.childCount; i++)
    {
      Destroy(perkButtonsHolder.transform.GetChild(i).gameObject);
    }
  }

  public void OnChangeCreationPerkButton()
  {

    if (perkButtonsHolder.activeSelf)
    {
      perkButtonsHolder.SetActive(false);
    }
    else
    {
      UpdateUIPerks();
      perkButtonsHolder.SetActive(true);
    }
  }

  private void OnChoosePerk(PerkData perk)
  {    
    OnChangeActivePerk?.Invoke(perk);
  }
}
