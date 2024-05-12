using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.Events;

public class UIPlayerHealth : MonoBehaviour
{
  public List<GameObject> healthList = new List<GameObject>();
  private int currentHealth;
  public static Action<int> OnTakeDamage, OnHeal, OnSetupUI;

  private void OnEnable()
  {
    OnTakeDamage += HealthTakeDamage;
    OnHeal += Heal;
    OnSetupUI += SetupUI;
    Debug.Log("Enabe");
  }
  private void OnDisable()
  {
    OnSetupUI -= SetupUI;
    OnHeal -= Heal;
    OnTakeDamage -= HealthTakeDamage;
  }
  private void Heal(int healAmount)
  {
    for (int i = 0; i < currentHealth + healAmount; i++)
    {
      if (!healthList[i].activeSelf)
      {
        healthList[i].SetActive(true);
        healthList[i].GetComponent<Animator>().SetTrigger("Create");

      }
    }
    currentHealth += healAmount;
  }

  private void HealthTakeDamage(int damage)
  {

    for (int i = currentHealth - 1; i >= currentHealth - damage; i--)
    {
      healthList[i].GetComponent<Animator>().SetTrigger("Destroy");
      
    }
    currentHealth -= damage;

  }


  private void SetupUI(int currentHealth)
  {
    Debug.Log(currentHealth);
    for (int i = 0; i < currentHealth; i++)
    {
      healthList[i].SetActive(true);
      healthList[i].GetComponent<Animator>().SetTrigger("Create");
    }
    this.currentHealth = currentHealth;
  }

}
