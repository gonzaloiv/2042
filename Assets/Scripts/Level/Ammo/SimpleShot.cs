using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
public class SimpleShot : ShooterBehaviour {

  #region Fields 

  private Animator anim;

  #endregion
  
  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
  }

  void OnEnable() {
    anim.Play("Spawn");
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    Disable();
  }

  #endregion

}