using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenController : MonoBehaviour {

  #region Fields

  [SerializeField] GameObject pauseScreenPrefab;
  GameObject pauseScreen;

  #endregion

  #region State Behaviour

  void Awake() {
    pauseScreen = Instantiate(pauseScreenPrefab, transform);
    pauseScreen.SetActive(false);
  }

  void OnEnable() {
    EventManager.StartListening<EscapeInput>(OnEscapeInput);
  }

  void OnDisable() {
    EventManager.StopListening<EscapeInput>(OnEscapeInput);
  }

  #endregion

  #region Event Behaviour

  void OnEscapeInput(EscapeInput escapeInput) {
    if (Time.timeScale == Config.TimeScale) {
      TimeManager.StopTime();
      pauseScreen.SetActive(true);
    } else {
      TimeManager.StartTime();
      pauseScreen.SetActive(false);
    }
  }

  #endregion

}
