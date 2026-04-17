using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HPText;

    public void UpdateHP(float value)
    {
        HPText.text = "HP : " + value.ToString();
    }
}
