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
    public bool isChiefWave;

    public Wave(Enemy[] enemies = null, PowerUp[] powerUps = null, float duration = 0, bool isChiefWave = false) {
      this.enemies = enemies;
      this.powerUps = powerUps;
      this.duration = duration;
      this.isChiefWave = isChiefWave;
    }

  }

  public interface ISpawnable {
    int GetType();
    int GetAmount();
    int[] GetPositions();
  }

  [Serializable]
  public struct Enemy : ISpawnable {

    public EnemyType type;
    public int amount;
    public int[] positions;

    public Enemy(EnemyType type, int amount, int[] positions = null) {
      this.type = type;
      this.amount = amount;
      this.positions = positions;
    }

    public new int GetType() {
      return (int) this.type;
    }

    public int GetAmount() {
      return this.amount;
    }

    public int[] GetPositions() {
      return this.positions;
    }

  }

  [Serializable]
  public struct PowerUp : ISpawnable {

    public PowerUpType type;
    public int amount;
    public int[] positions;

    public PowerUp(PowerUpType type, int amount, int[] positions = null) {
      this.type = type;
      this.amount = amount;
      this.positions = positions;
    }

    public new int GetType() {
      return (int) this.type;
    }

    public int GetAmount() {
      return this.amount;
    }

    public int[] GetPositions() {
      return this.positions;
    }

  }

}