using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControlController : MonoBehaviour
{
  private Rigidbody2D selectedRb;
  private Vector3 offset, mouseForce, lastPosition, mousePosition;
  [SerializeField] private float maxSpeed;
  [SerializeField] private LayerMask checkObjectMask;


  // Start is called before the first frame update
  private void Awake()
  {
    
  }

  void FixedUpdate()
  {
    if (selectedRb != null && Input.GetMouseButton(1))
    {
      selectedRb.MovePosition(mousePosition + offset);
    }
  }

  void Update()
  {
    if (Input.GetMouseButton(1))
    {
      mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity,checkObjectMask);
      if (hit.rigidbody != null && hit.collider.gameObject.CompareTag("Movable"))
      {
        selectedRb = hit.rigidbody;
        offset = selectedRb.transform.position - mousePosition;
        mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
        mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
        lastPosition = mousePosition;
      }
      
    }    


    if (Input.GetMouseButtonUp(1) && selectedRb)
    {
      Debug.Log(mouseForce);
      selectedRb.velocity = Vector2.zero;
      selectedRb.AddForce(mouseForce, ForceMode2D.Impulse);
      selectedRb = null;
    }

  }

}
