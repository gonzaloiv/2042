using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject playerPrefab;
  [SerializeField] private GameObject backgroundPrefab;
  [SerializeField] private GameObject levelPrefab;
  [SerializeField] private GameObject shotPrefab;

  #endregion

  #region Mono Behaviour

  void Awake() {
    Physics2D.gravity = Config.GlobalGravity;
    Application.targetFrameRate = 60;

    PoolManager.CreateGameObjectPool("ShotPool", shotPrefab, 30, transform);

    Instantiate(playerPrefab, transform);
    Instantiate(backgroundPrefab, transform);
    Instantiate(levelPrefab, transform);
  }

  #endregion

}
