using UnityEngine;

public class Config {

  // Global
  public static Vector3 GlobalGravity = new Vector3(0f, -2.7f, 0f);
  public const float BackgroundScrollingSpeed = .04f;
  public static float[] PlayerConstraints = { 4, 7, -3, -7 };
  public const int TimeScale = 1;
  public const float MaxMouseAngle = 120;
  public const float MinMouseAngle = 60;

  // Data
  public const string GameDataPath = "LevelData";

  // Level
  public const int InitialLevel = 1;
  public const int InitialWave = 1;
  public static Vector2 PlayerSpawningPosition = new Vector2(0, -3);

  // Player physics
  public const float PlayerControllerSpeed = 7;
  public const float BasicShotSpeed = 7;
  public const float PlayerWeaponFireRate = .1f;

  // Player model
  public const int InitialLivesAmount = 3;
  public const int InitialScore = 0;

  // Enemies
  public const float RocketSpeed = .12f;
  public const int InitialRocketGroupLives = 5;
}

// GLOBAL

public enum Direction {
  Up,
  Right,
  Down,
  Left
}

public enum CollisionLayer {
  Enemy = 8,
  Player = 9,
  PowerUp = 10,
  Constraint = 11,
  EnemyAmmo = 12,
  PlayerAmmo = 13
}

// GAME DATA

public enum EnemyType {
  Meteor,
  UFO,
  Rocket,
  Ship,
  ShipGroup,
  StationGroup
}

public enum EnemyScore {
  Meteor = 5,
  UFO = 10,
  Ship = 15,
  Station = 50
}

public enum PowerUpType {
  ExtraLife,
  DoubleShot,
  Invulnerability
}

public enum WeaponType {
  SingleShot,
  DoubleShot
}