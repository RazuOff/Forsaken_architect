using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthController
{

  void TakeDamage(int damage);
  void Heal(int healAmount);


}
