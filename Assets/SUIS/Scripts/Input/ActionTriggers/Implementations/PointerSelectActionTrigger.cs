using System.Collections;
using System.Collections.Generic;
using SUIS;
using UnityEngine;


public class PointerSelectActionTrigger : SUIS.PointerActionTrigger
{
    public float hoverRadius = 0.0f;

    protected override bool isPerformingAction(PointerInput input, float distance, InputHandler handler)
    {
        bool performingAction = input.inputs0d.ContainsKey("select") && input.inputs0d["select"];
        if (performingAction)
        {
            input.rejectAction = true;
            handler.rejectAction = true;
        }
        
        return performingAction;
    }
}
