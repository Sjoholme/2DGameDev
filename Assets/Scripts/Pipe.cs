using System.Collections;
using UnityEngine;
public class Pipe : MonoBehaviour
{
    public Transform connection;
    public KeyCode enterKeyCode = KeyCode.S;
    public Vector3 enterDirection = Vector3.down;
    public Vector3 exitDirection = Vector3.zero;

    /* MOVED THIS FUNCTION TO CHARACTER.CS nvm CHARANIM.CS
    private void OnCollisionStay2D(Collision2D other)
    {
        if (connection != null && other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(enterKeyCode) && other.gameObject.TryGetComponent(out Character Character))
            {
                StartCoroutine(Enter(Character));
            }
        }
    }
    */

    public IEnumerator Enter(Rigidbody2D Character)
    {
        Character.isKinematic = true;

        Vector3 enteredPosition = transform.position + enterDirection;
        Vector3 enteredScale = Vector3.one * 0.5f;

        yield return Move(Character.transform, enteredPosition, enteredScale);
        yield return new WaitForSeconds(1f);

        CameraScript sideScrolling = Camera.main.GetComponent<CameraScript>();
        sideScrolling.SetUnderground(connection.position.y < sideScrolling.GetUndergroundThreshold());

        if (exitDirection != Vector3.zero)
        {
            Character.transform.position = connection.position - exitDirection;
            yield return Move(Character.transform, connection.position + exitDirection, Vector3.one);
        }
        else
        {
            Character.transform.position = connection.position;
            Character.transform.localScale = Vector3.one;
        }

        Character.isKinematic = false;
    }

    private IEnumerator Move(Transform Character, Vector3 endPosition, Vector3 endScale)
    {
        float elapsed = 0f;
        float duration = 1f;

        Vector3 startPosition = Character.position;
        Vector3 startScale = Character.localScale;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            Character.position = Vector3.Lerp(startPosition, endPosition, t);
            Character.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        Character.position = endPosition;
        Character.localScale = endScale;
    }

}
