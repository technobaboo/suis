using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {

    public enum InputType {
        Controller,
        Hand,
        Head,
        Pointer
    }

    public enum ActionType
    {
        Scale,
        Translate,

    }

    public enum ControllerFeatures {
        ActionButtons,
        Joystick,
        Trackpad,
        MenuButton,
        HomeButton,
        AnalogTrigger,
        DigitalTrigger,
        AnalogGrip,
        DigitalGrip
    }

    public enum DigitalControllerButtons {
        A,
        B,
        X,
        Y,
        Trigger,
        Grip,
        Menu,
        Home
    }

}
