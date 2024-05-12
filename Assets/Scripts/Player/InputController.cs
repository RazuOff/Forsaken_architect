using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
  private bool[] stickDownLast;

  public static Action<float> onInputMove;
  public static Action onInputJump, onInputShoot, onInputCreateRock;
 


  private void Awake()
  {
    stickDownLast = new bool[3];
  }
  void FixedUpdate()
  {
    MovementInput();
    JumpInput();
    
    
  }

  private void Update()
  {
    ShootInput();
    CreateRockInput();
  }

  private void JumpInput()
  {
    if (Input.GetAxisRaw("Jump") > 0)
    {
      if (!stickDownLast[1])
      {
        onInputJump?.Invoke();
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
    onInputMove?.Invoke(axis);
  }
  private void CreateRockInput()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      onInputCreateRock.Invoke();
    }
  }
  private void ShootInput()
  {
    if (Input.GetAxisRaw("Fire1") > 0)
    {
      if (!stickDownLast[0])
      {
        onInputShoot?.Invoke();
        stickDownLast[0] = true;
      }

    }
    else
    {
      stickDownLast[0] = false;
    }
  }
}
