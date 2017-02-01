using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(PoolManager))]
[RequireComponent(typeof(LoadLevelState))]
[RequireComponent(typeof(PlayWaveState))]
[RequireComponent(typeof(RestartLevelState))]

public class Level : StateMachine {

  #region Fields

  [SerializeField] GameObject pauseScreenPrefab;
  GameObject pauseScreen;

  [SerializeField] private GameObject hudPrefab;
  private GameObject hud;

  public List<LevelData.Level> GameData { get { return gameData; } }
  private List<LevelData.Level> gameData;

  public int CurrentLevel { get { return currentLevel; } }
  private int currentLevel = Config.InitialLevel;

  private IEnumerator loadLevelRoutine;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameData = ParseGameDataFiles();

    pauseScreen = Instantiate(pauseScreenPrefab, transform);
    pauseScreen.SetActive(false);

    hud = Instantiate(hudPrefab, transform);
  }

  void Start() {
    loadLevelRoutine = LoadLevelRoutine();
    StartCoroutine(loadLevelRoutine);
  }

  void OnEnable() {
    EventManager.StartListening<EscapeInput>(OnEscapeInput);
    EventManager.StartListening<EndWaveEvent>(OnEndWaveEvent);
    EventManager.StartListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StartListening<RestartScreenEvent>(OnRestartScreenEvent);
    EventManager.StartListening<StartGameEvent>(OnStartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EscapeInput>(OnEscapeInput);
    EventManager.StopListening<EndWaveEvent>(OnEndWaveEvent);
    EventManager.StopListening<EndLevelEvent>(OnEndLevelEvent);
    EventManager.StopListening<RestartScreenEvent>(OnRestartScreenEvent);
    EventManager.StopListening<StartGameEvent>(OnStartGameEvent);
  }

  #endregion

  #region Events Behaviour

  void OnEscapeInput(EscapeInput escapeInput) {
    if (Time.timeScale == Config.TimeScale)
      pauseScreen.SetActive(true);
    else
      pauseScreen.SetActive(false);
  }

  void OnEndWaveEvent(EndWaveEvent endWaveEvent) {
    ChangeState<PlayWaveState>();
  }

  void OnEndLevelEvent(EndLevelEvent endLevelEvent) {
    currentLevel++;
    loadLevelRoutine = LoadLevelRoutine();
    StartCoroutine(loadLevelRoutine);
  }

  void OnRestartScreenEvent(RestartScreenEvent restartScreenEvent) {
    hud.SetActive(false);
    ChangeState<RestartLevelState>();
  }

  void OnStartGameEvent(StartGameEvent startGameEvent) {
    hud.SetActive(true);
    currentLevel = Config.InitialLevel;

    loadLevelRoutine = LoadLevelRoutine();
    StartCoroutine(loadLevelRoutine);
  }

  #endregion

  #region Private Behaviour

  private List<LevelData.Level> ParseGameDataFiles() {
    List<LevelData.Level> levels = new List<LevelData.Level>();
    foreach (TextAsset textAsset in Resources.LoadAll(Config.GameDataPath).Cast<TextAsset>())
      levels.Add(JsonUtility.FromJson<LevelData.Level>(textAsset.text));

    return levels;
  }

  private IEnumerator LoadLevelRoutine() {
    ChangeState<LoadLevelState>();
    yield return new WaitForSeconds(2f);
    ChangeState<PlayWaveState>();
    StopCoroutine(loadLevelRoutine);
  }

  #endregion

}
