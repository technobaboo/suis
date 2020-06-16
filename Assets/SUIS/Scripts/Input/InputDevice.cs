using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public class InputDevice : MonoBehaviour
    {
        [SerializeField]
        private List<InputMethod> inputMethods = new List<InputMethod>();
        public List<InputMethod> InputMethods { get { return inputMethods; } }

        public bool autoAddChildrenOnAwake = false;

        private void Start() {
            if(autoAddChildrenOnAwake) {
                for(int i=0; i<transform.childCount; ++i) {
                    InputMethod inputMethod = transform.GetChild(i).GetComponent<InputMethod>();
                    if (inputMethod != null)
                        AddInputMethod(inputMethod);
                }
            }
        }

        public void AddInputMethod(InputMethod inputMethod) {
            if (!inputMethods.Contains(inputMethod)) {
                inputMethod.device = this;
                inputMethods.Add(inputMethod);
            }
        }
        public void RemoveInput(InputMethod inputMethod) {
            if (inputMethods.Contains(inputMethod))
                inputMethods.Remove(inputMethod);
        }
    }
}