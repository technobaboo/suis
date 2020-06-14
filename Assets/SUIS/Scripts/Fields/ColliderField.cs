using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class ColliderField : Field {
        private void OnEnable() { supportsInsideDistance = false; }

        public new Collider collider;

        protected override float localDistance(Vector3 point) {
            return Vector3.Distance(point, localClosestPoint(point, normalRadius));
        }
        protected override Vector3 localClosestPoint(Vector3 point, float normalRadius) {
            return transform.InverseTransformPoint(collider.ClosestPoint(globalPoint));
        }
    }
}