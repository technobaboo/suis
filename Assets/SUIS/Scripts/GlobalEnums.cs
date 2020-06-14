using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {
    [Flags]
    public enum InputType
    {
        None = 0,
        Global = 1,
        Controller = 2,
        Pointer = 4,
        Hand = 8
    }

}
