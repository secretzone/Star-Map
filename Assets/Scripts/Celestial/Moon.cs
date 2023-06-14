using UnityEngine;

public class Moon : MonoBehaviour
{
    private PlanetData _moonData;
    private bool _initialized = false;
    public ClickableMoon clickableMoon;
    public float rotationAngle = 0f;
    private int _order = 0;
    
    public void Initialize(PlanetData moon, int order)
    {
        _moonData = moon;
        _order = order;
        clickableMoon.Initialize(_moonData, GetPlanetDistance());
        _initialized = true;
    }
    
    public float GetPlanetDistance()
    {
        return (_order + 1) * InnerSystem.instance.distanceScale; 
    }

    private void Update()
    {
        if (!_initialized) return;
        AddRotation();
        UpdatePosition();
    }

    private void AddRotation()
    {
        float step = ((SolarSystem.instance.orbitSpeed / GetPlanetDistance()) * 360) * Time.deltaTime;
        rotationAngle = Limits.Constrain(transform.eulerAngles.z + step, 0f, 360f);
    }

    private void UpdatePosition()
    {
        transform.rotation = Quaternion.Euler(transform.parent.eulerAngles.x, 0, rotationAngle);
    }
}
