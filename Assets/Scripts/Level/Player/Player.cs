using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

  #region Fields

  private int lives;
  private int score;

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  #endregion

  #region Event Behaviour

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    lives--;
  }

  #endregion

}
