using System.Collections;
using UnityEngine;

namespace planetsBehaviour
{
    public class RotateAround : MonoBehaviour
    {
        [SerializeField] GameObject objectToOrbit;
        [SerializeField] float angularSpeed = 20;
        [SerializeField] float secondsToWait = 0.01f;
        [SerializeField] Vector3 rotationAxis = new Vector3(1.0f, 0.0f, 1.0f);

        bool orbitBool = true;

        public void OrbitAround()
        {
            orbitBool = true;
            StartCoroutine(Orbit());
        }

        public void StopOrbit()
        {
            StopCoroutine(Orbit());
            orbitBool = false;
        }

        private IEnumerator Orbit()
        {
            while(orbitBool)
            {
                transform.RotateAround(objectToOrbit.transform.position, rotationAxis, angularSpeed * Time.deltaTime);
                yield return new WaitForSeconds(secondsToWait);
            }
        }
    }
}

