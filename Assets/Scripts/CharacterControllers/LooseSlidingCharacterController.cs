using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseSlidingCharacterController : CustomCharacterController
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
        ActivateSliding();
    }

    private void OnEnable()
    {
        InputManager.OnSpacePressed += DeactivateSliding;
        InputManager.OnSpacePressing += DeactivateSliding;
        InputManager.OnSpaceDepressed += ActivateSliding;
    }

    private void OnDisable()
    {
        InputManager.OnSpacePressed -= DeactivateSliding;
        InputManager.OnSpacePressing -= DeactivateSliding;
        InputManager.OnSpaceDepressed -= ActivateSliding;
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