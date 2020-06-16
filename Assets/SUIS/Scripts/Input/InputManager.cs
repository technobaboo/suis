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

        //Input Methods
        private List<InputMethod> inputMethods = new List<InputMethod>();

        private struct InputHandlerLink {
            public InputMethod inputMethod;
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
                inputMethods.AddRange(device.InputMethods);
            }
        }

        private void FixedUpdate() {
            //Refresh the rejection of actions
            foreach (InputMethod inputMethod in inputMethods)
                inputMethod.rejectAction = false;
            foreach (InputHandler handler in handlers)
                handler.rejectAction = false;

            //Create representations of input interaction with input handlers
            List<InputHandlerLink> distanceLinks = new List<InputHandlerLink>();
            foreach (InputHandler handler in handlers) {
                foreach (InputMethod inputMethod in inputMethods) {
                    if (!inputMethod.isTracked || !inputMethod.enabled)
                        continue;
                    InputHandlerLink link = new InputHandlerLink();
                    link.inputMethod = inputMethod;
                    link.handler = handler;

                    if (inputMethod.Type == InputType.Global)
                        link.distance = Mathf.Infinity;
                    else
                        link.distance = inputMethod.distanceToField(handler.field);

                    distanceLinks.Add(link);
                }
            }
            
            //Repeat enough times so that all links are covered
            for (int i = 0; i < distanceLinks.Count; ++i)
            {
                bool linkValid = false;
                InputHandlerLink linkToProcess = new InputHandlerLink();
                float minDistance = Mathf.Infinity;

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

                if (linkValid && !linkToProcess.inputMethod.rejectAction && !linkToProcess.handler.rejectAction) {
                    List<ActionTrigger> actionTriggers = linkToProcess.handler.ActionTriggers;
                    foreach (ActionTrigger actionTrigger in actionTriggers) {
                        actionTrigger.testAction(linkToProcess.inputMethod, linkToProcess.distance, linkToProcess.handler);
                    }
                }
            }
        }
    }
}