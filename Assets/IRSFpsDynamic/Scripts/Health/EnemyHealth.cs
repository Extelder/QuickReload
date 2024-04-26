using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class EnemyHealth : Health
{
    [SerializeField] private ParticleSystem _onEnemyHealingParticleSystem;
    [field: SerializeField] public float PlayerHealValue { get; private set; } = 20f;

    private Random _random;

    public UnityEvent Death;

    private void OnEnable()
    {
        Healed += OnHealed;
    }

    private void OnDisable()
    {
        Healed -= OnHealed;
    }

    private void OnHealed()
    {
        _onEnemyHealingParticleSystem.Play();
    }

    public void TakeDamage(float value, float stunChance)
    {
        TakeDamage(value);
    }

    public override void HealthBelowOrEqualsZero()
    {
        if (Dead)
            return;
        AddAmmoToWeaponsAfterEnemyDeath.Instance?.OnEnemyKilled();
        Death?.Invoke();
        base.HealthBelowOrEqualsZero();
    }
}