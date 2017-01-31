using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour {

  #region Fields

  private Animator animator;
  private ParticleSystem shootingParticleSystem;

  #endregion

  #region Mono Behaviour

  void Awake() {
    animator = GetComponent<Animator>();
    shootingParticleSystem = GetComponentInChildren<ParticleSystem>();
  }

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);

  }

  #endregion

  #region Event Behaviour

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    animator.Play("MoveRight");
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    animator.Play("MoveLeft");
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    animator.Play("Respawn");
    transform.position = Config.PlayerSpawningPosition;
  }

  void OnPlayerShotInput(PlayerShotInput playerShotInput) {
    shootingParticleSystem.Play();
  }

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    animator.Play("Die");
  }

  #endregion
	
}
