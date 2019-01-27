using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopCereal : MonoBehaviour
{
    public float timeToReachMouth = 5f;
    public Transform mouth;

    private Rigidbody spoon;
    private Vector3 mouthFeedPos;
    private Vector3 bowlScoopPos;

    private void Awake ()
    {
        spoon = GetComponent<Rigidbody> ();
        spoon.isKinematic = true;
        mouthFeedPos = mouth.position;
        bowlScoopPos = transform.position;
    }

    private void Start ()
    {
        StartCoroutine (ScoopingForever ());
    }

    private IEnumerator ScoopingForever ()
    {
        bool movingUp = true;
        float tZ = 0f;
        float tY = 0f;
        float ticker = 0f;
        float z = 0f;
        float y = 0f;
        float zMouth = mouthFeedPos.z;
        float yMouth = mouthFeedPos.y;
        float zBowl = bowlScoopPos.z;
        float yBowl = bowlScoopPos.y;
        float bowlRotZ = 0f;
        float mouthRotZ = -25f;
        float zRot = 0f;

        while (true)
        {
            ticker = movingUp ? ticker + Time.deltaTime : ticker - Time.deltaTime;
            tZ = ticker / timeToReachMouth;
            if (tZ > 1f)
            {
                movingUp = false;
                tZ = 1f;
            }
            else if (tZ < 0f)
            {
                movingUp = true;
                tZ = 0f;
                yield return new WaitForSeconds (1f);
            }

            z = Mathf.Lerp (zBowl, zMouth, tZ);
            zRot = Mathf.Lerp (bowlRotZ, mouthRotZ, tZ);

            tY = QuartEaseOut (ticker, 0f, 1f, timeToReachMouth);
            y = Mathf.Lerp (yBowl, yMouth, tY);

            transform.position = new Vector3 (transform.position.x, y, z);
            transform.rotation = Quaternion.Euler (0f, 0f, zRot);
            yield return null;
        }
    }


    /// <summary>
    /// Represents an eased interpolation w/ respect to time.
    /// 
    /// float t, float b, float c, float d
    /// </summary>
    /// <param name="current">how long into the ease are we</param>
    /// <param name="initialValue">starting value if current were 0</param>
    /// <param name="totalChange">total change in the value (not the end value, but the end - start)</param>
    /// <param name="duration">the total amount of time (when current == duration, the returned value will == initial + totalChange)</param>
    /// <returns></returns>
    public static float QuartEaseOut (float t, float b, float c, float d)
    {
        return -c * ((t = t / d - 1) * t * t * t - 1) + b;
    }
}
