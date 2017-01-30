using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : ShooterBehaviour {

  #region Mono Behaviour

  public int Score { get { return score; } set { value = score; } }

  private Animator anim;
  private int score = 0;

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

}
