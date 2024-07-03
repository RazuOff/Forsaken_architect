using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
  [SerializeField] private Animator animator;
  [SerializeField] private float bloodSpawnDistance;
  [SerializeField] private GameObject blood;

  private void OnEnable()
  {
    PlayerHealthController.OnPlayerHit += PlayerHitted;
    PlayerHealthController.OnPlayerDied += PlayerGetKilled;
  }

  private void OnDisable()
  {
    PlayerHealthController.OnPlayerHit -= PlayerHitted;
    PlayerHealthController.OnPlayerDied -= PlayerGetKilled;    
  }

  private void PlayerHitted()
  {
    gameObject.GetComponent<ParticleSystem>().Play();
    animator.SetTrigger("Hit");
    GameObject newBlood = Instantiate(blood, transform.position + Vector3.down * bloodSpawnDistance, blood.transform.rotation);
    newBlood.transform.localScale = gameObject.transform.localScale;
  }

  private void PlayerGetKilled()
  {
    GetComponent<Collider2D>().enabled = false;
    GetComponent<PlayerController>().enabled = false;
    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    animator.SetTrigger("Death");
  }
  private void PlayerKnockBacked()
  {

  }
}
