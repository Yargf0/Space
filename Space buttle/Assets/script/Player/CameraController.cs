using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float zPosition = -5f;
    [SerializeField] private float tpDistance = 0.25f;
    [SerializeField] private Transform target;

    [Header("Zoom")]
    [SerializeField] private float zoomRate = 1f;

    [SerializeField] private float minSize = 1f;
    [SerializeField] private float maxSize = 30f;
    

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        cam.orthographic = true;

        if (minSize > maxSize)
        {
            float tmp = minSize;
            minSize = maxSize;
            maxSize = tmp;
        }
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        if (target == null)
            return;
        Vector3 newPosition;

        if (Vector3.Distance(transform.position, target.position) < tpDistance)
            newPosition = target.position;
        else
            newPosition = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

        newPosition.z = zPosition;
        transform.position = newPosition;
    }

    private void Zoom()
    {
        float newZoom = cam.orthographicSize + (-Input.mouseScrollDelta.y * zoomRate);
        cam.orthographicSize = Mathf.Clamp(newZoom, minSize, maxSize);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
