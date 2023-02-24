using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private float destroyTime = 1f;
    [SerializeField] private float speedScaler = 250f;
    [SerializeField] private float flickThreshold = 4f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 flickDirection;
    private float flickSpeed;
    private float startTime;
    private float dragTime;
    Plane plane;
    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        startTime = Time.time;
    }

    public void OnDrag(PointerEventData eventData)
    {
        plane = new Plane(Vector3.forward, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        

        float distance;

        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.origin + ray.direction * distance;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //calculate speed based on total time mouse was dragged
        dragTime = Time.time - startTime;
        flickSpeed = Vector3.Distance(startPosition, endPosition) / (dragTime * speedScaler);


        //calculate direction of ball based on start and end of mouse click
        flickDirection = endPosition - startPosition;
        if (flickSpeed > flickThreshold)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(flickDirection * flickSpeed, ForceMode.Impulse);
            Invoke("DestroyObject", destroyTime);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //record starting position of mouse on click
        startPosition = eventData.pressPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //record end position of mouse on end of mouse click
        endPosition = eventData.position;
    }

    private void DestroyObject()
    {
        gameObject.GetComponent<Enemy>().DestroyObject();
    }
}
