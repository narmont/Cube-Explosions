using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 40f;
    [SerializeField] private float _force = 100;

    public void Exploded(List<Cube> cubes, Vector3 center)
    {
        foreach (Cube cube in cubes)
        {
            var rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_force, center, _explosionRadius);
            }
        }
    }
}
