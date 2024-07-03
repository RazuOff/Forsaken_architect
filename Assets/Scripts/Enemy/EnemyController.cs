using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour, IKnockBackable
{
  [SerializeField] private ContactFilter2D castFilter;
  [SerializeField] private float groundDistance = .5f;
  [SerializeField] private float movementSpeed;
  [SerializeField] private float knockBackDuration;


  protected GameObject player;

  protected Animator animator;
  private RaycastHit2D[] groundHits = new RaycastHit2D[5];
  private CapsuleCollider2D capsuleCollider;
  protected float direction = -1f, knockBackDurationCount = 0f;
  private bool isKnockBacked = false;
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
    player = GameObject.FindGameObjectWithTag("Player");
  }
  private void Update()
  {
    if (isKnockBacked)
    {
      knockBackDurationCount += Time.deltaTime;
      if (knockBackDurationCount >= knockBackDuration)
      {
        isKnockBacked = false;
        rb.velocity = Vector2.zero;
        knockBackDurationCount = 0f;
      }
    }
  }

  protected virtual void FixedUpdate()
  {
    Movement();
    IsGrounded = capsuleCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;

  }



  protected void Movement()
  {
    if (isKnockBacked)
    {
      return;
    }


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
    animator.SetBool("CanMove", false);
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

  public void OnKnockBack(Vector2 damagerPos, Vector2 toDealDamagePos, float knockBackForce)
  {
    isKnockBacked = true;
    Vector2 dirctionToKnockBack = (toDealDamagePos - damagerPos).normalized;
    rb.velocity = dirctionToKnockBack * knockBackForce;
  }
}
