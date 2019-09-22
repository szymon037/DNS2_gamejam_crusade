using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using UnityEngine.SceneManagement;

 public static class ColorExtensions {
        public static bool ColorEqual(this Color c1, Color c2) {
            int r1, g1, b1;
            r1 = Mathf.RoundToInt((float)System.Math.Round((double)c1.r, 2) * 1000f);
            g1 = Mathf.RoundToInt((float)System.Math.Round((double)c1.g, 2) * 1000f) ;
            b1 = Mathf.RoundToInt((float)System.Math.Round((double)c1.b, 2) * 1000f);
            int r2, g2, b2;
            r2 = Mathf.RoundToInt((float)System.Math.Round((double)c2.r, 2) * 1000f);
            g2 = Mathf.RoundToInt((float)System.Math.Round((double)c2.g, 2) * 1000f);
            b2 = Mathf.RoundToInt((float)System.Math.Round((double)c2.b, 2) * 1000f);
            Debug.Log(string.Format("RGB: {0} {1} {2}", r1, g1, b1));
            Debug.Log(string.Format("RGB: {0} {1} {2}", r2, g2, b2));
            return (r1 == r2 && g1 == g2 && b1 == b2);
        }

        public static bool Contains(this Dictionary<int, Color> dict, System.Func<Color, bool> predicate) {
            foreach (var entry in dict) {
                if (predicate(entry.Value)) {
                    return true;
                }
            }
            return false;
        }
    }

public class ColorPicker : MonoBehaviour
{
   

    public Color[] colors;
    public Dictionary<int, string> colorNames;
    public Dictionary<string, Color> mappedColours;

    public GameObject playerSlotsParent;
    public GameObject[] activePlayerSlots;
    public SpawnPlayers spawnPlayers;

    void Start() {
        colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };
        colorNames = new Dictionary<int, string>();
        
        
        mappedColours = new Dictionary<string, Color>() {
            {"red", new Color(1f, 0f, 0f)},
            {"green", new Color(0f, 1f, 0f)},
            {"blue", new Color(0f, 0f, 1f)},
            {"yellow", new Color(1f, 1f, 0f)}
        };
        List<Transform> children = new List<Transform>();
        foreach (Transform child in playerSlotsParent.transform) {
            child.gameObject.SetActive(false);
            children.Add(child);
        }

        for (int i = 0; i < GameManager.GamepadCount; ++i) {
            children[i].gameObject.SetActive(true);
        }

        activePlayerSlots = children.Where(c => c.gameObject.activeSelf).Select(c => c.gameObject).ToArray();
    }

    void Update() {
        if (colorNames.Count == activePlayerSlots.Length) {
            spawnPlayers.playersColors = this.colorNames.ToDictionary(entry => entry.Key, entry => mappedColours[entry.Value]);
            GameManager.instance.CurrentState = GameManager.GameState.GAME;
        }
    }

    public void Add(int id, string colorName) {
        if (this.colorNames.ContainsValue(colorName)) throw new System.ArgumentException();
        colorNames.Add(id, colorName);
    }

}
