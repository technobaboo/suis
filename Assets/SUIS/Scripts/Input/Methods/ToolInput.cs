using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public abstract class ToolInput : InputMethod
    {
        public Dictionary<string, bool>    RawInputs0D { get { return rawInputs0d; } }
        public Dictionary<string, float>   RawInputs1D { get { return rawInputs1d; } }
        public Dictionary<string, Vector2> RawInputs2D { get { return rawInputs2d; } }
        public Dictionary<string, Vector3> RawInputs3D { get { return rawInputs3d; } }

        protected Dictionary<string, bool>    rawInputs0d = new Dictionary<string, bool>();
        protected Dictionary<string, float>   rawInputs1d = new Dictionary<string, float>();
        protected Dictionary<string, Vector2> rawInputs2d = new Dictionary<string, Vector2>();
        protected Dictionary<string, Vector3> rawInputs3d = new Dictionary<string, Vector3>();
    }
}