using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthController
{

  void TakeDamage(float damage);
  void Heal(float healAmount);


}
