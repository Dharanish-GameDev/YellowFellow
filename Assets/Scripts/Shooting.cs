using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    #region Private Variables
    [SerializeField] private ParticleSystem _bulletParticles;
    #endregion

    private void Start()
    {
        var em = _bulletParticles.emission;
        em.enabled = false;
    }

    private void Update()
    {
        

        if(Input.GetMouseButton(0))
        {
            Shoot();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            var em = _bulletParticles.emission;
            em.enabled = false;
        }
    }
    private void Shoot()
    {
        var em = _bulletParticles.emission;
        em.enabled = true;
    }
}
