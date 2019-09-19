using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed;

    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }
}
