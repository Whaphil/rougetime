using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevHudManager : MonoBehaviour {
    [SerializeField]
    Player player = null;
    [SerializeField]
    [Range(1, 99)]
    int damage = 10;
    [SerializeField]
    Button menuButton = null;
    bool open = false;


    private void Start() {
        if (menuButton != null) SetMenuOpen(open);
    }

    private void SetMenuOpen(bool open) {
        foreach (Transform child in menuButton.transform) {
            if (child == menuButton.transform) continue;
            if (child.name == "DevButtonText") continue;
            child.gameObject.SetActive(open);
        }
    }

    public void OnDevHudButtoClick() {
        open = !open;
        SetMenuOpen(open);
    }

    public void OnDamageButtonClick() {
        player.TakeDamage(damage);
    }
}
