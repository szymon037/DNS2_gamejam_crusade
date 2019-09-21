using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SpawnPlayers : MonoBehaviour
{
    [System.Serializable]
    public struct ModelInfo {
        public GameObject model;
        public Color color;
    }
    public Dictionary<int, Color> playersColors;
    bool spawned = false;
    public List<ModelInfo> models;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        var scene = SceneManager.GetActiveScene();
        if (scene.name == "GameScene" && !spawned) {
            spawned = true;
            SpawnPlayerModels();
        }
    }

    void SpawnPlayerModels() {
        int offset = 10;
        int currentOffset = 0;
        Debug.Log(playersColors.Count.ToString());
        foreach (var key in playersColors.Keys) {
            try {
                Vector3 vec = new Vector3((float)currentOffset, 0f, 0f);
                var modelInfo = models.FirstOrDefault(m => ColorsEqual(m.color, playersColors[key]));
                Debug.Log((modelInfo.model == null).ToString());
                GameObject player = Instantiate(modelInfo.model, vec, Quaternion.identity) as GameObject;
                PlayerMovement movementScript = player.GetComponent<PlayerMovement>();
                currentOffset += offset;
                if (movementScript != null) {
                    movementScript.id = key;
                }
            } catch (System.Exception) {}
        }
    }

    bool ColorsEqual(Color c1, Color c2) {
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
}
