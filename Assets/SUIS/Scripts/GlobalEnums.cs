using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SUIS {

    enum ActionType {
        Hand,
        Controller,
        Pointer
    }

    enum ControllerFeatures {
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

    enum DigitalControllerButtons {
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
