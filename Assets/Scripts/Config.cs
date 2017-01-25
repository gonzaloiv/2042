using UnityEngine;

public class Config {

  // Physics
  public static Vector3 GlobalGravity = new Vector3(0f, -1f, 0f);
  public const float BackgroundScrollingSpeed = .03f;
  public const float PlayerBaseSpeed = 10;

  // Level positions
  public static Vector2 PlayerSpawningPosition = new Vector2(0, -3);

  // Player model
  public const int InitialLivesAmount = 3;
	
}

public enum Direction {
  Up,
  Right,
  Down,
  Left
}