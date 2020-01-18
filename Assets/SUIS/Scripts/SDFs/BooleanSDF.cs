using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public enum BooleanOperation {
        Union,
        Difference,
        Intersect
    }

    public class BooleanSDF : SDF {
        public BooleanOperation operation;
        public SDF sdf1;
        public SDF sdf2;

        public override float distance(Vector3 point) {
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