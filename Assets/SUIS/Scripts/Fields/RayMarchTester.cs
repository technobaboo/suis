using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SUIS;
public class RayMarchTester : MonoBehaviour
{
    public Field field;
    private Ray ray;

    [SerializeField]
    private RayMarchInfo marchInfo;

    private RayMarch rayMarch = new RayMarch();
    
    private void OnDrawGizmos() {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        rayMarch.ray = ray;
        marchInfo = rayMarch.March(field);

        Gizmos.DrawRay(ray);
        Gizmos.DrawLine(transform.position, new Vector3(0, 0, transform.InverseTransformPoint(marchInfo.deepestSurfacePoint).z));
        Gizmos.DrawLine(marchInfo.deepestPoint, marchInfo.deepestSurfacePoint);
    }
}
