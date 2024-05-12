using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;

public class EnemyBullet : MonoBehaviour
{
  private Transform playerTransform;
  [SerializeField] float bulletSpeed;
  private Rigidbody2D rb;
  private Vector2 target, direction;
  private void Awake()
  {
    playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
    rb = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    if (playerTransform != null)
    {


      target = new Vector2(playerTransform.position.x, playerTransform.position.y + 0.5f);

      // ¬ычисл€ем направление движени€
      direction = target - (Vector2)transform.position;
      direction.Normalize();

      // ѕоворачиваем снар€д в направлении движени€
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      transform.rotation = rotation;
    }
    else
      Destroy(gameObject);
  }
  void FixedUpdate()
  {   
    rb.velocity = direction * bulletSpeed;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Destroy(gameObject);
  }
}
