using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SingleShotWeapon))]
[RequireComponent(typeof(DoubleShotWeapon))]

public class PlayerController : MonoBehaviour {

  #region Fields

  private float playerBaseSpeed = Config.PlayerControllerSpeed;

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {  
    if (collision2D.gameObject.layer == (int) CollisionLayer.PowerUp && collision2D.gameObject.name.Contains("PUDoubleSpeed"))
      StartCoroutine(DoubleSpeed());
  }

  #endregion

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    if (transform.position.y < Config.PlayerConstraints[(int) Direction.Up])
      transform.Translate(new Vector2(0, 1) * playerBaseSpeed * TimeManager.DeltaTime, Space.World);
  }

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    if (transform.position.x < Config.PlayerConstraints[(int) Direction.Right])
      transform.Translate(new Vector2(1, 0) * playerBaseSpeed * TimeManager.DeltaTime, Space.World);
  }

  void OnMoveDownInput(MoveDownInput moveDownInput) {
    if (transform.position.y > Config.PlayerConstraints[(int) Direction.Down])
      transform.Translate(new Vector2(0, -1) * playerBaseSpeed * TimeManager.DeltaTime, Space.World);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    if (transform.position.x > Config.PlayerConstraints[(int) Direction.Left])
      transform.Translate(new Vector2(-1, 0) * playerBaseSpeed * TimeManager.DeltaTime, Space.World);
  }

  #endregion

  #region Private Behaviour

  public IEnumerator DoubleSpeed() {
    TimeManager.ModifyTimeScale(.5f);
    yield return new WaitForSeconds(2);
    TimeManager.ModifyTimeScale(2f);
  }

  #endregion

}
