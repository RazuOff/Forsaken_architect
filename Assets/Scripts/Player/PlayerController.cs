using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] LayerMask platformLayerMask;
  [SerializeField] private float jumpForce, moveSpeed, rockCreateCooldown , heightOfCheckForJump = 1f;
  [SerializeField] private GameObject attackProjectile, rockToCreate;
  [SerializeField] private Transform creatingPointTransform ;
  [SerializeField] private Animator animator;
  private float rockCreateCooldownCount = 0f;
  private Rigidbody2D rb;
  private BoxCollider2D boxCollider2D;
  private bool _isGrounded = true, facingRight = true, _isMoving = false, canCreateRock = true;
  public bool IsGrounded
  {
    get { return _isGrounded; }
    set
    {
      _isGrounded = value;
      animator.SetBool("IsGrounded", value);
    }
  }
  public bool IsMoving
  {
    get { return _isMoving; }
    private set
    {
      _isMoving = value;
      animator.SetBool("IsMoving", value);
    }
  }

  public bool CanMove
  {
    get
    {      
      return animator.GetBool("CanMove");
    }
  }

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    boxCollider2D = GetComponent<BoxCollider2D>();
   

  }
  private void OnEnable()
  {
    InputController.onInputMove += Move;
    InputController.onInputJump += Jump;
    InputController.onInputShoot += Shoot;
    InputController.onInputCreateRock += CreateRock;

  }
  private void OnDisable()
  {
    InputController.onInputMove -= Move;
    InputController.onInputJump -= Jump;
    InputController.onInputShoot -= Shoot;
    InputController.onInputCreateRock -= CreateRock;
  }
  private void Update()
  {
    rockCreateCooldownCount += Time.deltaTime;
    if(rockCreateCooldownCount >= rockCreateCooldown)
    {
      canCreateRock = true;
      rockCreateCooldownCount = 0;
    }
    
  }

  private void FixedUpdate()
  {
    GroundCheck();
  }

  private void Move(float axis)
  {
    if (CanMove)
    {
      rb.velocity = new Vector2(axis * moveSpeed, rb.velocity.y);
      if (axis > 0 && !facingRight)
      {
        Flip();
      }
      if (axis < 0 && facingRight)
      {
        Flip();
      }

      if (axis == 0)
      {
        IsMoving = false;
      }
      else
      {
        IsMoving = true;
      }
    }
    else
      rb.velocity = new Vector2(0, rb.velocity.y);
  }

  private void Jump()
  {
    if (IsGrounded && CanMove)
    {

      rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
      animator.SetTrigger("Jumped");


    }
  }

  private void Shoot()
  {
    if (IsGrounded)
     animator.SetTrigger("DistanceAttack");
  }
  private void CreateRock()
  {
    if (canCreateRock)
    {
      Instantiate(rockToCreate, creatingPointTransform.position, Quaternion.identity);
      canCreateRock = false;
    }
  }

  private void Flip()
  {
    Vector3 currentScale = gameObject.transform.localScale;
    currentScale.x *= -1;
    gameObject.transform.localScale = currentScale;
    facingRight = !facingRight;
  }

  private void GroundCheck()
  {
    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size - new Vector3(0.1f, 0f, 0f), 0f, Vector2.down, heightOfCheckForJump, platformLayerMask);
    Color color;
    if (raycastHit.collider != null)
    {
      IsGrounded = true;
      color = Color.green;
    }
    else
    {
      IsGrounded = false;
      color = Color.red;
    }

    Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + heightOfCheckForJump), color);
    Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + heightOfCheckForJump), color);
    Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, boxCollider2D.bounds.extents.y + heightOfCheckForJump), Vector2.right * (boxCollider2D.bounds.extents.x * 2f), color);
  }

}
