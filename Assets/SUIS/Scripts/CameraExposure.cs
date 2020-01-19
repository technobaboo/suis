using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraExposure : MonoBehaviour
{
    public Transform pointer;
    public float stepSize = 0.01f;
    public int maxSteps = 100;
    public float exposure = 0.0f;
    public float exposureSpeed = 10.0f;
    public float activationExposure = 100.0f;
    public float radius = 0.1f;
    public SUIS.SDF sdf;
    public Material material;
    public Color startColor;
    public Color endColor;
    public UnityEvent OnSelected;

    private void Update() {
        float minDist = Mathf.Infinity;
        Vector3 stepPoint = pointer.position;

        for (int i = 0; i < maxSteps; ++i) {
            float dist = sdf.distance(stepPoint);
            if(dist < minDist) {
                minDist = dist;
            }
            stepPoint += pointer.forward * stepSize;
        }
        float adjustedDist = -minDist + radius;
        exposure += adjustedDist * exposureSpeed * Time.deltaTime;
        exposure = Mathf.Clamp(exposure, 0, activationExposure);

        if(exposure == activationExposure) {
            OnSelected.Invoke();
        }

        material.color = Color.Lerp(startColor, endColor, exposure / activationExposure);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(pointer.position, pointer.forward);
    }
}
