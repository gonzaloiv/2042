using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level : MonoBehaviour {

  #region Fields

  public List<LevelData.Level> GameData { get { return gameData; } }
  private List<LevelData.Level> gameData;

  public int CurrentLevel { get { return currentLevel; } }
  private int currentLevel = Config.InitialLevel;

  public int CurrentWave { get { return currentWave; } }
  private int currentWave = Config.InitialWave;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameData = ParseGameDataFiles();
  }

  void OnEnable() {
    EventManager.StartListening<EndWaveEvent>(OnEndWaveEvent);
    EventManager.StartListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EndWaveEvent>(OnEndWaveEvent);
    EventManager.StopListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
  }

  #endregion

  #region Events Behaviour

  void OnEndWaveEvent(EndWaveEvent endWaveEvent) {
    currentWave++;
  }

  void OnEndLevelEvent(EndLevelEvent endLevelEvent) {
    currentLevel++;
    currentWave = Config.InitialWave;
  }

  void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    currentLevel = Config.InitialLevel;
    currentWave = Config.InitialWave;
  }

  #endregion

  public LevelData.Wave GetCurrentWaveData() {
    return gameData[currentLevel - 1].waves[currentWave - 1];
  }

  public bool HasMoreWaves() {
    return gameData[currentLevel - 1].waves.Length > currentWave;
  }

  #region Private Behaviour

  private List<LevelData.Level> ParseGameDataFiles() {
    List<LevelData.Level> levels = new List<LevelData.Level>();
    foreach (TextAsset textAsset in Resources.LoadAll(Config.GameDataPath).Cast<TextAsset>())
      levels.Add(JsonUtility.FromJson<LevelData.Level>(textAsset.text));

    return levels;
  }

  #endregion

}
