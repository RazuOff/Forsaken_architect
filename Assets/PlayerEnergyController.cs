using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergyController : MonoBehaviour
{
  [SerializeField] private float maxEnergy, regenegatePerSecond, attackCost;
  private float timeCount = 0;
  public UnityEvent<float, float> OnEnergyChange;
  private bool _canAttack;
  public bool CanAttack
  {
    get { return _canAttack; }
    private set { _canAttack = value; }
  }


  private float _currentEnergy;
  public float CurrentEnergy
  {
    get { return _currentEnergy; }
    private set
    {
      
      if (value > maxEnergy)
      {
        OnEnergyChange.Invoke(maxEnergy, maxEnergy);
        _currentEnergy = maxEnergy;
      }
      else
      {
        OnEnergyChange.Invoke(maxEnergy, value);
        _currentEnergy = value;
      }

      if (attackCost > value)
      {
        CanAttack = false;
      }
      else
      {
        CanAttack = true;
      }

    }
  }


  // Start is called before the first frame update
  void Start()
  {
    CurrentEnergy = maxEnergy;
  }

  // Update is called once per frame
  void Update()
  {
    timeCount += Time.deltaTime;

    if (timeCount >= 1f)
    {     
     

      CurrentEnergy += regenegatePerSecond;
      timeCount = 0f;
    }
  }
  public void ChangeEnergyOnAttack()
  {
    CurrentEnergy -= attackCost;
  }



}
