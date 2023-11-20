using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText = null;

    public void SetText(int nbKilled)
    {
        counterText.text = nbKilled.ToString();
    }
}
