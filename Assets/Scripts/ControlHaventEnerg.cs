using UnityEngine;
using UnityEngine.UI;
public class ControlHaventEnerg : MonoBehaviour
{
    public Text text;
    public GameObject txt;
    private void Update()
    {
        if (text.fontSize == 101)
        {
            txt.SetActive(false);
        }
    }
}
