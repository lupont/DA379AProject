using UnityEngine;
using TMPro;

public class AlexEndSplash : MonoBehaviour
{
    public const int WINNER = 0;
    public const int LOSER = 1;

    public TextMeshProUGUI text;
    private string[] messages = {"You are victorious", "You are a loser"};

    public void SetMessage(int index)
    {
        if (index < 0 || index > 1)
            index = 1;

        text.text = messages[index];
    }
}
