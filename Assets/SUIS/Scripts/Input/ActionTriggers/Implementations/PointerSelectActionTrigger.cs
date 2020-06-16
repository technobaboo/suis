using System.Collections;
using System.Collections.Generic;
using SUIS;
using UnityEngine;


public class PointerSelectActionTrigger : ActionTrigger
{
    public float hoverRadius = 0.0f;

    protected override bool isPerformingAction(InputMethod inputMethod, float distance, InputHandler handler) {
        if (inputMethod.Type != InputType.Pointer)
            return false;
        PointerInput pointer = inputMethod as PointerInput;

        bool performingAction = pointer.Actions0D.ContainsKey("select") && pointer.Actions0D["select"];
        if (performingAction)
        {
            pointer.rejectAction = true;
            handler.rejectAction = true;
        }
        
        return performingAction;
    }
}
