using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Rigidbody _rigidbody;

   public void SetDirection(Vector3 direction)
    {
        _rigidbody.velocity = direction.normalized * _speed;
    }
}