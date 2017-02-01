using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour {

  #region State Behaviour

  void OnEnable() {
    Time.timeScale = 0;
  }

  void OnDisable() {
    Time.timeScale = Config.TimeScale;
  }

  #endregion




}
