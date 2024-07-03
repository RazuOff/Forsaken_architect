using UnityEngine;

public class PlatformControlController : MonoBehaviour
{
  private Rigidbody2D selectedRb;
  private Vector3 mouseForce, lastPosition, mousePosition;
  [SerializeField] private float maxSpeed;
  [SerializeField] private LayerMask checkObjectMask;


  private void OnEnable()
  {
    InputController.OnControllObject += GetMovableObjectOnMouse;
    InputController.OnReleaseObject += ObjectReleased;
  }
  private void OnDisable()
  {
    InputController.OnControllObject -= GetMovableObjectOnMouse;
    InputController.OnReleaseObject -= ObjectReleased;
  }

  void FixedUpdate()
  {
    ControllMovable();
  }


  private void GetMovableObjectOnMouse()
  {
    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, checkObjectMask);
    if (hit.rigidbody != null && hit.rigidbody.gameObject.GetComponent<IMovable>() != null)
    {
      selectedRb = hit.rigidbody;     
      mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
      mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
      lastPosition = mousePosition;
    }
  }

  private void ObjectReleased()
  {
    if (selectedRb != null)
    {
      Release();
      selectedRb = null;
    }
  }

  private void ControllMovable()
  {
    if (selectedRb != null && selectedRb.gameObject.TryGetComponent(out IMovable movableObject))
    {
      movableObject.MoveObject(mousePosition);
    }
  }

  private void Release()
  {
    if (selectedRb.gameObject.TryGetComponent(out IThrowable throwableObject))
    {
      throwableObject.ReleaseObject(mouseForce);
    }
    if (selectedRb.gameObject.TryGetComponent(out INotThrowable notThrowableObject))
    {
      notThrowableObject.ReleaseObject();
    }
  }
}
