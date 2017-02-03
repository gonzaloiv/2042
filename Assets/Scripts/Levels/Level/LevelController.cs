using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(WaveSpawner))]
[RequireComponent(typeof(LoadLevelState))]
[RequireComponent(typeof(WaveLevelState))]
[RequireComponent(typeof(RestartLevelState))]
[RequireComponent(typeof(PauseScreenController))]

public class LevelController : StateMachine {

  #region Fields

  [SerializeField] private GameObject hudPrefab;
  private GameObject hud;

  private IEnumerator loadLevelRoutine;

  #endregion

  #region Mono Behaviour

  void Awake() {
    hud = Instantiate(hudPrefab, transform);
  }

  void Start() {
    StartLevel();
  }

  void OnEnable() {
    EventManager.StartListening<EndWaveEvent>(OnEndWaveEvent);
    EventManager.StartListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StartListening<RestartScreenEvent>(OnRestartScreenEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EndWaveEvent>(OnEndWaveEvent);
    EventManager.StopListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StopListening<RestartScreenEvent>(OnRestartScreenEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
  }

  #endregion

  #region Events Behaviour

  void OnEndWaveEvent(EndWaveEvent endWaveEvent) {
    ChangeState<WaveLevelState>();
  }

  void OnEndLevelEvent(EndLevelEvent endLevelEvent) {
    StartLevel();
  }

  void OnRestartScreenEvent(RestartScreenEvent restartScreenEvent) {
    hud.SetActive(false);
    ChangeState<RestartLevelState>();
  }

  void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    StartLevel();
  }

  #endregion

  #region Private Behaviour

  private void StartLevel() {
    hud.SetActive(true);
    loadLevelRoutine = LoadLevelRoutine();
    StartCoroutine(loadLevelRoutine);
  }

  private IEnumerator LoadLevelRoutine() {
    ChangeState<LoadLevelState>();
    yield return new WaitForSeconds(2f);
    ChangeState<WaveLevelState>();
//    StopCoroutine(loadLevelRoutine);
  }

  #endregion

}
