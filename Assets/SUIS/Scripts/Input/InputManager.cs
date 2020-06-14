using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public class InputManager : MonoBehaviour
    {
        #region Public Variables

        //Input devices
        [SerializeField]
        private List<InputDevice> devices;
        public List<InputDevice> Devices { get { return devices; } }

        //Input handlers
        [SerializeField]
        private List<InputHandler> handlers;
        public List<InputHandler> Handlers { get { return handlers; } }

        public bool autoAddChildrenOnStart = false;

        #endregion

        //Inputs
        private List<Input> inputs = new List<Input>();

        private struct InputHandlerLink {
            public Input input;
            public float distance;
            public InputHandler handler;
        }

        private void Start() {
            if (autoAddChildrenOnStart) {
                for (int i = 0; i < transform.childCount; ++i)
                {
                    InputHandler handler = transform.GetChild(i).GetComponent<InputHandler>();
                    if (handler != null)
                        handlers.Add(handler);

                    InputDevice device = transform.GetChild(i).GetComponent<InputDevice>();
                    if (device != null)
                    {
                        devices.Add(device);
                    }
                }
            }

            foreach(InputDevice device in devices) {
                inputs.AddRange(device.Inputs);
            }
        }

        private void FixedUpdate() {
            //Refresh the rejection of actions
            foreach (Input input in inputs)
                input.rejectAction = false;
            foreach (InputHandler handler in handlers)
                handler.rejectAction = false;

            //Create representations of input interaction with input handlers
            float maxDistance = 0.0f;
            List<InputHandlerLink> distanceLinks = new List<InputHandlerLink>();
            foreach (InputHandler handler in handlers) {
                maxDistance = Mathf.Max(maxDistance, handler.maxDistance);
                foreach (Input input in inputs) {
                    if (!input.isTracked || !input.enabled)
                        continue;
                    InputHandlerLink link = new InputHandlerLink();
                    link.input = input;
                    link.handler = handler;

                    if (input.Type == InputType.Global)
                        link.distance = handler.maxDistance - 0.001f;
                    else
                        link.distance = input.distanceToField(handler.field);

                    distanceLinks.Add(link);
                }
            }
            
            //Repeat enough times so that all links are covered
            for (int i = 0; i < distanceLinks.Count; ++i)
            {
                bool linkValid = false;
                InputHandlerLink linkToProcess = new InputHandlerLink();
                float minDistance = maxDistance;

                //Look for next link to process
                for (int j = distanceLinks.Count - 1; j > -1; --j)
                {
                    if (distanceLinks[j].distance < minDistance) {
                        minDistance = distanceLinks[j].distance;
                        linkToProcess = distanceLinks[j];
                        linkValid = true;
                    } else
                        continue;
                }

                distanceLinks.Remove(linkToProcess);

                Debug.Log(linkToProcess);

                if (linkValid && !linkToProcess.input.rejectAction && !linkToProcess.handler.rejectAction) {
                    List<ActionTrigger> actionTriggers = linkToProcess.handler.ActionTriggers;
                    foreach (ActionTrigger actionTrigger in actionTriggers) {
                        actionTrigger.testAction(linkToProcess.input, linkToProcess.distance, linkToProcess.handler);
                    }
                }
            }
        }
    }
}