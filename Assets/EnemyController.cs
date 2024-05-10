using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
  [SerializeField] private ContactFilter2D castFilter;
  [SerializeField] private float groundDistance = .5f;
  
  [SerializeField] private float movementSpeed;

  protected Animator animator;
  private RaycastHit2D[] groundHits = new RaycastHit2D[5];
  private CapsuleCollider2D capsuleCollider;
  private float direction = -1f;

  private Rigidbody2D rb;
  private bool _isMoving;
  public bool IsMoving
  {
    get { return _isMoving; }
    private set
    {
      _isMoving = value;
      animator.SetBool("IsMoving", value);
    }
  }

  private bool _isGrounded;

  public bool IsGrounded
  {
    get
    {
      return _isGrounded;
    }
    private set
    {
      _isGrounded = value;
      animator.SetBool("IsGrounded", value);
    }
  }
  public bool CanMove
  {
    get
    {
      return animator.GetBool("CanMove");
    }
  }
  protected void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    capsuleCollider = GetComponent<CapsuleCollider2D>();
    animator = GetComponent<Animator>();
  }
  
  protected virtual void FixedUpdate()
  {
    Movement();
    IsGrounded = capsuleCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
  }

  protected void Movement()
  {
    if (IsGrounded && CanMove)
    {
      rb.velocity = new Vector2(movementSpeed * direction, rb.velocity.y);
      IsMoving = true;
    }
    else
    {
      if (IsMoving)
      {
        IsMoving = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
      }
    }
  }
  public virtual void Attack()
  {
    animator.SetTrigger("Attack");
  }
  protected void ChangeDirection()
  {
    direction *= -1;
    Vector3 currentScale = gameObject.transform.localScale;
    currentScale.x *= -1;
    gameObject.transform.localScale = currentScale;


  }

  public void OnClifDetected()
  {
    ChangeDirection();
  }
  public void OnWallDetected()
  {
    ChangeDirection();

  }


}
