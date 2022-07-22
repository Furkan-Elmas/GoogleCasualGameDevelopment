using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHitController : MonoBehaviour
{
    [SerializeField] ParticleSystem _hitParticle;

    ParticleSystem _particleClone;

    void Awake()
    {
        _particleClone = Instantiate(_hitParticle); // Making instance
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Planet"))
        {

            _particleClone.transform.position = collision.contacts[0].point; // particle will position and explode first contact point
            _particleClone.Play();

            gameObject.SetActive(false);
        }
    }
}
