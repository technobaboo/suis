using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exposure : MonoBehaviour {
    public Transform pointer;
    public float stepSize = 0.01f;
    public int maxSteps = 100;
    public float exposure = 0.0f;
    public float exposureSpeed = 10.0f;
    public float activationExposure = 100.0f;
    public float radius = 0.1f;
    public SUIS.SDF sdf;
	Renderer renderer;
    public Color startColor;
    public Color endColor;
    public UnityEvent OnExposedStart;
    public UnityEvent OnExposed;
    public UnityEvent OnExposedEnd;
    public bool isExposed = false;
    private bool wasExposed = false;

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

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

        isExposed = exposure == activationExposure;

        if(isExposed != wasExposed) {
            if(wasExposed)
                OnExposedEnd.Invoke();
            else
                OnExposedStart.Invoke();
        }

        if(isExposed) {
            OnExposed.Invoke();
        }

        wasExposed = isExposed;
        renderer.material.color = Color.Lerp(startColor, endColor, exposure / activationExposure);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(pointer.position, pointer.forward);
    }
}
