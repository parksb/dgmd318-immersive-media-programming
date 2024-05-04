using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLabels : MonoBehaviour
{
    public TMP_Text objectsAliveText;
    public TMP_Text objectsDestroyedText;
    public TMP_Text modeText;

    public void UpdateObjectsAliveLabel(int count)
    {
        objectsAliveText.text = "Objects alive: " + count;
    }

    public void UpdateModeLabel(string mode)
    {
        modeText.text = "Mode: " + mode;
    }

    public void UpdateObjectsDestroyedLabel(int count)
    {
        objectsDestroyedText.text = "Objects destroyed: " + count;
    }
}
