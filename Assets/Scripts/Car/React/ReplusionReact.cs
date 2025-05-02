using System.Collections;
using UnityEngine;

public class ReplusionReact : IReactPlayer
{
    public IEnumerator React(Car player, Vector2 direction)
    {
        float pushDistance = 1f;
        float angle = 0f;
        Vector3 targetPosition = player.transform.position;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                targetPosition += Vector3.left * pushDistance;
                angle = -13f;

            }
            else
            {
                targetPosition += Vector3.right * pushDistance;
                angle = -80f;
            }
        }
        else
        {
            if (direction.y > 0)
            {
                targetPosition += Vector3.down * pushDistance;
                angle = 0;
            }
        }
        float duration = 0.3f;
        float elapsed = 0f;
        Vector3 startPosition = player.transform.position;
        float startAngle = player.transform.rotation.eulerAngles.z;
        player.setInputControl(false);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            float rot = Mathf.LerpAngle(startAngle, angle, t);
            player.transform.rotation = Quaternion.Euler(0, 0, rot);
            yield return null;
        }
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            float rot = Mathf.LerpAngle(angle, player.InitialRotationZ, t);
            player.transform.rotation = Quaternion.Euler(0, 0, rot);
            yield return null;
        }
        player.setInputControl(true);
    }
}