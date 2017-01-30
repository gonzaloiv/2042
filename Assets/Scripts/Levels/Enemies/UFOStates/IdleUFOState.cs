using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {

  #region Fields

  protected Vector3 rotation;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rotation = new Vector3(0, 0, Random.Range(0, 2));
  }

  void Update() {
    transform.Rotate(rotation  * Time.timeScale);
  }

  #endregion
 
}
