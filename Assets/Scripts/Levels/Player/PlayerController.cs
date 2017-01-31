using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SingleShotWeapon))]
[RequireComponent(typeof(DoubleShotWeapon))]

public class PlayerController : MonoBehaviour {

  #region Fields

  private Weapon[] weapons;

  private float playerBaseSpeed = Config.PlayerControllerSpeed;
  private float fireRate = Config.PlayerWeaponFireRate;
  private float nextFire;
  private WeaponType currentWeapon = WeaponType.SingleShot;

  #endregion

  #region Mono Behaviour

  void Awake() {
    weapons = GetComponents<Weapon>();
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
    currentWeapon = WeaponType.SingleShot;
    if (collision2D.gameObject.name.Contains("PUDoubleShot"))
      currentWeapon = WeaponType.DoubleShot;
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
    if ((Vector2) playerShotInput.mousePosition != Vector2.up)
      FocusOnMouse(playerShotInput.mousePosition);
    if (Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      weapons[(int) currentWeapon].Shoot();
    }
  }

  #endregion

  #region Private Behaviour

  private void FocusOnMouse(Vector2 mousePosition) {
    Vector3 dir = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    angle = angle > Config.MaxMouseAngle ? Config.MaxMouseAngle : angle; 
    angle = angle < Config.MinMouseAngle ? Config.MinMouseAngle : angle;
    Quaternion q = Quaternion.AngleAxis(angle + -90, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, 100);
  }

  #endregion

}
