using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class Meteor : ShooterBehaviour {

  #region Mono Behaviour

  private Animator animator;
  private Vector3 rotation;

  #endregion

  #region Mono Behaviour

  void Awake() {
    animator = GetComponent<Animator>();
    rotation = new Vector3(0, 0, Random.Range(0, 2));
  }

  void Update() {
    transform.Rotate(rotation);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.name.Contains("Player"))
      Disable();
  }

  #endregion

}