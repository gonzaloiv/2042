using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : ShooterBehaviour {

  #region Mono Behaviour

  private Animator anim;
  private int score;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    anim = GetComponent<Animator>();
  }

  protected virtual void OnCollisionEnter2D(Collision2D collision2D) {
    EventManager.TriggerEvent(new EnemyHitEvent(score));
    anim.Play("Die");
  }

  #endregion

  #region Mono Behaviour

  public void SetScore(int score) {
    this.score = score;
  }

  #endregion

}
