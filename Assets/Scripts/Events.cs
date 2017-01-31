using UnityEngine.Events;
using UnityEngine;

#region Player Input Events

public class MoveRightInput : UnityEvent {}
public class MoveLeftInput : UnityEvent {}
public class MoveDownInput : UnityEvent {}
public class MoveUpInput : UnityEvent {}

public class PlayerShotInput : UnityEvent {
  public Vector3 mousePosition;
  public PlayerShotInput(Vector3 mousePosition) {
    this.mousePosition = mousePosition;
  }
}

public class MouseInput : UnityEvent{
  public Vector3 mousePosition;
  public MouseInput(Vector3 mousePosition) {
    this.mousePosition = mousePosition;
  }
}

public class PauseLevelInput : UnityEvent {}

#endregion

#region Game Mechanics Events

public class PlayerHitEvent : UnityEvent {}

public class EnemyHitEvent : UnityEvent {
  public int enemyScore;
  public EnemyHitEvent(int enemyScore) {
    this.enemyScore = enemyScore;
  }
}

#endregion

#region Level Events

public class EndLevelEvent : UnityEvent {}
public class GameOverEvent :UnityEvent {}
public class RestartGameEvent : UnityEvent {}
public class StartGameEvent :UnityEvent {}

#endregion

#region UI Events

public class LivesUIEvent : UnityEvent {
  public int lives;
  public LivesUIEvent(int lives) {
    this.lives = lives;
  }
}

public class ScoreUIEvent : UnityEvent {
  public int score;
  public ScoreUIEvent(int score) {
    this.score = score;
  }
}

#endregion

