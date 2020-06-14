using System.Collections;
using System.Collections.Generic;
using SUIS;
using UnityEngine;


public class HoverActionTrigger : SUIS.ActionTrigger
{
    public float hoverRadius = 0.0f;

    protected void Awake() {
        type = InputType.Global | InputType.Controller | InputType.Pointer | InputType.Hand;
    }

    protected override bool isPerformingAction(SUIS.Input input, float distance, InputHandler handler) {
        return distance <= hoverRadius;
    }
}
