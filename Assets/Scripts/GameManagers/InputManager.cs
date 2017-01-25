using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {
    if (Input.GetKey("space"))
      EventManager.TriggerEvent(new PlayerShotInput());
    if (Input.GetKey("right"))
      EventManager.TriggerEvent(new MoveRightInput());
    if (Input.GetKey("left"))
      EventManager.TriggerEvent(new MoveLeftInput());
    if (Input.GetKey("down"))
      EventManager.TriggerEvent(new MoveDownInput());
    if (Input.GetKey("up"))
      EventManager.TriggerEvent(new MoveUpInput());
  }

  #endregion

}
