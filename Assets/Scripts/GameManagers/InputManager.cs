using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {

    // KEYBOARD PLAYER INPUT
    if (Time.timeScale != 0) {

      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        EventManager.TriggerEvent(new MoveUpInput());
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        EventManager.TriggerEvent(new MoveRightInput());
      if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        EventManager.TriggerEvent(new MoveDownInput());
      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        EventManager.TriggerEvent(new MoveLeftInput());

      if (Input.GetKey(KeyCode.Space))
        EventManager.TriggerEvent(new PlayerShotInput(Vector2.up));

      // MOUSE PLAYER INPUT
      if(Input.GetMouseButton(0))
        EventManager.TriggerEvent(new PlayerShotInput(Input.mousePosition));

    }
   
    // LEVEL INPUT
    if (Input.GetKeyDown(KeyCode.Escape))
      EventManager.TriggerEvent(new EscapeInput());
    if (Input.GetKeyDown(KeyCode.Return))
      EventManager.TriggerEvent(new EnterInput());

  }

  #endregion

}
