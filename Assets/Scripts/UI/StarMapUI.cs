using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarMapUI : MonoBehaviour
{
    public TextMeshPro starNameText;
    public Transform starNameAnchor;

    public Camera starMapCamera;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Enabled(bool enabled)
    {
        starMapCamera.gameObject.SetActive(enabled);
        // starNameText.gameObject.SetActive(enabled);
        // starNameAnchor.gameObject.SetActive(enabled);
    }

    public void SetStarNameTextPosition(Vector3 pos)
    {
        starNameAnchor.position = starMapCamera.WorldToScreenPoint(pos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
