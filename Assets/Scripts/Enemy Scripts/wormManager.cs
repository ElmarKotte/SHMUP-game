using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormManager : MonoBehaviour
{
    public int healthPerPart;
    public int beginSize;
    public int HighestScore;
    public int scoreLoweringFactor;
    public GameObject bodyPartPrefab;
    public GameObject levelFinishScreen;
    public gameManager gm;
    private GameObject prevSpawn;
    private float score;

    void Start()
    {
        score = HighestScore;
        AddBoddyPart(true , false);
        // Maak de aantal body parts aan zodra de worm spawnt
        for (int i = 0; i < beginSize - 2; i++)
        {
            AddBoddyPart( false, false);
        }

        AddBoddyPart(false, true);
    }

    // functie die een bodypart aan maakt
    public void AddBoddyPart(bool isFirst, bool isLast)
    {
        Transform newParent = transform;
        Transform newpart = Instantiate(bodyPartPrefab, transform.position, transform.rotation).transform;
        WormPart newScript = newpart.GetComponent<WormPart>();
        newScript.MaxHealth = healthPerPart;
        newScript.health = healthPerPart;
        newpart.SetParent(newParent);
        if (isFirst)
        {
            newScript.isHead = true;
        }
        else
        {
            newScript.front = prevSpawn;
            prevSpawn.GetComponent<WormPart>().back = newpart.gameObject;
        }
        if (isLast)
        {
            newScript.isBack = true;
        }
        prevSpawn = newpart.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            levelFinishScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            gm.levelEnd(5);
        }
        if (score <= 0)
        {
            score = 0;
        }
        score -= scoreLoweringFactor * Time.deltaTime;
        gm.SetScore((int)score);
    }
}