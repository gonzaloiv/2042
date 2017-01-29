using UnityEngine;

public class Config {

  // Global
  public static Vector3 GlobalGravity = new Vector3(0f, -2.7f, 0f);
  public const float BackgroundScrollingSpeed = .04f;
  public static float[] PlayerConstraints = { 4, 7, -3, -7 };
  public const string GameDataPath = "GameData";

  // Level
  public static Vector2 PlayerSpawningPosition = new Vector2(0, -3);

  // Player physics
  public const float PlayerControllerSpeed = 7;
  public const float BasicShotSpeed = 7;
  public const float PlayerWeaponFireRate = .1f;

  // Player model
  public const int InitialLivesAmount = 3;
	
}

public enum Direction {
  Up,
  Right,
  Down,
  Left
}

public enum EnemyType {
  Meteor,
  UFO,
  None
}