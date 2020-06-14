using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {

    public abstract class Field : MonoBehaviour {
        public float normalRadius = 0.0001f;

        protected bool supportsInsideDistance = true;

        protected Vector3 localPoint;
        protected Vector3 globalPoint;

        protected abstract float localDistance(Vector3 point);
        protected virtual Vector3 localNormal(Vector3 point, float radius) {
            float d = localDistance(point);
            Vector2 e = new Vector2(radius, 0);

            Vector3 n = new Vector3(d, d, d) - new Vector3(
                localDistance(new Vector3(e.x, e.y, e.y)),
                localDistance(new Vector3(e.y, e.x, e.y)),
                localDistance(new Vector3(e.y, e.y, e.x)));

            return n.normalized;
        }
        protected virtual Vector3 localClosestPoint(Vector3 point, float normalRadius) {
            return point - (localNormal(point, normalRadius) * localDistance(point));
        }

        public float distance(Vector3 point) {
            globalPoint = point;
            localPoint = transform.InverseTransformPoint(point);
            if (transform.localScale == Vector3.one) {
                //Unscaled
                return localDistance(localPoint);
            } else if (transform.localScale.x == transform.localScale.y && transform.localScale.y == transform.localScale.z) {
                //Uniformly scaled
                float scaleFactor = transform.localScale.x;
                return localDistance(localPoint * scaleFactor);
            } else {
                //Non-uniformly scaled, slow
                Vector3 localSurfacePoint = localClosestPoint(localPoint, normalRadius);
                Vector3 surfacePoint = transform.TransformPoint(localSurfacePoint);
                float distance = Vector3.Distance(point, surfacePoint);

                //Don't calculate the distance for its sign if we already know the field doesn't support it
                if (!supportsInsideDistance || distance == 0.0f) {
                    return distance;
                } else {
                    float localScaledDistance = localDistance(localPoint);
                    return distance * Mathf.Sign(localScaledDistance);
                }
            }
        }
        public Vector3 closestPoint(Vector3 point) {
            globalPoint = point;
            localPoint = transform.InverseTransformPoint(point);
            Vector3 localNearestPoint = localClosestPoint(localPoint, normalRadius);
            return transform.TransformPoint(localNearestPoint);
        }
        public Vector3 normal(Vector3 point, float radius) {
            globalPoint = point;
            localPoint = transform.InverseTransformPoint(point);
            Vector3 localDirection = localNormal(localPoint, radius);
            return transform.TransformDirection(localDirection);
        }
        public Vector3 normal(Vector3 point) { return normal(point, normalRadius); }
    }

}
