using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
  private bool[] stickDownLast;

  public bool isActive = true;

  public static Action<float> OnInputMove;
  public static Action OnInputJump, OnInputShoot, OnInputCreateRock, OnInputMenu;

  
 


  private void Awake()
  {
    stickDownLast = new bool[3];
  }
  void FixedUpdate()
  {
    if (isActive)
    {
      MovementInput();
      JumpInput();
    }
    
    
  }

  private void Update()
  {
    if (isActive)
    {
      ShootInput();
      CreateRockInput();
    }
      Menu();
    
  }

  private void Menu()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
      OnInputMenu?.Invoke();
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
      OnInputCreateRock.Invoke();
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
}
