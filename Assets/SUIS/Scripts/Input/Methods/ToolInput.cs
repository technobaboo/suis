using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS
{
    public abstract class ToolInput : Input
    {
        public Dictionary<string, bool> inputs0d    = new Dictionary<string, bool>();
        public Dictionary<string, float> inputs1d   = new Dictionary<string, float>();
        public Dictionary<string, Vector2> inputs2d = new Dictionary<string, Vector2>();
        public Dictionary<string, Vector3> inputs3d = new Dictionary<string, Vector3>();
    }
}