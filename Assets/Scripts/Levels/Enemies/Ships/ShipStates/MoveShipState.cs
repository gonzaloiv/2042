using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShipState : State {

  #region Fields

  private Transform target;

  private Vector2 yMovement = new Vector2(0, -1);
  private Vector2 xMovement = new Vector2(1, 0);
  private float ySpeed = .1f;
  private float xSpeed = .1f;
  private bool moving = false;

  #endregion

  #region State Behaviour

  void Update() {
    if (moving) {
      transform.Translate(yMovement * ySpeed * Time.timeScale);
      transform.Translate(XMovement() * xSpeed * Time.timeScale);
    }
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    // TODO: corregir dependencia entre los enemigos y el jugador
    if (!target)
      target = GameObject.FindGameObjectWithTag("Player").transform;

    moving = true;
  }

  public override void Exit() {
    base.Exit();

    moving = false;
  }

  #endregion

  #region Private Behaviour

  public Vector2 XMovement() {
    return target.position.x > 0 ? -xMovement : xMovement;
  }

  #endregion

}
