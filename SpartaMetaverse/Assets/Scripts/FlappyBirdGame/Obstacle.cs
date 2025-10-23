using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float highPosY;
    [SerializeField] float lowPosY;

    [SerializeField] float holeSizeMin;
    [SerializeField] float holeSizeMax;

    [SerializeField] Transform topObject;
    [SerializeField] Transform bottomObject;

    [SerializeField] float widthPadding;
    
    public Vector3 SetRandomPlace(Vector3 lastPosition)
    {
        RandomSetLocalPosition();
        Vector3 position = RandomSetPosition(lastPosition);
        transform.position = position;
        return position;
    }

    private void RandomSetLocalPosition()
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);
    }

    private Vector3 RandomSetPosition(Vector3 pos)
    {
        Vector3 placePosition = pos + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);
        return placePosition;
    }
}
