using UnityEngine;

public class Config {

  // Global
  public static Vector3 GlobalGravity = new Vector3(0f, -3f, 0f);
  public const float BackgroundScrollingSpeed = .001f;

  // Level
  public static Vector2 PlayerSpawningPosition = new Vector2(0, -3);

  // Player physics
  public const float PlayerControllerSpeed = 5;
  public const float PlayerShotSpeed = 4;
  public static Vector3 PlayerShotDirection = new Vector3(0, 0, 1);
  public const float PlayerWeaponFireRate = .2f;

  // Player model
  public const int InitialLivesAmount = 3;
	
}

public enum Direction {
  Up,
  Right,
  Down,
  Left
}