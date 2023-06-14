using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class InnerSystem : MonoBehaviour
{
    public static InnerSystem instance;
    [FormerlySerializedAs("innerPlanetPrefab")] public InnerPlanet planetPrefab;
    public Moon moonPrefab;
    private StarData _starData;
    private List<Moon> _moons;
    private InnerPlanet _planet;
    private PlanetData _planetData;
    
    [Header("UI")]
    public GameObject ui;
    public TextMeshProUGUI innerSystemName;
    public TextMeshProUGUI innerSystemCoords;
    
    [Header("Scale")]
    public float orbitSpeed = 0.001f;
    public float distanceScale = 0.001f;
    public float rotationOffset = 70f;
    public float planetScale = 1f;
    public float moonScale = 0.5f;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            _starData = GameManager.instance.activeSystem;
            _planetData = GameManager.instance.activeInnerSystem;
            _moons = new List<Moon>();
            innerSystemName.text = _planetData.name;
            innerSystemCoords.text = _starData.GetPosition2D().ToString();
            SpawnBodies();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void SpawnBodies()
    {
        ClearBodies();
        Debug.Log("Spawning main planet");
        _planet = Instantiate(planetPrefab, transform.position, Quaternion.identity, transform);
        _planet.Initialize(_planetData);
        
        Debug.Log("Spawning moons");
        for (int i = 0; i < _planetData.moons.Count; i++)
        {
            Moon m = Instantiate(moonPrefab, transform.position, 
                Quaternion.identity, transform);
            m.Initialize(_planetData.moons[i], i);
            _moons.Add(m);
        }
        Debug.Log("Done spawning");
    }

    private void ClearBodies()
    {
        
    }

    public void GoToSystemView()
    {
        Debug.Log("Going back");
        GameManager.instance.ShowSolarSystemView(_starData);
    }

}
