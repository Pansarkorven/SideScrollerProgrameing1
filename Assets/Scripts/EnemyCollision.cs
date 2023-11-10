using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Enemy MyEnemyScript = null;

       private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 enemyScale = MyEnemyScript.transform.localScale;
        enemyScale.x = -enemyScale.x;
        MyEnemyScript.transform.localScale = enemyScale;
        MyEnemyScript.MovmentSign *= -1;
    }
}
