using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {

    // PLAYER INPUT
    if (Time.timeScale != 0) {
      if (Input.GetKey(KeyCode.UpArrow))
        EventManager.TriggerEvent(new MoveUpInput());
      if (Input.GetKey(KeyCode.RightArrow))
        EventManager.TriggerEvent(new MoveRightInput());
      if (Input.GetKey(KeyCode.DownArrow))
        EventManager.TriggerEvent(new MoveDownInput());
      if (Input.GetKey(KeyCode.LeftArrow))
        EventManager.TriggerEvent(new MoveLeftInput());
      if (Input.GetKey(KeyCode.Space))
        EventManager.TriggerEvent(new PlayerShotInput());
    }

    // LEVEL INPUT
    if (Input.GetKeyDown(KeyCode.Escape))
      EventManager.TriggerEvent(new PauseLevelInput());
  }

  #endregion

}
