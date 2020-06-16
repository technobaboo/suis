using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    [RequireComponent(typeof(ActionTrigger))]
    public class InputHandler : MonoBehaviour
    {
        public bool rejectAction = false;

        public Field field;
        
        [SerializeField]
        private List<ActionTrigger> actionTriggers;
        public List<ActionTrigger> ActionTriggers { get { return actionTriggers; } }

        private void Awake()
        {
            actionTriggers.AddRange(GetComponents<ActionTrigger>());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}