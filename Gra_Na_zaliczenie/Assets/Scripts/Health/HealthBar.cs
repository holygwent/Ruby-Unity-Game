using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currenHealtBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currenHealtBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
