using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyUFO;
    public Transform spawnPoint;

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

    }
    private void spawnUfo(float offsetX, Patterns ptrn)
    {
        GameObject o = Instantiate(enemyUFO, spawnPoint);
        o.transform.position += new Vector3(offsetX, 0);
        o.GetComponent<ufoAI>().setPatern(ptrn);
    }
}
