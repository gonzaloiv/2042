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
    EventManager.StartListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer != (int) CollisionLayer.PowerUp) {
      lives--;
      EventManager.TriggerEvent(new LivesUIEvent(lives));
      if (lives <= 0)
        EventManager.TriggerEvent(new GameOverEvent());   
    } else {
      if (collision2D.gameObject.name.Contains("PUExtraLife"))
        IncreaseLives();
    }
  }

  #endregion

  #region Event Behaviour

  void OnEnemyHitEvent(EnemyHitEvent enemyHitEvent) {
    score += enemyHitEvent.enemyScore;
    EventManager.TriggerEvent(new ScoreUIEvent(score)); 
  }

  void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    RestartPlayer();
  }

  #endregion

  #region Private Behaviour

  private void RestartPlayer() {
    lives = Config.InitialLivesAmount;
    EventManager.TriggerEvent(new LivesUIEvent(lives));
    score = Config.InitialScore;
    EventManager.TriggerEvent(new ScoreUIEvent(score)); 
  }

  private void IncreaseLives() {
    lives++;
    EventManager.TriggerEvent(new LivesUIEvent(lives));
  }

  #endregion

}
