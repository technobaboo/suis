using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteAlways]
public class LineRendererTargets : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform[] targets = new Transform[2];

    [Range(0.0f, 1.0f)]
    public float clipFirst = 0.0f;
    [Range(0.0f, 1.0f)]
    public float clipLast = 1.0f;

    private void Update()
    {
        if(targets[0] != null && targets[1] != null)
        {
            lineRenderer.SetPosition(0, Vector3.Lerp(targets[0].position, targets[1].position, clipFirst));
            lineRenderer.SetPosition(1, Vector3.Lerp(targets[0].position, targets[1].position, clipLast));
        }
    }
    
    private void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();

        Transform[] oldTargets = targets;
        targets = new Transform[lineRenderer.positionCount];

        for(int i=0;i<targets.Length;i++)
            if(oldTargets[i] != null)
                targets[i] = oldTargets[i];
    }
}
