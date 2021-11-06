using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public static int diamonds = 0;
    void Update()
    {
        textMesh.text ="Score: "+ diamonds.ToString();

    }
}
