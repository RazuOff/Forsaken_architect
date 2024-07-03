using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class SceneController : MonoBehaviour
{

  public static SceneController instance;

  private AttackPerksController attackPerksController;
  private CreationPerksController creationPerksController;

  private void Awake()
  {    
    if (instance == null)
      instance = this;
    else
    {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);
  }


  public void LoadNewScene(string sceneName)
  {
    
  }
}
