using UnityEngine;

public abstract class CreatedObject : MonoBehaviour, IMovable
{ 
  [SerializeField] private float duration = 2f;
  [SerializeField] private GameObject destroyParticle;
  protected Rigidbody2D rb;
  private float durationCount = 0f;
 

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  protected virtual void  Update()
  {
    durationCount += Time.deltaTime;
    if (durationCount >= duration)
    {
      RockDestroy();
    }

  }

  private void RockDestroy()
  {
    Instantiate(destroyParticle, transform.position, destroyParticle.transform.rotation);
    Destroy(gameObject);
  }

  public virtual void MoveObject(Vector2 positionToMove)
  {
    GetComponent<Rigidbody2D>().MovePosition(positionToMove);
  }

}
