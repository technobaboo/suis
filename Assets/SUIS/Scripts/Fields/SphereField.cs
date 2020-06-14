using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class SphereField : Field {
        public float radius = 0.5f;

        protected override float localDistance(Vector3 point) {
            return point.magnitude - radius;
        }

        protected override Vector3 localNormal(Vector3 point, float radius) {
            return point.normalized;
        }
    }
}