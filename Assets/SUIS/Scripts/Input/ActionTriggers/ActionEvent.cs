using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SUIS
{
    [System.Serializable]
    public class ActionEvent : UnityEvent<InputMethod, float, InputHandler> {}
}