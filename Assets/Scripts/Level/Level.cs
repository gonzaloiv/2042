using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] meteorPrefabs;
  [SerializeField] private GameObject[] ufoPrefabs;
  [SerializeField] private GameObject hudPrefab;

  private List<GameObjectArrayPool> enemyPools;

  private GameObjectPool shotPool;
  private Transform levelEnemies;

  private GameData.Levels gameData;
  private int currentLevel = 0;

  #endregion

  #region Mono Behaviour

  void Awake() {
    gameData = ParseGameDataFile();

    enemyPools = new List<GameObjectArrayPool>();

    levelEnemies = new GameObject("LevelEnemies").transform;
    levelEnemies.SetParent(transform);
 
    enemyPools.Add(PoolManager.CreateGameObjectPool("MeteorPool", meteorPrefabs, 20, levelEnemies));
    enemyPools.Add(PoolManager.CreateGameObjectPool("UFOPool", ufoPrefabs, 10, levelEnemies));

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
      SpawnEnemies(level.waves[i]);
      yield return new WaitForSeconds(1);
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
      GameObject enemy = enemyPools[(int) enemyData.type].PopObject();
      enemy.transform.position = new Vector3(Random.Range(-7, 7), 6, 0);
      enemy.SetActive(true);
    }
  }

  #endregion
}
