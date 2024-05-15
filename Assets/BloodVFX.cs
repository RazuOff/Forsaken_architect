using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVFX : MonoBehaviour
{
  [SerializeField] private List<string> canContainBloodVFX = new List<string>();
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (!canContainBloodVFX.Contains(collision.gameObject.tag))
    {
      Destroy(gameObject);
    }
  }
}
