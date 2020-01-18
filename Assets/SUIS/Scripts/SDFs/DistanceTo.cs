using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIS;

public class DistanceTo : MonoBehaviour
{
    [SerializeField]
    float distance = 0.0f;

    public SDF sdf;

    [ExecuteInEditMode]
    void LateUpdate() {
        distance = sdf.distance(transform.position);
    }
}
