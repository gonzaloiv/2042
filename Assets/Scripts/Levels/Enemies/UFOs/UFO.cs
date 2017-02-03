using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]

[RequireComponent(typeof(IdleUFOState))]
[RequireComponent(typeof(ShootUFOState))]

public class UFO : StateMachine {

  #region Mono Behaviour

  void Awake() {
    GetComponent<Enemy>().SetScore((int) EnemyScore.UFO);
    GetComponent<Weapon>().SetShotPool(PoolManager.GetPool<GameObjectPool>("EnemyShotPool"));
  }

  void OnEnable() {
    ChangeState<IdleUFOState>();
  }

  #endregion

}