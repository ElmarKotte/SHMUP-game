using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Patterns
{
    swerve,
    straightTurn,
    diagonal
}
public class ufoAI : MonoBehaviour
{
    public Patterns pattern;
    [Header("Overall settings")]
    public float moveSpeed = 5.0f;

    [Header("Swerve settings")]
    public float frequency = 20.0f;
    public float magnitude = 0.5f;

    [Header("Diagonal settings")]
    public float turnTime = 2f;

    [Header("StraightTurn settings")]
    public float straightTurnTime = 2f;


    private Vector3 pos;
    private float timer = 0;
    private float turnCount = 0;
    private bool turnRight = false;
    private bool turnLeft = false;
    private bool backwards = true;

    private void Start()
    {
        pos = transform.position;
        if (pattern == Patterns.diagonal)
        {
            transform.Rotate(0, 0, -45f);
        }
    }

    // sets the patern, this function can be used in the EnemySpawner script
    public void setPatern(Patterns ptrn)
    {
        pattern = ptrn;
        Start();
        if (pattern == Patterns.diagonal)
        {
            transform.Rotate(0, 0, 45f);
        }
    }

    void Update()
    {
        // Calling the right moving function using pattern enum
        if (pattern == Patterns.swerve) moveSwerve();
        if (pattern == Patterns.straightTurn) moveStraightTurn();
        if (pattern == Patterns.diagonal) moveDiagonal();
    }

    // Function that is called in update to move in swerve pattern
    private void moveSwerve()
    {
        pos += transform.up * -1 * Time.deltaTime * moveSpeed;
        transform.position = pos + Vector3.right * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    // Function that is called in update to move in StraightTurn pattern
    private void moveStraightTurn()
    {
        timer += Time.deltaTime;
        if (timer >= straightTurnTime)
        {
            turnCount++;
            if (turnCount == 4) turnCount = 0;
            switch (turnCount)
            {
                case 0:
                    turnRight = true;
                    turnLeft = false;
                    backwards = false;
                    break;
                case 1:
                    turnRight = false;
                    turnLeft = false;
                    backwards = true;
                    break;
                case 2:
                    turnRight = false;
                    turnLeft = true;
                    backwards = false;
                    break;
                case 3:
                    turnRight = false;
                    turnLeft = false;
                    backwards = true;
                    break;
            }
            timer = 0;
        }

        if (turnRight) pos += Vector3.right * Time.deltaTime * moveSpeed;
        if (backwards) pos += Vector3.back * Time.deltaTime * moveSpeed;
        if (turnLeft) pos += Vector3.left * Time.deltaTime * moveSpeed;

        transform.position = pos;
    }

    // Function that is called to move in Diagonal pattern
    private void moveDiagonal()
    {
        timer += Time.deltaTime;
        if (timer >= turnTime)
        {
            if (turnRight)
            {
                turnRight = false;
                transform.Rotate(0f, 0f, -90f, Space.Self);
            }
            else
            {
                turnRight = true;
                transform.Rotate(0f, 0f, 90f, Space.Self);
            }
            timer = 0;
        }
        if (turnRight) pos += (Vector3.back + Vector3.right) * Time.deltaTime * moveSpeed;
        if (!turnRight) pos += (Vector3.back + Vector3.right * -1) * Time.deltaTime * moveSpeed;

        transform.position = pos;
    }
}
