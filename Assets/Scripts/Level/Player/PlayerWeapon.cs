using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject shotPrefab;
  private GameObjectPool shotPool;
  private GameObject shot;

  private float fireRate = Config.PlayerWeaponFireRate;
  private float nextFire;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotPool = Pooler.CreateGameObjectPool(shotPrefab, 10, transform.parent);
    nextFire = Time.time;
  }

  void OnEnable() {
    EventManager.StartListening<PlayerShotInput>(OnPlayerShotInput);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerShotInput>(OnPlayerShotInput);
  }

  #endregion

  #region Event Behaviour

  void OnPlayerShotInput(PlayerShotInput playerShotInput) {
    if (Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      shot = shotPool.PopObject();
      shot.transform.position = transform.position + new Vector3(0, transform.localScale.y, 0);
      shot.SetActive(true);
    }
  }

  #endregion

}
