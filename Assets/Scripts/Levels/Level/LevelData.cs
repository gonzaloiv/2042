using UnityEngine;
using System;

namespace LevelData {

  [Serializable]
  public struct Level {

    public Wave[] waves;

  }

  [Serializable]
  public struct Wave {

    public Enemy[] enemies;
    public PowerUp[] powerUps;
    public float duration;

    public Wave(Enemy[] enemies = null, PowerUp[] powerUps = null, float duration = 0) {
      this.enemies = enemies;
      this.powerUps = powerUps;
      this.duration = duration;
    }

  }

  [Serializable]
  public struct Enemy {

    public EnemyType type;
    public int amount;
    public int[] positions;

    public Enemy(EnemyType type, int amount, int[] positions = null) {
      this.type = type;
      this.amount = amount;
      this.positions = positions;
    }

  }

  [Serializable]
  public struct PowerUp {

    public int type;
    public int amount;
    public int[] positions;

    public PowerUp(int type, int amount, int[] positions = null) {
      this.type = type;
      this.amount = amount;
      this.positions = positions;
    }

  }

}