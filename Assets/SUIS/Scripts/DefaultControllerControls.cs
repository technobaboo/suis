using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public class DefaultControllerControls : MonoBehaviour
    {
        public ToolInput toolInput = null;
        public bool isRightController = false;

        //void Start()
        //{
        //    if(toolInput == null)
        //        toolInput = GetComponent<ToolInput>();
        //
        //    //Add trigger
        //    toolInput.inputs0d.Add("trigger", false);
        //    toolInput.inputs1d.Add("trigger", 0.0f);
        //
        //    //Add grip
        //    toolInput.inputs0d.Add("grip", false);
        //    toolInput.inputs1d.Add("grip", 0.0f);
        //
        //    //Add actions
        //    toolInput.inputs0d.Add("select", false);
        //    toolInput.inputs0d.Add("grab", false);
        //}
        //
        //void Update()
        //{
        //    //Update trigger
        //    float trigger = UnityEngine.Input.GetAxis(isRightController ? "TriggerR" : "TriggerL");
        //    toolInput.inputs0d["trigger"] = trigger == 1.0f;
        //    toolInput.inputs1d["trigger"] = trigger;
        //
        //    //Update grip
        //    float grip = UnityEngine.Input.GetAxis(isRightController ? "GripR" : "GripL");
        //    toolInput.inputs0d["grip"] = grip == 1.0f;
        //    toolInput.inputs1d["grip"] = grip;
        //
        //    //Update actions
        //    toolInput.inputs0d["select"] = toolInput.inputs0d["trigger"];
        //    toolInput.inputs0d["grab"] = toolInput.inputs0d["grip"];
        //}
    }
}