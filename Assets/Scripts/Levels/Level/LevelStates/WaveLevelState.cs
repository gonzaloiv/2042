using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveLevelState : State {

  #region Fields

  private Level level;
  private int currentLevel;

  private int currentWave = Config.InitialWave;
  private List<GameObject> waveObjects;
  private IEnumerator spawningRoutine;
  private bool gameOver = false;

  #endregion

  #region Mono Behaviour

  void Awake() {
    level = GetComponent<Level>();
    currentLevel = level.CurrentLevel;
    waveObjects = new List<GameObject>();
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();
   
    if (currentLevel != level.CurrentLevel)
      RestartState();
     
    spawningRoutine = SpawningRoutine();
    StartCoroutine(spawningRoutine);
  }

  public override void Exit() {
    base.Exit();

    StopCoroutine(spawningRoutine);
    currentWave++;
  }

  protected override void AddListeners() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  protected override void RemoveListeners() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  #endregion

  #region Event Behaviour

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    gameOver = true;
  }

  void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    gameOver = false;
    RestartState();
  }

  #endregion

  #region Private Behaviour

  private IEnumerator SpawningRoutine() {

    LevelData.Wave wave = level.GameData[currentLevel - 1].waves[currentWave - 1];
    waveObjects = WaveSpawner.SpawnWave(wave);

    if (wave.duration != 0)
      yield return new WaitForSeconds(wave.duration);

    if (gameOver) {
      EventManager.TriggerEvent(new RestartScreenEvent());
    } else if (LevelHasNextWave()) {
      EventManager.TriggerEvent(new EndWaveEvent());
    } else {
      while (HasActiveChildren())
        yield return new WaitForSeconds(.1f);
      // TODO: resolver problema durante la espera en caso de cambio de nivel con otro estado
      if (gameOver) {
        EventManager.TriggerEvent(new RestartScreenEvent());
      } else {
        EventManager.TriggerEvent(new EndLevelEvent());
      }
    }

  }

  private void RestartState() {
    currentLevel = level.CurrentLevel;
    currentWave = Config.InitialWave;
  }

  private bool LevelHasNextWave() {
    return level.GameData[currentLevel - 1].waves.Length > currentWave;
  }

  private bool HasActiveChildren() {
    return waveObjects.Where(x => x.activeInHierarchy).Count() != 0;
  }

  #endregion
 
}
