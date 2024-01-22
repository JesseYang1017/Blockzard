using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventCenter : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDied;
    public static void EnemyDied(Enemy enemy){
        print("dies");
        OnEnemyDied?.Invoke(enemy);
    }
}
