using System.Collections.Generic;
using UnityEngine;

public class BloodVFX : MonoBehaviour
{
  [SerializeField] private List<BoxCollider2D> checkColliders;
  [SerializeField] private LayerMask platformMask;
  private Collider2D[] hits;

  private void Start()
  {
    foreach(BoxCollider2D boxCollider in checkColliders) 
    {
      hits = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.size, 0f, platformMask);
      if (hits.Length == 0)
      {
        Destroy(gameObject);
      }
    }
  }
}
