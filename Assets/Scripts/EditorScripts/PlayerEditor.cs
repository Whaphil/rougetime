using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {

    Player player = null;

    override public void OnInspectorGUI() {
        this.player = (Player)target;
        player.speed = (int)EditorGUILayout.Slider("Speed", player.speed, 0, 10);
        player.inputDelay_ms = (int)EditorGUILayout.Slider("Input Delay ms", player.inputDelay_ms, 0, 1000);
        DrawDefaultInspector();
    }

    private void OnInspectorUpdate() {
        player.speed = (int)EditorGUILayout.Slider("Speed", player.speed, 0, 10);
        player.inputDelay_ms = (int)EditorGUILayout.Slider("Input Delay ms", player.inputDelay_ms, 0, 1000);
    }
}
