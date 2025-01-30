using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explode))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointPosition;
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Player _player;
    [SerializeField] private Explode _explode;

    private int _minRandomValue = 2;
    private int _maxRandomValue = 6;
    private int _indexForDerciseChanceSpleet = 2;
    private float _maximumChance = 100f;
    private float _minimumChance = 0f;

    private void Start()
    {
        CreateCube(_prefabCube, _pointPosition.position);
        CreateCube(_prefabCube, _pointPosition.position + new Vector3(10, 0, 0));
        CreateCube(_prefabCube, _pointPosition.position + new Vector3(1, 0, -6));
    }

    private void OnEnable()
    {
        _player.CubeDestroed += CreateRedusedCubes;
    }

    private void OnDisable()
    {
        _player.CubeDestroed -= CreateRedusedCubes;
    }

    private Cube CreateCube(Cube cube, Vector3 position)
    {
        Cube newCube = Instantiate(cube, position, Quaternion.identity);

        return newCube;
    }

    private void CreateRedusedCubes(Cube newCube)
    {
        int countCubes = Random.Range(_minRandomValue, _maxRandomValue);
        float chance = Random.Range(_minimumChance, _maximumChance);

        List<Cube> cubes = new List<Cube>();

        Vector3 scale = newCube.transform.localScale / 2;
        float chanceToSplite = newCube.ChanceToSplit / _indexForDerciseChanceSpleet;

        Debug.Log(chanceToSplite);

        if (chance <= chanceToSplite)
        { 
            for (int i = 0; i < countCubes; i++)
            {
                newCube = CreateCube(newCube, newCube.Position);
                newCube.Init(newCube, scale, chanceToSplite);
                cubes.Add(newCube);
            }
        }
        
        _explode.Exploded(cubes, transform.position);
    }
}
