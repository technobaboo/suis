using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SUIS
{
    public abstract class ActionTrigger : MonoBehaviour {
        protected InputType type;
        public InputType Type { get { return type; } }

        private bool performedAction = false;
        private bool performingAction = false;
        
        public ActionEvent OnActionStarted;
        public ActionEvent OnActionUpdate;
        public ActionEvent OnActionEnded;

        public void testAction(Input input, float distance, InputHandler handler) {
            performedAction = performingAction;

            //Check if the input types are the same
            bool inputTypeMatches = (input.Type & type) != InputType.None;
            //If they are, check if the action is being performed
            performingAction = inputTypeMatches ? isPerformingAction(input, distance, handler) : false;
            
            if (!performedAction && performingAction)
                OnActionStarted.Invoke(input, distance, handler);
            if (performingAction)
                OnActionUpdate.Invoke(input, distance, handler);
            if (performedAction && !performingAction)
                OnActionEnded.Invoke(input, distance, handler);
        }

        protected abstract bool isPerformingAction(Input input, float distance, InputHandler handler);
    }
}