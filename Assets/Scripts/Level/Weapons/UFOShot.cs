using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOShot : ShooterBehaviour {

  #region Fields 

  private Rigidbody2D rb;
  private Animator animator;
  private float speed = Config.BasicShotSpeed;

  #endregion
  
  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  void OnEnable() {
    rb.velocity = -transform.up * speed;
    animator.Play("Spawn");
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if(collision2D.gameObject.transform.parent != transform)
      Disable();
  }

  #endregion

}