using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class SphereSDF : SDF {
        public float radius = 0.5f;

        public override float distance(Vector3 point) {
            return transformPoint(point, transform).magnitude - radius;
        }
    }
}