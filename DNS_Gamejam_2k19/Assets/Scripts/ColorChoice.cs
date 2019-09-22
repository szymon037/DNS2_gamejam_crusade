using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChoice : MonoBehaviour
{

    public Color[] colorsToChoose;
    public Dictionary<int, string> colorNames;
    public Dictionary<string, Color> colors;
    public ColorPicker colorPicker;
    public Image colorImage;
    public int id = 0;
    private int index = 0;

    private string axisName;
    [SerializeField]
    private bool pressed;
    private bool colorChosen;

    // Start is called before the first frame update
    void Start()
    {
        colorNames = new Dictionary<int, string>() {
            {0, "red"},
            {1, "green"},
            {2, "blue"},
            {3, "yellow"}
        };
        colors = new Dictionary<string, Color>() {
            {"red", new Color(1f, 0f, 0f)},
            {"green", new Color(0f, 1f, 0f)},
            {"blue", new Color(0f, 0f, 1f)},
            {"yellow", new Color(1f, 1f, 0f)}
        };
        colorsToChoose = colorPicker.colors;
        colorImage = this.gameObject.GetComponent<Image>();
      //  colorImage.color = colorsToChoose[index];
        colorImage.color = colors[colorNames[index]];
        axisName = $"DPadHorizontal{id}";
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChosen) return;
        float inputValue = Input.GetAxis(axisName);
        if (inputValue != 0f) {
            if (pressed) return;
            pressed = true;
            if (inputValue > 0f) {
                try {
                    index++;
                    colorImage.color = colors[colorNames[index]];
                } catch (KeyNotFoundException) {
                    index = 0;
                    colorImage.color = colors[colorNames[index]];
                }
            } else {
                try {
                    index--;
                    colorImage.color = colors[colorNames[index]];
                } catch (KeyNotFoundException) {
                    index = colorsToChoose.Length - 1;
                    colorImage.color = colors[colorNames[index]];
                }
            }
            inputValue = 0f;
            return;
        } else {
            pressed = false;
        }

        bool buttonPressed = Input.GetKeyDown($"joystick {id} button 0");

        if (buttonPressed) {
            Debug.Log("Pressed A: " + buttonPressed.ToString());
            Debug.Log($"{colorPicker.mappedColours.Count}");
            foreach (var entry in colorPicker.mappedColours) {
                Debug.Log($"id: {entry.Key}, Color: {entry.Value.ToString()}");
            }
            try {
                colorPicker.Add(id, colorNames[index]);
                colorChosen = true;
                Debug.Log($"color chosen for player nr {id}. value: {colorsToChoose[index]}");
            } 
            catch (System.IndexOutOfRangeException) {
                
                return;
            } 
            catch (System.ArgumentException) {
                //handle choosing other color
                Debug.Log("Color is already chosen!");
            }
        }
        pressed = false;
    }

}
