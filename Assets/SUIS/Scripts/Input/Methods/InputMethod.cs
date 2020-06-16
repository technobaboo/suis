using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    public abstract class InputMethod : MonoBehaviour {

        #region Basic Metadata
        public new string name;
        protected InputType type;
        public InputType Type { get { return type; } }
        public InputDevice device;
        public bool rejectAction = false;
        public bool isTracked = true;
        #endregion

        #region Actions
        public Dictionary<string, bool>    Actions0D { get { return actions0d; } }
        public Dictionary<string, float>   Actions1D { get { return actions1d; } }
        public Dictionary<string, Vector2> Actions2D { get { return actions2d; } }
        public Dictionary<string, Vector3> Actions3D { get { return actions3d; } }

        protected Dictionary<string, bool>    actions0d = new Dictionary<string, bool>();
        protected Dictionary<string, float>   actions1d = new Dictionary<string, float>();
        protected Dictionary<string, Vector2> actions2d = new Dictionary<string, Vector2>();
        protected Dictionary<string, Vector3> actions3d = new Dictionary<string, Vector3>();
        #endregion

        public abstract float distanceToField(Field field);
    }
}