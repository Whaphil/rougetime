using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevHudManager : MonoBehaviour {
    
    [Header("In-game objects")]
    [SerializeField]
    Player player = null;
    [SerializeField]
    Button menuButton = null;
    
    [Header("Fields")]
    [SerializeField]
    bool startOpen = true;
    [SerializeField][Range(1, 99)]
    int damgePerPress = 10;
    
    bool open = false;


    private void Start() {
        open = startOpen;
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
        player.TakeDamage(damgePerPress);
    }
}
