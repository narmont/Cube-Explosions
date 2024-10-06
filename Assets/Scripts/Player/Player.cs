using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _pointer;

    private float _maximumChance = 100f;
    private float _minimumChance = 0f;

    private void LateUpdate()
    {
        Guide();
    }

    private void Guide()
    {
        RaycastHit targetHit;
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, mousePos, Color.yellow);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out targetHit))
            {
                _pointer.position = targetHit.point;

                InitializationCubes(targetHit);
            }
        }
    }

    private void InitializationCubes(RaycastHit targetHit)
    {
        float chance = Random.Range(_minimumChance, _maximumChance);

        if (targetHit.collider.gameObject.GetComponent<Cube>())
        {
            var cube = targetHit.collider.gameObject.GetComponent<Cube>();

            Destroy(targetHit.collider.gameObject);

            if (chance <= cube.Chance)
                cube.Create(cube);
        }
    }
}
