using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {

    public enum ActionType {
        Hand,
        Controller,
        Pointer
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
