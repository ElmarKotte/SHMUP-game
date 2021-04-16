using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    UFOGreen,
    UFORed
}

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyUFOGreen;
    public GameObject enemyUFORed;
    public Transform spawnPoint;
    public Transform enemyList;
    public EnemyType enemyType;

    public int lvl = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (lvl == 1) StartCoroutine("lvlOne");
    }

    // note to self || spawn offset -7.5x/7.5x
    private IEnumerator lvlOne()
    {
        yield return new WaitForSeconds(1f);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(2f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        yield return new WaitForSeconds(2f);
        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(2f, Patterns.straightTurn);
        spawnUfo(-2f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);
        yield return new WaitForSeconds(2f);
        spawnUfo(5f, Patterns.diagonal);
        spawnUfo(2f, Patterns.diagonal);
        spawnUfo(-2f, Patterns.diagonal);
        spawnUfo(-5f, Patterns.diagonal);
        yield return new WaitForSeconds(2f);
        spawnUfo(-5f, Patterns.diagonal);
        spawnUfo(1f, Patterns.diagonal);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(-4f, Patterns.diagonal);
        spawnUfo(2f, Patterns.diagonal);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(-3f, Patterns.diagonal);
        spawnUfo(3f, Patterns.diagonal);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(-2f, Patterns.diagonal);
        spawnUfo(4f, Patterns.diagonal);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(-1f, Patterns.diagonal);
        spawnUfo(5f, Patterns.diagonal);

    }
    private void spawnUfo(float offsetX, Patterns ptrn)
    {
        if (enemyType == EnemyType.UFOGreen)
        {
            GameObject o = Instantiate(enemyUFOGreen, spawnPoint);
            o.transform.position += new Vector3(offsetX, 0);
            o.GetComponent<ufoAI>().setPatern(ptrn);
            o.transform.SetParent(enemyList);
        }
        if (enemyType == EnemyType.UFORed)
        {
            GameObject o = Instantiate(enemyUFORed, spawnPoint);
            o.transform.position += new Vector3(offsetX, 0);
            o.GetComponent<ufoAI>().setPatern(ptrn);
            o.transform.SetParent(enemyList);
        }
        //GameObject o = Instantiate(enemyUFOGreen, spawnPoint);
        //o.transform.position += new Vector3(offsetX, 0);
        //o.GetComponent<ufoAI>().setPatern(ptrn);
        //o.transform.SetParent(enemyList);
    }
}
