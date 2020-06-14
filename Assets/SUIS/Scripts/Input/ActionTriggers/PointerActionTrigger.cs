using System.Collections;
using System.Collections.Generic;
using SUIS;
using UnityEngine;

namespace SUIS {
    public abstract class PointerActionTrigger : SUIS.ActionTrigger
    {
        private void Awake() {
            type = InputType.Pointer;
        }

        protected override bool isPerformingAction(Input input, float distance, InputHandler handler) {
            return isPerformingAction(input as PointerInput, distance, handler);
        }

        protected abstract bool isPerformingAction(PointerInput input, float distance, InputHandler handler);
    }
}