using UnityEngine;

public class Camera1 : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void LateUpdate()
    {
        transform.position = new Vector3(
            _target.position.x,
            _target.position.y,
            transform.position.z);
    }
}
