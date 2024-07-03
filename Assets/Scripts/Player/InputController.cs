using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
  private bool[] stickDownLast;

  public bool isActive = true, isMovementActive = true, isJumpActive = true;

  public static Action<float> OnInputMove;
  public static Action OnInputJump, OnInputShoot, OnInputCreateRock, OnInputMenu, OnControllObject, OnReleaseObject, OnPerkMenuOpen;

  public static InputController instance;



  private void Awake()
  {
    stickDownLast = new bool[3];
    instance = this;
  }
  void FixedUpdate()
  {
    if (isActive)
    {
      if (isMovementActive)
        MovementInput();
      if (isJumpActive)
        JumpInput();
    }


  }

  private void Update()
  {
    if (isActive)
    {
      ShootInput();
      CreateRockInput();
      ControllMovableObject();
      ReleaseMovableObject();
    }
    Menu();
    PerksMenu();
    


  }

  private void Menu()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
      OnInputMenu?.Invoke();
  }
  private void PerksMenu()
  {
    if (Input.GetKeyDown(KeyCode.P))
      OnPerkMenuOpen?.Invoke();
  }
  private void JumpInput()
  {
    if (Input.GetAxisRaw("Jump") > 0)
    {
      if (!stickDownLast[1])
      {
        OnInputJump?.Invoke();
        stickDownLast[1] = true;
      }
    }
    else
    {
      stickDownLast[1] = false;
    }
  }

  private void MovementInput()
  {
    float axis = Input.GetAxisRaw("Horizontal");
    OnInputMove?.Invoke(axis);
  }
  private void CreateRockInput()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      OnInputCreateRock?.Invoke();
    }
  }
  private void ShootInput()
  {
    if (Input.GetAxisRaw("Fire1") > 0)
    {
      if (!stickDownLast[0])
      {
        OnInputShoot?.Invoke();
        stickDownLast[0] = true;
      }

    }
    else
    {
      stickDownLast[0] = false;
    }
  }

  private void ControllMovableObject()
  {
    if (Input.GetMouseButton(1))
    {
      OnControllObject?.Invoke();
    }
  }
  private void ReleaseMovableObject()
  {
    if (Input.GetMouseButtonUp(1))
    {
      OnReleaseObject?.Invoke();
    }
  }
}
