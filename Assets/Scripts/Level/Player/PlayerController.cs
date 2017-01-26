using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Would be cool to have a CharacterController2D...
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour {

  #region Fields

  private float playerBaseSpeed = Config.PlayerControllerSpeed;
  bool[] constraints = { false, false, false, false };

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (!collision2D.gameObject.name.Contains("PlayerShot"))
      EventManager.TriggerEvent(new PlayerHitEvent());
  }

  void OnTriggerEnter2D(Collider2D collider) {
    if (collider.gameObject.name == "TopConstraint")
      constraints[(int) Direction.Up] = true;
    if (collider.gameObject.name == "RightConstraint")
      constraints[(int) Direction.Right] = true;
    if (collider.gameObject.name == "BottomConstraint")
      constraints[(int) Direction.Down] = true;
    if (collider.gameObject.name == "LeftConstraint")
      constraints[(int) Direction.Left] = true;
  }

  void OnTriggerExit2D(Collider2D collider) {
    if (collider.gameObject.name == "TopConstraint")
      constraints[(int) Direction.Up] = false;
    if (collider.gameObject.name == "RightConstraint")
      constraints[(int) Direction.Right] = false;
    if (collider.gameObject.name == "BottomConstraint")
      constraints[(int) Direction.Down] = false;
    if (collider.gameObject.name == "LeftConstraint")
      constraints[(int) Direction.Left] = false;
  }

  #endregion

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    if (!constraints[(int) Direction.Up])
      transform.Translate(new Vector2(0, 1) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    if (!constraints[(int) Direction.Right])
      transform.Translate(new Vector2(1, 0) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnMoveDownInput(MoveDownInput moveDownInput) {
    if (!constraints[(int) Direction.Down])
      transform.Translate(new Vector2(0, -1) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    if (!constraints[(int) Direction.Left])
      transform.Translate(new Vector2(-1, 0) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    for (int i = 0; i < constraints.Length; i++)
      constraints[i] = false;
  }

  #endregion

}
