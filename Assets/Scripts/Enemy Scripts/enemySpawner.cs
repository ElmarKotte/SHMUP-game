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
    public GameObject commet;
    public Transform spawnPoint;
    public Transform enemyList;
    public EnemyType enemyType;

    public int lvl = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (lvl == 1) StartCoroutine("lvlOne");
        if (lvl == 2) StartCoroutine("lvlTwo");
        if (lvl == 3) StartCoroutine("lvlThree");
        if (lvl == 4) StartCoroutine("lvlFour");
    }

    // note to self || spawn offset -7.5x/7.5x
    private IEnumerator lvlOne()
    {
        setUfoType(EnemyType.UFOGreen);
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
    private IEnumerator lvlTwo()
    {
        yield return new WaitForSeconds(1f);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        spawnUfo(-4f, Patterns.swerve);
        spawnUfo(-3f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);
        
        spawnUfo(2f, Patterns.swerve);
        spawnUfo(3f, Patterns.swerve);
        spawnUfo(4f, Patterns.swerve);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        yield return new WaitForSeconds(2f);
        spawnCommet(-7.5f);
        spawnCommet(-6f);
        
        
        spawnCommet(-3f);
        spawnCommet(-2f);
        
        
        
        spawnCommet(2f);
        spawnCommet(3f);
        
        
        spawnCommet(6f);
        spawnCommet(7.5f);
        setUfoType(EnemyType.UFOGreen);
        yield return new WaitForSeconds(5f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        yield return new WaitForSeconds(1f);
        spawnCommet(-4f);
        spawnCommet(-3f);
        spawnCommet(-2f);
        spawnCommet(-1f);
        spawnCommet(2f);
        spawnCommet(3f);
        spawnCommet(4f);
        spawnCommet(5f);
        yield return new WaitForSeconds(3f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
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
        yield return new WaitForSeconds(2f);
        spawnCommet(-7.5f);
        spawnCommet(-6f);


        spawnCommet(-3f);
        spawnCommet(-2f);



        spawnCommet(2f);
        spawnCommet(3f);


        spawnCommet(6f);
        spawnCommet(7.5f);

        yield return new WaitForSeconds(4f);
        spawnUfo(-5f, Patterns.diagonal);
        spawnUfo(-4f, Patterns.diagonal);
        spawnUfo(-3f, Patterns.diagonal);
        spawnUfo(-2f, Patterns.diagonal);

        spawnUfo(0f, Patterns.diagonal);
        spawnUfo(1f, Patterns.diagonal);
        spawnUfo(2f, Patterns.diagonal);
        spawnUfo(3f, Patterns.diagonal);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);

        spawnUfo(0f, Patterns.swerve);

        spawnUfo(5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        yield return new WaitForSeconds(5f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        yield return new WaitForSeconds(1f);
        spawnCommet(-4f);
        spawnCommet(-3f);
        spawnCommet(-2f);
        spawnCommet(-1f);
        spawnCommet(2f);
        spawnCommet(3f);
        spawnCommet(4f);
        spawnCommet(5f);
        yield return new WaitForSeconds(3f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
    }
    private IEnumerator lvlThree()
    {
        yield return new WaitForSeconds(1f);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        spawnUfo(-4f, Patterns.swerve);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-3f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);

        spawnUfo(2f, Patterns.swerve);
        spawnUfo(3f, Patterns.swerve);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(4f, Patterns.swerve);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        yield return new WaitForSeconds(2f);
        spawnCommet(-7.5f);
        spawnCommet(-6f);


        spawnCommet(-3f);
        spawnCommet(-2f);



        spawnCommet(2f);
        spawnCommet(3f);


        spawnCommet(6f);
        spawnCommet(7.5f);

        yield return new WaitForSeconds(4f);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-5f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-4f, Patterns.diagonal);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-3f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-2f, Patterns.diagonal);

        setUfoType(EnemyType.UFORed);
        spawnUfo(0f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(1f, Patterns.diagonal);
        setUfoType(EnemyType.UFORed);
        spawnUfo(2f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(3f, Patterns.diagonal);
        yield return new WaitForSeconds(5f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        yield return new WaitForSeconds(1f);
        spawnCommet(-4f);
        spawnCommet(-3f);
        spawnCommet(-2f);
        spawnCommet(-1f);
        spawnCommet(2f);
        spawnCommet(3f);
        spawnCommet(4f);
        spawnCommet(5f);
        yield return new WaitForSeconds(3f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
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
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);

        setUfoType(EnemyType.UFORed);
        spawnUfo(0f, Patterns.swerve);
        setUfoType(EnemyType.UFOGreen);

        spawnUfo(5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        yield return new WaitForSeconds(5f);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        setUfoType(EnemyType.UFOGreen);

        yield return new WaitForSeconds(1f);
        spawnCommet(-4f);
        spawnCommet(-3f);
        spawnCommet(-2f);
        spawnCommet(-1f);
        spawnCommet(2f);
        spawnCommet(3f);
        spawnCommet(4f);
        spawnCommet(5f);
        yield return new WaitForSeconds(5f);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        setUfoType(EnemyType.UFOGreen);
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
    private IEnumerator lvlFour()
    {
        yield return new WaitForSeconds(1f);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-7f, Patterns.diagonal);
        spawnUfo(-5f, Patterns.diagonal);
        spawnUfo(-3f, Patterns.diagonal);
        spawnUfo(-1f, Patterns.diagonal);
        spawnUfo(0f, Patterns.diagonal);
        spawnUfo(1f, Patterns.diagonal);
        spawnUfo(3f, Patterns.diagonal);
        spawnUfo(5f, Patterns.diagonal);
        spawnUfo(7f, Patterns.diagonal);
        yield return new WaitForSeconds(3f);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        spawnUfo(-4f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(4f, Patterns.swerve);
        yield return new WaitForSeconds(0.5f);

        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        spawnUfo(-4f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(4f, Patterns.swerve);
        yield return new WaitForSeconds(0.5f);

        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        spawnUfo(-4f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(4f, Patterns.swerve);
        spawnCommet(0f);
        yield return new WaitForSeconds(1f);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-7.5f, Patterns.swerve);
        spawnUfo(-6f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        spawnUfo(-4f, Patterns.swerve);
        spawnUfo(-3f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);

        spawnUfo(2f, Patterns.swerve);
        spawnUfo(3f, Patterns.swerve);
        spawnUfo(4f, Patterns.swerve);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(6f, Patterns.swerve);
        spawnUfo(7.5f, Patterns.swerve);
        yield return new WaitForSeconds(2f);
        spawnCommet(-7.5f);
        spawnCommet(-6f);


        spawnCommet(-3f);
        spawnCommet(-2f);



        spawnCommet(2f);
        spawnCommet(3f);


        spawnCommet(6f);
        spawnCommet(7.5f);
        setUfoType(EnemyType.UFOGreen);
        yield return new WaitForSeconds(5f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        yield return new WaitForSeconds(1f);
        spawnCommet(-4f);
        spawnCommet(-3f);
        spawnCommet(-2f);
        spawnCommet(-1f);
        spawnCommet(2f);
        spawnCommet(3f);
        spawnCommet(4f);
        spawnCommet(5f);
        yield return new WaitForSeconds(3f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        yield return new WaitForSeconds(0.5f);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(2f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        yield return new WaitForSeconds(1f);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(2f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
        yield return new WaitForSeconds(1f);
        spawnUfo(5f, Patterns.swerve);
        spawnUfo(2f, Patterns.swerve);
        spawnUfo(-2f, Patterns.swerve);
        spawnUfo(-5f, Patterns.swerve);
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
        yield return new WaitForSeconds(2f);
        spawnCommet(-7.5f);
        spawnCommet(-6f);


        spawnCommet(-3f);
        spawnCommet(-2f);



        spawnCommet(2f);
        spawnCommet(3f);


        spawnCommet(6f);
        spawnCommet(7.5f);

        yield return new WaitForSeconds(4f);
        spawnUfo(-5f, Patterns.diagonal);
        spawnUfo(-4f, Patterns.diagonal);
        spawnUfo(-3f, Patterns.diagonal);
        spawnUfo(-2f, Patterns.diagonal);

        spawnUfo(0f, Patterns.diagonal);
        spawnUfo(1f, Patterns.diagonal);
        spawnUfo(2f, Patterns.diagonal);
        spawnUfo(3f, Patterns.diagonal);
        yield return new WaitForSeconds(4f);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-5f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-4f, Patterns.diagonal);
        setUfoType(EnemyType.UFORed);
        spawnUfo(-3f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(-2f, Patterns.diagonal);

        setUfoType(EnemyType.UFORed);
        spawnUfo(0f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(1f, Patterns.diagonal);
        setUfoType(EnemyType.UFORed);
        spawnUfo(2f, Patterns.diagonal);
        setUfoType(EnemyType.UFOGreen);
        spawnUfo(3f, Patterns.diagonal);
        yield return new WaitForSeconds(5f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);
        yield return new WaitForSeconds(1f);
        spawnCommet(-4f);
        spawnCommet(-3f);
        spawnCommet(-2f);
        spawnCommet(-1f);
        spawnCommet(2f);
        spawnCommet(3f);
        spawnCommet(4f);
        spawnCommet(5f);
        yield return new WaitForSeconds(3f);
        spawnUfo(-7.5f, Patterns.straightTurn);
        spawnUfo(-6f, Patterns.straightTurn);
        spawnUfo(-5f, Patterns.straightTurn);

        spawnUfo(0f, Patterns.straightTurn);

        spawnUfo(5f, Patterns.straightTurn);
        spawnUfo(6f, Patterns.straightTurn);
        spawnUfo(7.5f, Patterns.straightTurn);     

       
   
      
    }
    private void spawnCommet(float offsetX)
    {
        GameObject o = Instantiate(commet, spawnPoint);
        o.transform.position += new Vector3(offsetX, 0);
        o.transform.SetParent(enemyList);
    }
    private void setUfoType(EnemyType type)
    {
        enemyType = type;
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
