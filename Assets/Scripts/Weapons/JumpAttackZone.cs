using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
  public class JumpAttackZone : MonoBehaviour
  {
    [SerializeField] private float zoneDuration =0.1f;
    private float durationCount = 0f;


    void Update()
    {
      durationCount += Time.deltaTime;
      if (durationCount >= zoneDuration )
      {
        Destroy(gameObject);
      }
    }

    
  }
}