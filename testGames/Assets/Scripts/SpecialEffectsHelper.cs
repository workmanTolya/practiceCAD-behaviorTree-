using UnityEngine;
using System.Collections;
using System;

public class SpecialEffectsHelper : MonoBehaviour {

    public static SpecialEffectsHelper Instance;
    public ParticleSystem soulEffect;
    public ParticleSystem soulEnemyEffect;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Несколько экземпляров SpecialEffectsHelper!");
        }
        Instance = this;
    }

    public void Explosion( Vector3 position)
    {

            instantiate(soulEffect, position);

    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
        return newParticleSystem;
    }
}
