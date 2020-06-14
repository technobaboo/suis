using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public struct RayMarchInfo
    {
        public Ray ray;
        public float distance;
        public Vector3 deepestPoint;
        public Vector3 deepestSurfacePoint;
        public float rayLength;
        public int raySteps;
    }

    public class RayMarch
    {
        public Ray ray;

        public int minRaySteps = 0;
        public int maxRaySteps = 1000;

        public float minRayMarch = 0.001f;
        public float maxRayMarch = float.PositiveInfinity;

        public float minRayLength = 0.0f;
        public float maxRayLength = 1000.0f;

        public RayMarchInfo March(Field field)
        {
            RayMarchInfo info = new RayMarchInfo {
                ray = this.ray,
                distance = float.PositiveInfinity,
                rayLength = 0.0f,
                raySteps = 0
            };

            Vector3 rayPoint = ray.origin;

            while (info.raySteps < maxRaySteps && info.rayLength < maxRayLength) {
                info.raySteps++;

                float distance = field.distance(rayPoint);
                if(info.distance > distance)
                    info.deepestPoint = rayPoint;
                info.distance = Mathf.Min(distance, info.distance);

                float marchDistance = Mathf.Clamp(distance, minRayMarch, maxRayMarch);
                rayPoint += marchDistance * ray.direction;
                info.rayLength += marchDistance;
            }

            info.deepestSurfacePoint = field.closestPoint(info.deepestPoint);

            return info;
        }
    }
}