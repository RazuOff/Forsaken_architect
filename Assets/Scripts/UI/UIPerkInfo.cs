using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UIPerkInfo : MonoBehaviour
{

  [SerializeField] private  TMP_Text perkName, description;
  [SerializeField] private GameObject perkInfoPanel;
  [SerializeField] private float infoDelay = 0.2f;



  public void SetupUI(string name, string description)
  {
    this.perkName.text = name;
    this.description.text = description;
  }


  public void OnButtonHover()
  {
    StartCoroutine(ShowPerkInfo());
  }

  public void OnCursorExitButton()
  {
    StartCoroutine (HidePerkInfo());
  }

  private  IEnumerator ShowPerkInfo()
  {
    yield return new WaitForSecondsRealtime(infoDelay);
    perkInfoPanel.SetActive(true);
  }
  private IEnumerator HidePerkInfo()
  {
    yield return new WaitForSecondsRealtime(infoDelay);
    perkInfoPanel.SetActive(false);

  }
    




 
}
