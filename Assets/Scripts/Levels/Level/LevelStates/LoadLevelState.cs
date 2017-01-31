using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelState : State {

  #region Fields

  [SerializeField] private GameObject playerPrefab;
  [SerializeField] private GameObject loadScreenPrefab; 

  private PoolManager poolManager;
  private Level level;

  private GameObject loadScreen;
  private Text loadScreenLabel;
  private string loadScreenInitialText = "LEVEL ";

  #endregion

  #region State Behaviour

  void Awake() {
    level = GetComponent<Level>();    
    poolManager = GetComponent<PoolManager>();

    // Orden de ejecución según dependencias...
    poolManager.InitializeShotPool();
    Instantiate(playerPrefab, transform);

    poolManager.InitializeEnemyPools();
    poolManager.InitializePowerUpPool();
  }

  public override void Enter() {
    base.Enter();

    if(!loadScreen)
      InstantiateLoadScreen();
     
    loadScreen.SetActive(true);
    loadScreenLabel.text = loadScreenInitialText + level.CurrentLevel;
  }

  public override void Exit() {
    base.Enter();

    loadScreen.SetActive(false);
  }

  #endregion

  #region Private Behaviour

  private void InstantiateLoadScreen() {
    loadScreen = Instantiate(loadScreenPrefab, transform);
    loadScreenLabel = loadScreen.GetComponentInChildren<Text>();
    loadScreen.SetActive(false);
  }

  #endregion

}
