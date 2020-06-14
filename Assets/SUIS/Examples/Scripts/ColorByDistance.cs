using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SUIS;

public class ColorByDistance : MonoBehaviour
{
    public Gradient colorGradient;
    public float minDist;
    public float maxDist;

    private new MeshRenderer renderer;

    private void OnEnable() {
        renderer = GetComponent<MeshRenderer>();
    }

    private float map(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue) {
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

    public void UpdateColor(SUIS.Input input, float distance, InputHandler handler) {
        UpdateColor(distance);
    }

    public void UpdateColor(float distance) {
        renderer.material.color = colorGradient.Evaluate(map(minDist, maxDist, 0, 1, distance));
    }
}
