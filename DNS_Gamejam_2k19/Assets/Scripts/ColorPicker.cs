using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ColorPicker : MonoBehaviour
{
    public Color[] colors;
    public Dictionary<int, Color> mappedColours;

    public GameObject playerSlotsParent;
    public GameObject[] activePlayerSlots;
    public SpawnPlayers spawnPlayers;

    void Awake() {
        colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };
        mappedColours = new Dictionary<int, Color>();
        List<Transform> activeChildren = new List<Transform>();
        foreach (Transform child in playerSlotsParent.transform) {
            if (child.gameObject.activeSelf) {
                activeChildren.Add(child);
            }
        }
        activePlayerSlots = activeChildren.Select(c => c.gameObject).ToArray();
    }

    void Update() {
        if (mappedColours.Count == activePlayerSlots.Length) {
            spawnPlayers.playersColors = this.mappedColours;
            SceneManager.LoadScene("GameScene");
        }
    }

    public void Add(int id, Color color) {
        if (mappedColours.ContainsValue(color)) throw new System.ArgumentException();
        mappedColours.Add(id, color);
    }
}
