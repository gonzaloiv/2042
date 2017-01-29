using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ShooterBehaviour {

  #region Mono Behaviour

  protected Animator anim;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    anim = GetComponent<Animator>();
  }

  protected virtual void OnCollisionEnter2D(Collision2D collision2D) {
    anim.Play("Die");
  }

  #endregion

}
