using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Would be cool to have a CharacterController2D...
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerWeapon))]
public class PlayerController : MonoBehaviour {

  #region Fields

  private PlayerWeapon weapon;
  private float playerBaseSpeed = Config.PlayerControllerSpeed;

  private float fireRate = Config.PlayerWeaponFireRate;
  private float nextFire;

  #endregion

  #region Mono Behaviour

  void Awake() {
    weapon = GetComponent<PlayerWeapon>();
  }

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveDownInput>(OnMoveDownInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (!collision2D.gameObject.name.Contains("PlayerShot"))
      EventManager.TriggerEvent(new PlayerHitEvent());
  }

  #endregion

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    if (transform.position.y < Config.PlayerConstraints[(int) Direction.Up])
      transform.Translate(new Vector2(0, 1) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    if (transform.position.x < Config.PlayerConstraints[(int) Direction.Right])
      transform.Translate(new Vector2(1, 0) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnMoveDownInput(MoveDownInput moveDownInput) {
    if (transform.position.y > Config.PlayerConstraints[(int) Direction.Down])
      transform.Translate(new Vector2(0, -1) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    if (transform.position.x > Config.PlayerConstraints[(int) Direction.Left])
      transform.Translate(new Vector2(-1, 0) * playerBaseSpeed * Time.deltaTime, Space.World);
  }

  void OnPlayerShotInput(PlayerShotInput playerShotInput) {
    if (Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      weapon.Shoot();
    }
  }

  #endregion

}
