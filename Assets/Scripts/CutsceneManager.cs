using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
  [SerializeField] private Animator blackBarsAnimator;
  public static CutsceneManager Instance;
  [SerializeField] private List<CutsceneStruct> cutscenes = new List<CutsceneStruct>();
  public static Dictionary<string, GameObject> cutsceneDataBase = new Dictionary<string, GameObject>();
  public static GameObject activeCutscene;
 
  

  private void Awake()
  {

    Instance = this;

    InitializeCutsceneDataBase();

    foreach (var cutscene in cutsceneDataBase)
    {
      cutscene.Value.SetActive(false);
    }
  }

  private void InitializeCutsceneDataBase()
  {
    cutsceneDataBase.Clear();

    for (int i = 0; i < cutscenes.Count; i++)
    {
      cutsceneDataBase.Add(cutscenes[i].cutsceneKey, cutscenes[i].cutsceneObject);
    }
  }

  public void StartCutscene(string cutsceneKey)
  {
    if (!cutsceneDataBase.ContainsKey(cutsceneKey))
    {
      Debug.LogError($"cutsceneDataBase do not containes  \"{cutsceneKey}\"");
      return;
    }

    if (activeCutscene != null)
    {
      if (activeCutscene == cutsceneDataBase[cutsceneKey])
      {
        return;
      }
    }

    activeCutscene = cutsceneDataBase[cutsceneKey];

    foreach (var cutscene in cutsceneDataBase)
    {
      cutscene.Value.SetActive(false);
    }

    cutsceneDataBase[cutsceneKey].SetActive(true);
    InputController.instance.isActive = false;
  }

  public void EndCutscene()
  {
    if (activeCutscene != null)
    {
      activeCutscene.SetActive(false);
      activeCutscene = null;
      
    }
    InputController.instance.isActive = true;
  }

  public void ShowBlackBars()
  {
    blackBarsAnimator.SetTrigger("Show");

  }
  public void HideBlackBars()
  {
    blackBarsAnimator.SetTrigger("Hide");
  }
}

[System.Serializable]
public struct CutsceneStruct
{
  public string cutsceneKey;
  public GameObject cutsceneObject;
}