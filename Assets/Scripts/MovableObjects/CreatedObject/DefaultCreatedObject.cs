using UnityEngine;

public class DefaultCreatedObject : CreatedObject, INotThrowable
{
  public void ReleaseObject(Vector3 throwForce)
  {
    rb.velocity = Vector2.zero;
    rb.AddForce(throwForce, ForceMode2D.Impulse);
  }

  public void ReleaseObject()
  {
    rb.velocity = Vector2.zero;
  }
}
