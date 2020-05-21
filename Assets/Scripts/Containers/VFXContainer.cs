using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VFXContainer", menuName = "VFXContainer", order = 0)]
public class VFXContainer : ScriptableObject
{
    public ParticleSystem[] slideVFXs;
}