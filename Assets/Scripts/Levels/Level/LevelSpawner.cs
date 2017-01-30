using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject playerPrefab;
  [SerializeField] private GameObject hudPrefab;

  private PoolManager poolManager;
  private GameData.Levels gameData;
  private int currentLevel = 0;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameData = ParseGameDataFile();

    poolManager = GetComponent<PoolManager>();
    poolManager.InitializePools();

    Instantiate(playerPrefab, transform);
    Instantiate(hudPrefab, transform);
  }

  void Start() {
    StartCoroutine(SpawningRoutine(gameData.levels[currentLevel]));
  }

  #endregion

  #region Private Behaviour

  private GameData.Levels ParseGameDataFile() {
    string gameData = Resources.Load(Config.GameDataPath).ToString();
    return JsonUtility.FromJson<GameData.Levels>(gameData);
  }

  private IEnumerator SpawningRoutine(GameData.Level level) {
    for (int i = 0; i < level.waves.Length; i++) {
      yield return new WaitForSeconds(1);
      SpawnEnemies(level.waves[i]);
    }
    // Infinite loop for testing
    StopCoroutine(SpawningRoutine(level));
    StartCoroutine(SpawningRoutine(level));
  }

  private void SpawnEnemies(GameData.Wave wave) {
    for (int i = 0; i < wave.enemies.Length; i++)
      SpawnEnemy(wave.enemies[i]);
  }

  private void  SpawnEnemy(GameData.Enemy enemyData) {
    for (int i = 0; i < enemyData.amount; i++) {
      GameObject enemy = poolManager.EnemyPools[(int) enemyData.type].PopObject();
      enemy.transform.position = new Vector3(Random.Range(-7, 7), 6, 0);
      enemy.SetActive(true);
    }
  }

  #endregion
}
