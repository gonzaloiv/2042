using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerShot : BaseEntity {

  #region Fields 

  private Rigidbody2D rb;
  private Animator animator;
  private float speed = Config.PlayerShotSpeed;
  private Vector3 direction = Config.PlayerShotDirection;

  #endregion
  
  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  void OnEnable() {
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    rb.velocity = new Vector3(0, 1, 0) * speed;
    animator.Play("Spawn");
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if(!collision2D.gameObject.name.Contains("Player"))
     Disable();
  }

  #endregion

}
