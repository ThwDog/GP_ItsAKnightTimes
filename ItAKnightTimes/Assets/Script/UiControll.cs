using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiControll : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI staminaText;

    // Start is called before the first frame update
    void Start()
    {
        hpText.text = "HP : 100";
        staminaText.text = "Stamina : 100";
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public void hpChange(string text)
    {
        hpText.text = text;
        staminaText.text = text;

    }
    public void staChange(string text)
    {
        staminaText.text = text;

    }
}
