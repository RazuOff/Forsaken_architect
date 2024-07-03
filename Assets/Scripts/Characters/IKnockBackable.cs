using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockBackable
{
  void OnKnockBack(Vector2 damagerPos, Vector2 toDealDamagePos, float knockBackForce);
}
