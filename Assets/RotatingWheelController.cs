using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWheelController : MonoBehaviour
{
  public float force = 10f; // Момент вращения
  private Rigidbody2D rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    // Применяем момент к объекту
    rb.AddTorque(force);
  }
}
