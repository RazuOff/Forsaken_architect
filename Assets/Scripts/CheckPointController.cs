using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
  private Animator animator;
  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      animator.SetTrigger("Activate");
      StartCoroutine(GameWin());
    }
  }



  private IEnumerator GameWin()
  {
    yield return new WaitForSeconds(2f);

    UIController.instance.WinSceneLoad();
  }


}
