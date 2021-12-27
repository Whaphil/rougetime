using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour {
    [SerializeField]
    Player player = null;
    [SerializeField]
    HealthBarController health = null;

    // Start is called before the first frame update
    void Start() {
        player.OnHealthChange += (int healthNow, int healthPrev) => health.SetHealth(healthNow);
    }
}
