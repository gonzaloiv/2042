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
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer != (int) CollisionLayer.PowerUp) {
      transform.position = Config.PlayerSpawningPosition;
      animator.Play("Respawn");
    } else {
      if (collision2D.gameObject.name.Contains("PUInvulnerability"))
        animator.Play("Invulnerable");
    }
  }

  #endregion

  #region Event Behaviour

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    animator.Play("MoveRight");
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    animator.Play("MoveLeft");
  }

  void OnPlayerShotInput(PlayerShotInput playerShotInput) {
    shootingParticleSystem.Play();
  }

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    animator.Play("Die");
  }

  #endregion
	
}
