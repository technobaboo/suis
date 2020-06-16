using System.Collections;
using System.Collections.Generic;
using SUIS;
using UnityEngine;

namespace SUIS {
    public abstract class PointerActionTrigger : ActionTrigger
    {
        private void Awake() {
            type = InputType.Pointer;
        }

        protected override bool isPerformingAction(InputMethod inputMethod, float distance, InputHandler handler) {
            return isPerformingAction(inputMethod as PointerInput, distance, handler);
        }

        protected abstract bool isPerformingAction(PointerInput input, float distance, InputHandler handler);
    }
}