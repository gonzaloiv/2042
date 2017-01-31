using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class PowerUp : ShooterBehaviour {

  #region Mono Behaviour

  protected virtual void OnCollisionEnter2D(Collision2D collision2D) {
    gameObject.SetActive(false);
  }

  #endregion

}
