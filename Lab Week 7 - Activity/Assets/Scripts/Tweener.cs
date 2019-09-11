
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    //private Tween activeTween;

    private List<Tween> activeTweens = new List<Tween>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

#if false
         //90%
        float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
        if (distance > 0.1f)
        {
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;

            // Linear interpolation
            //  activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);

            // Cubic easing-in interplation
            activeTween.Target.position = Coserp(activeTween.StartPos, activeTween.EndPos, timeFraction);  

        }

        if (distance <= 0.1f)
        {
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }
#endif

        // 100%
        // Loop through all elements on the activeTweens list, updating all of their positions
        foreach (Tween item in activeTweens)
        {
            MoveTween(item);
        }

    }

    //100%
    public void MoveTween(Tween activeTween)
    {
        float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
        if (distance > 0.1f)
        {
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;

            // Linear interpolation
            //  activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);

            // Cubic easing-in interplation
            activeTween.Target.position = Coserp(activeTween.StartPos, activeTween.EndPos, timeFraction);
        }

        if (distance <= 0.1f)
        {
            activeTween.Target.position = activeTween.EndPos;
            // Once a tween complete, remove it from the activeTweens list.
            activeTweens.Remove(activeTween);
        }
    }

    //Ease in http://wiki.unity3d.com/index.php?title=Mathfx#C.23_-_Mathfx.cs
    public static float Coserp(float start, float end, float value)
    {
        return Mathf.Lerp(start, end, 1.0f - Mathf.Cos(value * Mathf.PI * 0.5f));
    }

    public static Vector3 Coserp(Vector3 start, Vector3 end, float value)
    {
        return new Vector3(Coserp(start.x, end.x, value), Coserp(start.y, end.y, value), Coserp(start.z, end.z, value));
    }


    /* 90%
    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
    }
    */

        //100%
    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        
         if (TweenExists(targetObject) == false)
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool TweenExists(Transform target)
    {
        foreach (Tween item in activeTweens)
        {
            if (item.Target.Equals(target))
            {
                return true;
            }            
        }

        return false;
    }
}
