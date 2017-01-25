using UnityEngine.Events;

#region Player Input Events

public class MoveRightInput : UnityEvent {}
public class MoveLeftInput : UnityEvent {}
public class MoveDownInput : UnityEvent {}
public class MoveUpInput : UnityEvent {}
public class PlayerShotInput : UnityEvent {}

#endregion

#region Level Mechanics Events

public class PlayerHitEvent : UnityEvent {}

#endregion