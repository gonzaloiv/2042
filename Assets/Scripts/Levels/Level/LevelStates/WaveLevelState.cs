using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveLevelState : State {

  #region Fields

  private Level level;

  private List<GameObject> waveObjects;
  private IEnumerator spawningRoutine;
  private bool gameOver = false;

  #endregion

  #region Mono Behaviour

  void Awake() {
    level = GetComponent<Level>();
    waveObjects = new List<GameObject>();
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    StartCoroutine(SpawningRoutine());
  }

  public override void Exit() {
    base.Exit();

    StopAllCoroutines();
    gameOver = false;
  }

  protected override void AddListeners() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  protected override void RemoveListeners() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  #endregion

  #region Event Behaviour

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    gameOver = true;
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawningRoutine() {
    LevelData.Wave currentWave = level.GetCurrentWaveData();
    waveObjects = WaveSpawner.SpawnWave(currentWave);

    if (currentWave.duration != 0)
      yield return new WaitForSeconds(currentWave.duration);

    if (currentWave.isChiefWave)
      StartCoroutine(ChiefRoutine());
    else
      StartCoroutine(WaveRoutine());
  }

  private IEnumerator WaveRoutine() {
    if (level.HasMoreWaves())
      EventManager.TriggerEvent(new EndWaveEvent());

    while (HasActiveChildren())
      yield return new WaitForSeconds(.1f);

    if (gameOver)
      EventManager.TriggerEvent(new RestartScreenEvent());
    else
      EventManager.TriggerEvent(new EndLevelEvent());
  }

  private IEnumerator ChiefRoutine() {
    while (HasActiveChildren()) {
      if (gameOver) {
        EventManager.TriggerEvent(new RestartScreenEvent());
        waveObjects.ForEach(x => x.SetActive(false));
      }
      yield return new WaitForSeconds(.1f);
    }
    EventManager.TriggerEvent(new EndLevelEvent());
  }

  private bool HasActiveChildren() {
    return waveObjects.Where(x => x.activeInHierarchy).Count() != 0;
  }

  #endregion
 
}
