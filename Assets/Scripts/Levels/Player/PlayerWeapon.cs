using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

  #region Fields

  private Weapon[] weapons;

  private float fireRate = Config.PlayerWeaponFireRate;
  private float nextFire;
  private WeaponType currentWeapon = WeaponType.SingleShot;

  #endregion

  #region Mono Behaviour

  void Awake() {
    weapons = GetComponents<Weapon>();
    foreach(Weapon weapon in weapons)
      weapon.SetShotPool(PoolManager.GetPool<GameObjectPool>("PlayerShotPool"));
  }

  void OnEnable() {
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer != (int) CollisionLayer.PowerUp)
      currentWeapon = WeaponType.SingleShot;
    if (collision2D.gameObject.name.Contains("PUDoubleShot"))
      currentWeapon = WeaponType.DoubleShot;
  }

  #endregion

  #region Event Behaviour

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