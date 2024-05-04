using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLabels : MonoBehaviour
{
    public TMP_Text objectAliveText;
    public TMP_Text modeText;

    public void UpdateObjectAliveLabel(int count)
    {
        objectAliveText.text = "Objects alive: " + count;
    }

    public void UpdateModeLabel(string mode)
    {
        modeText.text = "Mode: " + mode;
    }
}
