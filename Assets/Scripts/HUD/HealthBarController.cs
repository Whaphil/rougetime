using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarController : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI healthText = null;
    [SerializeField]
    Slider healthSlider = null;

    void Start() {
        healthText.text = "100/100";
    }

    public void SetHealth(int health) {
        float hpFraction = (float)health / 100;
        healthSlider.value = hpFraction;
        healthText.text = health + "/100";
    }
}
