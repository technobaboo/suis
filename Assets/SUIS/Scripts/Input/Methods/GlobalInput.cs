using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public class GlobalInput : ToolInput
    {
        private void Awake() { type = InputType.Global; }

        public override float distanceToField(Field field)
        {
            return float.PositiveInfinity;
        }
    }
}