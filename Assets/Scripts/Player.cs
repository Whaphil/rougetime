using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField]
    private int health = 100;
    [HideInInspector]
    public int speed = 0;
    [HideInInspector]
    public int inputDelay_ms = 250;
    [HideInInspector]
    public static Player instance = null;

    private float timeSinceLastInputCheck_ms = 250;
    public delegate void HealthChangeEvent(int healthNow, int healthPrevious);
    public event HealthChangeEvent OnHealthChange;

    public Dictionary<string, bool> inputs = new Dictionary<string, bool>(){
        {"UP",false},
        {"LEFT",false},
        {"DOWN",false},
        {"RIGHT",false}
    };

    private void Start() {
        if(instance != null){
            Destroy(this.gameObject);
            throw new TwoSingletonInstancesException("Only one Player should exist");
        }
        instance = this;
        OnHealthChange += (int healthNow, int healthPrevious) => { if (healthNow <= 0) Die(); };
    }

    private void Die() {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int amount) {
        health -= amount;
        OnHealthChange.Invoke(health, health + amount/*health+amount of damage = previous health*/);
    }

    private void getInputs() {
        if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) { inputs["UP"] = true; timeSinceLastInputCheck_ms = 0; }
        if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)) { inputs["LEFT"] = true; timeSinceLastInputCheck_ms = 0; }
        if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)) { inputs["DOWN"] = true; timeSinceLastInputCheck_ms = 0; }
        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)) { inputs["RIGHT"] = true; timeSinceLastInputCheck_ms = 0; }
    }

    private Vector2Int getAxis() {
        int horizontal = 0;
        int vertical = 0;
        if (inputs["UP"]) vertical += 1;
        if (inputs["DOWN"]) vertical += -1;
        if (inputs["LEFT"]) horizontal -= 1;
        if (inputs["RIGHT"]) horizontal += 1;
        return new Vector2Int(horizontal, vertical);
    }

    private void handleInput(Vector2Int axis) {
        if (timeSinceLastInputCheck_ms >= 125) {
            transform.position = new Vector3(
                transform.position.x + axis.x,
                transform.position.y + axis.y,
                transform.position.z
            );
            List<string> keys = inputs.Keys.ToList<string>();
            foreach (string key in keys) {
                inputs[key] = false;
            }
            timeSinceLastInputCheck_ms = 0;
        }
    }

    private void Update() {
        timeSinceLastInputCheck_ms += Time.deltaTime * 1000;
        getInputs();
        handleInput(getAxis());
    }
}

public class TwoSingletonInstancesException :Exception{
    static string defaultMessage = "Singleton Pattern was not respected";
    public TwoSingletonInstancesException(string message = null)
        :base(message??defaultMessage){

    }
}
