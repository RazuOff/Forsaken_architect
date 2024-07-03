using UnityEngine;

public class PlayerController : MonoBehaviour, IKnockBackable
{
  public Animator animator;
  [SerializeField] LayerMask platformLayerMask;
  [SerializeField] private float jumpForce, moveSpeed, rockCreateCooldown, rockSpawnRange, heightOfCheckForJump = 1f, knockBackDuration;
  [SerializeField] private GameObject attackProjectile;  
  private CreationPerksController perksController;
  private AttackPerksController attackPerksController;
  private bool isKnockBacked = false;
  private float rockCreateCooldownCount = 0f, knockBackDurationCount = 0f;
  private Rigidbody2D rb;
  private BoxCollider2D boxCollider2D;
  private PlayerEnergyController playerEnergyController;
  private bool _isGrounded = true, facingRight = true, _isMoving = false, canCreateRock = true;
  private GameObject RockToCreate
  {
    get { return perksController.currentPerk.prefab; }
  }
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
    playerEnergyController = GetComponent<PlayerEnergyController>();
    perksController = GetComponent<CreationPerksController>();
    attackPerksController = GetComponent<AttackPerksController>();


  }
  private void OnEnable()
  {
    InputController.OnInputMove += Move;
    InputController.OnInputJump += Jump;
    InputController.OnInputShoot += Shoot;
    InputController.OnInputCreateRock += CreateRock;
  }
  private void OnDisable()
  {
    InputController.OnInputMove -= Move;
    InputController.OnInputJump -= Jump;
    InputController.OnInputShoot -= Shoot;
    InputController.OnInputCreateRock -= CreateRock;
  }
  private void Update()
  {
    rockCreateCooldownCount += Time.deltaTime;
    if (rockCreateCooldownCount >= rockCreateCooldown)
    {
      canCreateRock = true;
      rockCreateCooldownCount = 0;
    }

    if (isKnockBacked)
    {
      knockBackDurationCount += Time.deltaTime;
      if (knockBackDurationCount >= knockBackDuration)
      {
        rb.velocity = Vector2.zero;
        isKnockBacked = false;
        knockBackDurationCount = 0;
      }
    }
  }

  private void FixedUpdate()
  {
    GroundCheck();
  }

  public void OnKnockBack(Vector2 damagerPos, Vector2 toDealDamagePos, float knockBackForce)
  {
    isKnockBacked = true;

    Vector2 dirctionToKnockBack = (toDealDamagePos - damagerPos).normalized;
    rb.velocity = dirctionToKnockBack * knockBackForce;
  }

  private void Move(float axis)
  {

    if (isKnockBacked)
    {
      return;
    }



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
    attackPerksController.currentPerk.weapon.Attack();
  }
  private void CreateRock()
  {
    if (canCreateRock)
    {
      Vector3 spawnPoint = transform.position;
      if (spawnPoint.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
      {
        spawnPoint.x -= rockSpawnRange;
      }
      else if (spawnPoint.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
      {
        spawnPoint.x += rockSpawnRange;
      }
      Instantiate(RockToCreate, spawnPoint, Quaternion.identity);
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
    if (raycastHit.collider != null)
    {
      IsGrounded = true;
    }
    else
    {
      IsGrounded = false;
    }
  }

}
