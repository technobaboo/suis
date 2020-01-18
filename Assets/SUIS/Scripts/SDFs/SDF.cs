using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {

    public abstract class SDF : MonoBehaviour {
        public abstract float distance(Vector3 point);

        protected static Vector3 transformPoint(Vector3 point, Transform origin) {
            Quaternion inverseRotation = Quaternion.Inverse(origin.rotation);
            Vector3 inverseScale = Vector3.zero;
            inverseScale.x = 1 / origin.lossyScale.x;
            inverseScale.y = 1 / origin.lossyScale.y;
            inverseScale.z = 1 / origin.lossyScale.z;

            point -= origin.position;
            point = inverseRotation * point;
            point = Vector3.Scale(point, inverseScale);
            return point;
        }
    }

}
