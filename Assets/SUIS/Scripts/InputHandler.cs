using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For each object created in the scene, create an InputHandler.
public abstract class InputHandler : MonoBehaviour {
  // ActionTriggers is an ordered list, where order dictates priority
  List<ActionTrigger> ActionTriggers = new List<ActionTrigger>();

  void Start() {
    print(gameObject.name);
  }
}
