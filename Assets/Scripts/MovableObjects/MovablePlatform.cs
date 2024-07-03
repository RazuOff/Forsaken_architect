using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MovablePlatform : MonoBehaviour, INotThrowable, IMovable
{
  [SerializeField] private float platformSpeed, lifeTime;
  [SerializeField] private ParticleSystem[] releaseParticles;
  [SerializeField] private ParticleSystem movingParticle;
  [SerializeField] private GameObject destroyParticle;

  private Rigidbody2D rb;
  private float offset = 0.1f, lifetimeCount = 0f, movingEmissionRate;


  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    var emission = movingParticle.emission;
    movingEmissionRate = emission.rateOverTime.constant;
  }


  public void MoveObject(Vector2 positionToMove)
  {
    var emission = movingParticle.emission;    
    emission.rateOverTime = CustomMath.Normalize(lifetimeCount, 0, lifeTime, movingEmissionRate);
    movingParticle.Play();    
    lifetimeCount += Time.deltaTime;

    if (lifetimeCount >lifeTime)
    {
      DestroyPlatform();
    }

    Vector2 velocity = Vector2.one;
    if (positionToMove.x < transform.position.x)
    {
      velocity.x = -velocity.x;
    }
    if (positionToMove.y < transform.position.y)
    {
      velocity.y = -velocity.y;
    }

    if (Math.Abs(positionToMove.x - transform.position.x) < offset)
      velocity.x = 0;
    if (Math.Abs(positionToMove.y - transform.position.y) < offset)
      velocity.y = 0;

    rb.bodyType = RigidbodyType2D.Dynamic;
    rb.velocity = velocity * platformSpeed;

  }


  public void ReleaseObject()
  {
    movingParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    rb.bodyType = RigidbodyType2D.Kinematic;
    rb.velocity = Vector2.zero;
    foreach (ParticleSystem particle in releaseParticles)
    {
      if (!particle.isPlaying)
        particle.Play();
    }
  }

  private void DestroyPlatform()
  {
    Instantiate(destroyParticle, transform.position, Quaternion.identity);    
    Destroy(gameObject);
  }
}
