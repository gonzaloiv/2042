using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour {

  #region Fields

  private Animator animator;
  private ParticleSystem particleSystem;

  #endregion

  #region Mono Behaviour

  void Awake() {
    animator = GetComponent<Animator>();
    particleSystem = GetComponentInChildren<ParticleSystem>();
  }

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
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
    transform.position = Config.PlayerSpawningPosition;
    animator.Play("Respawn");
  }

  void OnPlayerShotInput(PlayerShotInput playerShotInput) {
    particleSystem.Play();
  }

  #endregion
	
}
