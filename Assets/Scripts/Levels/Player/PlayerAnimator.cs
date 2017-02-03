using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour {

  #region Fields

  private Animator anim;
  private ParticleSystem particles;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
    particles = GetComponentInChildren<ParticleSystem>();
  }

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StopListening<RestartGameEvent>(OnRestartGameEvent);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer != (int) CollisionLayer.PowerUp) {
      anim.Play("Respawn");
      transform.position = Config.PlayerSpawningPosition;
    } else {
      if (collision2D.gameObject.name.Contains("PUInvulnerability"))
        anim.Play("Invulnerable");
    }
  }

  #endregion

  #region Event Behaviour

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    anim.Play("MoveRight");
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    anim.Play("MoveLeft");
  }

  void OnPlayerShotInput(PlayerShotInput playerShotInput) {
    particles.Play();
  }

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    anim.Play("Die");
  }

  void OnRestartGameEvent(RestartGameEvent restartGameEvent) {
    anim.Play("Idle");
  }


  #endregion
	
}
