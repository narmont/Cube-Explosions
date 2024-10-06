using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minRandomValue;
    [SerializeField] private int _maxRandomValue;
    [SerializeField] private float _explosionRadius = 40f;
    [SerializeField] private float _force = 100;

    private int _indexForDerciseChanceSpleet = 2;
    private int _decreaseValueScale = 2;
    private float _chanceToSplit = 100;

    public float Chance => _chanceToSplit;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    public void Create(Cube cube)
    {
        int countCubes = Random.Range(_minRandomValue, _maxRandomValue);
        List<Cube> cubes = new List<Cube>();
        
        cube.transform.localScale /= _decreaseValueScale;
        _chanceToSplit /= _indexForDerciseChanceSpleet;

        for (int i = 0; i < countCubes; i++)
        {
            Cube newCube = new Cube();
            newCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);
            cubes.Add(newCube);
            Explode(cubes);
        }
    }

    private void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            var rigidbody = cube.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _explosionRadius);
            }
        }
    }
}
