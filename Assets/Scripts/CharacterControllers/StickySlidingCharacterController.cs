using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySlidingCharacterController : CustomCharacterController
{
    [Header("Prefabs")]
    public PhysicMaterial slidingMaterial;
    public PhysicMaterial frictionMaterial;

    private new Collider collider;

    protected override void Awake()
    {
        base.Awake();

        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        DeactivateSliding();
    }

    private void OnEnable()
    {
        InputManager.OnSpacePressed += ActivateSliding;
        InputManager.OnSpaceDepressed += DeactivateSliding;
    }

    private void OnDisable()
    {
        InputManager.OnSpacePressed -= ActivateSliding;
        InputManager.OnSpaceDepressed -= DeactivateSliding;
    }

    private void ActivateSliding()
    {
        collider.sharedMaterial = slidingMaterial;
    }

    private void DeactivateSliding()
    {
        collider.sharedMaterial = frictionMaterial;
    }
}