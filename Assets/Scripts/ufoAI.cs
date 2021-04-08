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
    private Patterns pattern;   
    public void setPatern(int ptrn)
    {
        if (ptrn == 0) pattern = Patterns.swerve;
        if (ptrn == 1) pattern = Patterns.straightTurn;
        if (ptrn == 2) pattern = Patterns.diagonal;

    }

    void Update()
    {
        if (pattern == Patterns.swerve) moveSwerve();
        if (pattern == Patterns.straightTurn) moveStraightTurn();
        if (pattern == Patterns.diagonal) moveDiagonal();
    }
    private void moveSwerve()
    {

    }
    private void moveStraightTurn()
    {

    }
    private void moveDiagonal()
    {

    }
}
