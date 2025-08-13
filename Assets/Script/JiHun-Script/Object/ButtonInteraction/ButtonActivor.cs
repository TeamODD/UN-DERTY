using System.Collections.Generic;
using UnityEngine;

public class ButtonActivor : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Button button = collision.gameObject.GetComponent<Button>();
        if (button == null)
            return;

        currentPossibleActiveButtons.Add(button);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Button button = collision.gameObject.GetComponent<Button>();
        if (button == null)
            return;

        currentPossibleActiveButtons.Remove(button);
    }
    public void Update()
    {
        foreach(Button button in currentPossibleActiveButtons)
            button.Active();
    }
    private List<Button> currentPossibleActiveButtons = new List<Button>();
}
