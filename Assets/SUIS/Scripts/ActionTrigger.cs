using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{

  public void scaleByVelocity(Vector3 velocity)
  {
    transform.localScale += velocity;
  }

  public void translateByVelocity(Vector3 velocity)
  {
    transform.Translate(
      velocity.x,
      velocity.y,
      velocity.z
    );
  }
}
