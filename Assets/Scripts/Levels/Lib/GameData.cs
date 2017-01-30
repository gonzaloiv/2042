using UnityEngine;
using System;

namespace GameData {

  [Serializable]
  public struct Game {

    public Level[] levels;

  }

  [Serializable]
  public struct Level {

    public Wave[] waves;

  }

  [Serializable]
  public struct Wave {

    public Enemy[] enemies;

  }

  [Serializable]
  public struct Enemy {

    public EnemyType type;
    public int amount;
    public int[] positions;

  }

}