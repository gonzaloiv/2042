using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

  #region Fields

  private int lives = Config.InitialLivesAmount;
  private int score = Config.InitialScore;

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StartListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StopListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
  }

  #endregion

  #region Event Behaviour

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    lives--;
    EventManager.TriggerEvent(new LivesUIEvent(lives));
    if(lives == 0)
      EventManager.TriggerEvent(new PlayerDeadEvent());   
  }

  void OnEnemyHitEvent(EnemyHitEvent enemyHitEvent) {
    score += enemyHitEvent.enemyScore;
    EventManager.TriggerEvent(new ScoreUIEvent(score)); 
   }

  void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    lives = Config.InitialLivesAmount;
    EventManager.TriggerEvent(new LivesUIEvent(lives));
    score = Config.InitialScore;
    EventManager.TriggerEvent(new ScoreUIEvent(score)); 
  }

  #endregion

}
