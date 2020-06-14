using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public enum BooleanOperation {
        Union,
        Difference,
        Intersect
    }

    public class BooleanField : Field {
        public BooleanOperation operation;
        public Field sdf1;
        public Field sdf2;

        protected override float localDistance(Vector3 point) {
            float distance1 = sdf1.distance(point);
            float distance2 = sdf2.distance(point);

            switch (operation) {
                case BooleanOperation.Union:
                    return Mathf.Min(distance1, distance2);
                case BooleanOperation.Difference:
                    return Mathf.Max(-distance1, distance2);
                case BooleanOperation.Intersect:
                    return Mathf.Max(distance1, distance2);
                default:
                    return 0;
            }
        }
    }

}