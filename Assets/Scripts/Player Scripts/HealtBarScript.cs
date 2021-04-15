using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{
    [SerializeField] Image fillImage;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        fillImage.fillAmount = 1f;
    }
    public void UpdateHealthBar()
    {
        fillImage.fillAmount = (1f / playerHealth.maxHealth) * playerHealth.health;
    }
}
