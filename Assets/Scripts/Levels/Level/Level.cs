﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolManager))]
[RequireComponent(typeof(LoadLevelState))]
[RequireComponent(typeof(PlayLevelState))]
[RequireComponent(typeof(RestartLevelState))]

public class Level : StateMachine {

  #region Fields
 
  public GameData.Game GameData { get { return gameData; } }
  public int CurrentLevel { get { return currentLevel; } }

  private GameData.Game gameData;
  private IEnumerator levelRoutine;

  private int currentLevel = 1;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameData = ParseGameDataFile();
    levelRoutine = LevelRoutine();
  }

  void OnEnable() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
    StartCoroutine(levelRoutine);
  }

  void OnDisable() {
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StopListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
    StopCoroutine(levelRoutine);
  }

  #endregion

  #region Events Behaviour

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    ChangeState<RestartLevelState>();
  }

  void OnEndLevelEvent(EndLevelEvent endLevelEvent) {
    currentLevel++;
    levelRoutine = LevelRoutine();
    StartCoroutine(levelRoutine);
  }

  private void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    EventManager.TriggerEvent(new StartGameEvent());
    currentLevel = 1;
    levelRoutine = LevelRoutine();
    StartCoroutine(levelRoutine);
  }

  #endregion

  #region Private Behaviour

  private GameData.Game ParseGameDataFile() {
    string gameData = Resources.Load(Config.GameDataPath).ToString();
    return JsonUtility.FromJson<GameData.Game>(gameData);
  }

  private IEnumerator LevelRoutine() {
    yield return new WaitForSeconds(.5f);
    ChangeState<LoadLevelState>();
    yield return new WaitForSeconds(2);
    ChangeState<PlayLevelState>();
  }

  #endregion

}