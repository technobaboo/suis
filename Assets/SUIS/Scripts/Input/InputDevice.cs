using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public class InputDevice : MonoBehaviour
    {
        [SerializeField]
        private List<Input> inputs = new List<Input>();
        public List<Input> Inputs { get { return inputs; } }

        public bool autoAddChildrenOnAwake = false;

        private void Start() {
            if(autoAddChildrenOnAwake) {
                for(int i=0; i<transform.childCount; ++i) {
                    Input input = transform.GetChild(i).GetComponent<Input>();
                    if (input != null)
                        AddInput(input);
                }
            }
        }

        public void AddInput(Input input) {
            if (!inputs.Contains(input)) {
                input.device = this;
                inputs.Add(input);
            }
        }
        public void RemoveInput(Input input) {
            if (inputs.Contains(input))
                inputs.Remove(input);
        }
    }
}