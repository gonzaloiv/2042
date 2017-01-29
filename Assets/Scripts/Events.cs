using UnityEngine.Events;
using UnityEngine;

#region Player Input Events

public class MoveRightInput : UnityEvent {}
public class MoveLeftInput : UnityEvent {}
public class MoveDownInput : UnityEvent {}
public class MoveUpInput : UnityEvent {}
public class PlayerShotInput : UnityEvent {}

#endregion

#region Level Mechanics Events

public class PlayerHitEvent : UnityEvent {}

public class EnemyHitEvent : UnityEvent {
  public int enemyScore;
  public EnemyHitEvent(int enemyScore) {
    this.enemyScore = enemyScore;
  }
}

public class PlayerDeadEvent : UnityEvent {
  public PlayerDeadEvent () {
    Debug.Log("This player is deadly dead...");
  }
}

#endregion