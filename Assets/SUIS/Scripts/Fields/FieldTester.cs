using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUIS;

public class FieldTester : MonoBehaviour
{
    public Field field;

    private void OnDrawGizmos() {
        Vector3 closestSurfacePoint = field.closestPoint(transform.position);
        Gizmos.DrawLine(transform.position, closestSurfacePoint);
    }
}
