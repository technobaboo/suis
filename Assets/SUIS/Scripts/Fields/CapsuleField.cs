using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class CapsuleField : Field {
        public Vector3 pointA;
        public Vector3 pointB;
        public float radius;

        protected override float localDistance(Vector3 point) {
            float t = Vector3.Dot(point - pointA, point - pointB) / Vector3.Dot(point - pointB, point - pointB);

            t = Mathf.Clamp(t, 0, 1);

            Vector3 c = pointA + (t * (pointB - pointA));

            float d = Vector3.Distance(point, c) - radius;

            return d;
        }
    }
}