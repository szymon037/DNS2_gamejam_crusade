using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChoice : MonoBehaviour
{

    public Color[] colorsToChoose;
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
        colorsToChoose = colorPicker.colors;
        colorImage = this.gameObject.GetComponent<Image>();
        colorImage.color = colorsToChoose[index++];
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
                    colorImage.color = colorsToChoose[index];
                } catch (System.IndexOutOfRangeException) {
                    index = 0;
                    colorImage.color = colorsToChoose[index];
                }
            } else {
                try {
                    index--;
                    colorImage.color = colorsToChoose[index];
                } catch (System.IndexOutOfRangeException) {
                    index = colorsToChoose.Length - 1;
                    colorImage.color = colorsToChoose[index];
                }
            }
            inputValue = 0f;
            return;
        } else {
            pressed = false;
        }

        if (Input.GetKeyDown($"joystick {id} button 0")) {
            try {
                colorPicker.Add(id, colorsToChoose[index - 1]);
                colorChosen = true;
            } 
            catch (System.IndexOutOfRangeException) {
                return;
            } 
            catch (System.ArgumentException) {
                //handle choosing other color
            } finally {
                Debug.Log(colorChosen ? $"color chosen for player nr {id}. value: {colorsToChoose[index - 1]}" : "Color is already chosen!");
            }
        }
        pressed = false;
    }

}
