using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenihManager : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private FarmManager farmManager;
    [SerializeField] private Image iconBefore;
    [SerializeField] private Image iconAfter;

    public BenihSO selectedBenih;

    private float timer = 5;
    private bool isFilled = false;

    private void Start()
    {
        iconBefore.gameObject.SetActive(false);
        iconAfter.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(selectedBenih == null)
        {
            isFilled = false;
        } else
        {
            isFilled = true;
        }

        if (isFilled)
        {
            iconBefore.sprite = selectedBenih.iconBefore;
            iconBefore.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                iconAfter.sprite = selectedBenih.iconAfter;
                iconAfter.gameObject.SetActive(true);
               
            }
        }
    }

    public void SelectBenihToPlant()
    {
        farmManager.SelectBenih(this);
    }
}
