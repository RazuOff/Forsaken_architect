using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class UIHealthPoint : MonoBehaviour
{
   public AnimatorController controller;

  private void Awake()
  {
    gameObject.GetComponent<Animator>().runtimeAnimatorController = Instantiate(controller);
  }

  public void OnTakeDamage()
  {
    gameObject.SetActive(false);
  }
  public void OnHeal()
  {
    gameObject.SetActive(true);
  }
}
