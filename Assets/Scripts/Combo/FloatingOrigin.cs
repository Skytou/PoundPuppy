﻿/**
Script Author : Peter Stirling (Sourced from net) 
Description   : Combo - Floating Origin
**/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float threshold = 100.0f;
    public float physicsThreshold = 1000.0f; // Set to zero to disable
    public float defaultSleepVelocity = 0.14f;
    public float defaultAngularVelocity = 0.14f;

    GameObject tempObj;
    ParticleEmitter pe;
    Rigidbody r;
    Transform t;
    Vector3 cameraPosition;
    Object[] objects;
    Particle[] emitterParticles;

    void LateUpdate()
    {
        //SpawnTrigger.floatingOriginInProgress = false;
        cameraPosition = gameObject.transform.parent.transform.position;
        cameraPosition.y = 0f;
        cameraPosition.x = 0f;
        if (cameraPosition.sqrMagnitude > threshold)
        {
            SpawnTrigger.floatingOriginInProgress = true;
            objects = FindObjectsOfType(typeof(Transform));
            for(int i=0;i<objects.Length;i++)
            {
                t = objects[i] as Transform;
                if(t.CompareTag("Stationary"))
                {
                    continue;
                }
                else if(t.parent == null || t.parent.name=="Pooler")
                {
                    t.position -= cameraPosition;
                }
            }
            objects = FindObjectsOfType(typeof(ParticleEmitter));
            for (int i = 0; i < objects.Length; i++)
            {
                Debug.Log("Particle");
                pe = objects[i] as ParticleEmitter;
                emitterParticles = pe.particles;
                for (int j = 0; j < emitterParticles.Length; j++)
                {
                    emitterParticles[j].position -= cameraPosition;
                }
                pe.particles = emitterParticles;
            }
            //if (physicsThreshold >= 0f)
            //{
            //    objects = FindObjectsOfType(typeof(Rigidbody));
            //    for (int i = 0; i < objects.Length; i++)
            //    {
            //        r = (Rigidbody)objects[i];
            //        if (r.gameObject.transform.position.magnitude > physicsThreshold)
            //        {
            //            r.sleepAngularVelocity = float.MaxValue;
            //            r.sleepVelocity = float.MaxValue;
            //        }
            //        else
            //        {
            //            r.sleepAngularVelocity = defaultSleepVelocity;
            //            r.sleepVelocity = defaultAngularVelocity;
            //        }
            //    }
            //}
            StartCoroutine(ResetFlag());
        }
    }

    IEnumerator ResetFlag()
    {
        yield return new WaitForFixedUpdate();
        SpawnTrigger.floatingOriginInProgress = false;
        yield return null;
    }
}