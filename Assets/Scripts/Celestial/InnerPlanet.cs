using Clickable;
using Data;
using UnityEngine;

namespace Celestial
{
    public class InnerPlanet : MonoBehaviour
    {
        public ClickableInnerPlanet clickableInnerPlanet;
        private bool _initialized = false;

        private PlanetData _planetData;

        // Start is called before the first frame update

        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void Initialize(PlanetData planetData)
        {
            _planetData = planetData;
            clickableInnerPlanet.Initialize(_planetData);
            _initialized = true;
        }
    }
}