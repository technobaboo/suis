using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class ColliderSDF : SDF {
        public Collider collider;

        public override float distance(Vector3 point) {
            point = transformPoint(point, transform);

            if(collider is SphereCollider) {
                SphereSDF sphere = GetComponent<SphereSDF>();
                if (sphere == null) gameObject.AddComponent<SphereSDF>();
                sphere.radius = (collider as SphereCollider).radius;
                return sphere.distance(point);
            }

            if(collider is BoxCollider) {
                BoxSDF box = GetComponent<BoxSDF>();
                if(box == null) gameObject.AddComponent<BoxSDF>();
                box.center = (collider as BoxCollider).center;
                box.size = (collider as BoxCollider).size;
                return box.distance(point);
            }
            
            return Vector3.Distance(point, collider.ClosestPoint(point));
        }
    }
}