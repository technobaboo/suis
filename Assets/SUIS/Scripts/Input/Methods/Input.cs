using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public abstract class Input : MonoBehaviour
    {
        public new string name;
        protected InputType type;
        public InputType Type { get { return type; } }
        public InputDevice device;
        public bool rejectAction = false;
        public bool isTracked = true;

        public abstract float distanceToField(Field field);
    }
}