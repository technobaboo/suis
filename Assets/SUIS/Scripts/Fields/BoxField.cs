using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class BoxField : Field {
        public Vector3 size = Vector3.one;

        protected override float localDistance(Vector3 point) {
            Vector3 offsetPoint = point;
            offsetPoint.x = Mathf.Abs(offsetPoint.x) - (size.x / 2);
            offsetPoint.y = Mathf.Abs(offsetPoint.y) - (size.y / 2);
            offsetPoint.z = Mathf.Abs(offsetPoint.z) - (size.z / 2);

            Vector3 outsideVector = Vector3.zero;
            outsideVector.x = Mathf.Max(offsetPoint.x, 0.0f);
            outsideVector.y = Mathf.Max(offsetPoint.y, 0.0f);
            outsideVector.z = Mathf.Max(offsetPoint.z, 0.0f);

            float outsideDistance = outsideVector.magnitude;

            float insideDistance = Mathf.Min(Mathf.Max(offsetPoint.x, Mathf.Max(offsetPoint.y, offsetPoint.z)), 0);

            return outsideDistance;// + insideDistance;
        }
    }
}