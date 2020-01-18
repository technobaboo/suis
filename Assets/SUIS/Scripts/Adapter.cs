using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public class Adapter : MonoBehaviour {
        private Camera camera;
        public InputType inputType;
        public ActionType actionType;

        void Start() {
            camera = Camera.main;
        }

        void Update() {
            if (inputType == InputType.Head) {
                //HeadTransformer.handleAction(actionType);
            }
        }
    }
}