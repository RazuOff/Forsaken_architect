using System.Collections;
using UnityEngine;


public class CorruptedSprite : MonoBehaviour
{  
  [SerializeField] GameObject player;

  private IWeapon weapon;
  private Animator animator;

  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  public void OnAnimatePerformAttack()
  {    
    weapon = player.GetComponent<AttackPerksController>().currentPerk.weapon;
    weapon.OnAnimateAttack();

  }

  public void PauseAnimation()
  {    
    animator.speed = 0f;  
  }


  public IEnumerator OnDeath()
  {
    yield return new WaitForSeconds(1.5f);
    UIController.instance.LoseSceneLoad();

    Destroy(player);
    
  }

}
