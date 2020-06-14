using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public class PointerInput : ToolInput
    {
        private void Start() { type = InputType.Pointer; }

        RayMarch rayMarch = new RayMarch();
        RayMarchInfo rayMarchInfo;

        public override float distanceToField(Field field) {
            rayMarch.ray.origin = transform.position;
            rayMarch.ray.direction = transform.forward;
            rayMarchInfo = rayMarch.March(field);
            return rayMarchInfo.distance;
        }
    }
}