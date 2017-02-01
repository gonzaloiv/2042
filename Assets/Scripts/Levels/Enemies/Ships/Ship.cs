using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]

public class Ship : StateMachine {

  #region Mono Behaviour

  void Awake() {
    GetComponent<Enemy>().SetScore((int) EnemyScore.Ship);
    GetComponent<Weapon>().SetShotPool(PoolManager.GetPool<GameObjectPool>("EnemyShotPool"));
  }

  void OnEnable() {
    transform.rotation = Quaternion.Euler(0, 0, 180);
    ChangeState<IdleShipState>();
  }

  #endregion

}
