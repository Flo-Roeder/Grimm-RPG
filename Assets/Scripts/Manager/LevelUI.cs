using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    public int levelRoom;
    // Start is called before the first frame update
    void Start()
    {
        textMesh= GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = "LEVEL " + "1 - " + levelRoom;
    }

    public void NextRoomUpdateLevelUI()
    {
        levelRoom++;
        textMesh.text = "LEVEL " + "1 - " + levelRoom;
    }
}
