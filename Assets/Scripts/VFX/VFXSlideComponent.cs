using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSlideComponent : MonoBehaviour
{
    [Header("Scene Objects")]
    public Rigidbody body;

    [Header("Variables")]
    public float activationThreshold;

    private ParticleSystem slideVFX;
    private bool isPlaying;
    private ParticleSystem.EmissionModule[] emissionModules;

    private void Start()
    {
        SelectSlideVFX(0);

        TrySetActive(false);
    }

    public void SelectSlideVFX(int index)
    {
        if(slideVFX != null)
        {
            Destroy(slideVFX.gameObject);
        }

        slideVFX = Instantiate(GameManager.instance.vfxContainer.slideVFXs[index].gameObject, transform.position, Quaternion.identity, transform).GetComponent<ParticleSystem>();
        ParticleSystem[] all = slideVFX.GetComponentsInChildren<ParticleSystem>();
        emissionModules = new ParticleSystem.EmissionModule[all.Length];
        for(int iSystem = 0; iSystem < all.Length; ++iSystem)
        {
            emissionModules[iSystem] = all[iSystem].emission;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TrySetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        TrySetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        TrySetActive(false);
    }

    private void TrySetActive(bool active)
    {
        if(active && body.velocity.sqrMagnitude >= activationThreshold * activationThreshold)
        {
            if(!isPlaying)
            {
                for(int iModule = 0; iModule < emissionModules.Length; ++iModule)
                {
                    emissionModules[iModule].enabled = true;
                }
                isPlaying = true;
            }
        }
        else
        {
            if(isPlaying)
            {
                for (int iModule = 0; iModule < emissionModules.Length; ++iModule)
                {
                    emissionModules[iModule].enabled = false;
                }
                isPlaying = false;
            }
        }
    }
}