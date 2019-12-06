using UnityEngine;
using Vuforia;
using planetsBehaviour;

public class OrbitButton : MonoBehaviour, IVirtualButtonEventHandler
{
    [SerializeField] GameObject buttonObj;
    [SerializeField] RotateAround[] satelites;

    private void Start()
    {
        buttonObj = GameObject.Find("OrbitPlanetsButton");
        buttonObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        for (int i = 0; i < satelites.Length; i++)
        {
            satelites[i].OrbitAround();
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        for (int i = 0; i < satelites.Length; i++)
        {
            satelites[i].StopOrbit();
        }
    }
}
