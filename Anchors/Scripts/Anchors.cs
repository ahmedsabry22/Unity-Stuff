

// This script was created by: Ahmed Sabry
// for contact: ahmedsabry19@outlook.com
// Linkedin: https://www.linkedin.com/in/ahmed-sabry19
// Youtube: https://www.youtube.com/ahmedsabrygamedev
// My regards


using UnityEngine;

[ExecuteInEditMode]
public class Anchors : MonoBehaviour
{
    private static float parentRectWidth, parentRectHeight;

    private static RectTransform rectTransform;

    private static float thisRectWidth, thisRectHeight;

    private static Vector3 rectInitialPosition;
    private static Vector2 minAnchors;
    private static Vector2 maxAnchors;
    private static Vector2 rectPositionRelativeToParent;
    private static Vector2 initialPivot;

    private static float rectWidthRatio;
    private static float rectHeightRatio;

    private static void SetInitialValues()
    {
        // Initial Position, because we will reset the position later.
        rectInitialPosition = rectTransform.localPosition;
        initialPivot = rectTransform.pivot;

        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        // Screen dimensions:-
        // We do not use Screen.width and Screen.height here, because these variables are only set correctly in play mode, but in edit mode, they return the size of the game window, it's a litte bit tricky -_- .
        // We do not use screen dimensions anymore. Instead we use the parent rect's dimensions.


        // parent dimensions.
        parentRectWidth = rectTransform.parent.GetComponent<RectTransform>().rect.width;
        parentRectHeight = rectTransform.parent.GetComponent<RectTransform>().rect.height;


        // Rect dimensions.
        thisRectWidth = rectTransform.rect.width;
        thisRectHeight = rectTransform.rect.height;


        // Relative position:-
        // width, and height. We add 0.5 to X and Y coordinates becuase the center in local space is (0, 0) while the center in world space (0.5, 0.5).
        rectPositionRelativeToParent = new Vector2(
            (rectTransform.localPosition.x / parentRectWidth) + 0.5f,
            (rectTransform.localPosition.y / parentRectHeight) + 0.5f);


        // rectWidthRatio and rectHeightRatio return the ratio of the current rect's dimensions relative to screen. e.g if parent rect's width = 400 and current rect's width = 100, then rectWidthRatio will be 0.25 
        rectWidthRatio = thisRectWidth / parentRectWidth;
        rectHeightRatio = thisRectHeight / parentRectHeight;

        float minX = rectPositionRelativeToParent.x - (rectWidthRatio / 2);
        float minY = rectPositionRelativeToParent.y - (rectHeightRatio / 2);

        float maxX = rectPositionRelativeToParent.x + (rectWidthRatio / 2);
        float maxY = rectPositionRelativeToParent.y + (rectHeightRatio / 2);

        minAnchors = new Vector2(minX, minY);
        maxAnchors = new Vector2(maxX, maxY);
    }

    public static void SetAnchorsToRect(RectTransform rect)
    {
        // 1) We will get the current position, width, and height of the rect transform, because we will reset these values after setting the anchor. That's because when the anchors positions change, they autmatically change the coordinates of the rect transform.
        // 2) we will get the width and height of the parent's rect transform.
        // 3) we will get the width and height of this rect's transform.
        // 4) we have to find the rect transform's position in relativity with parent width, and height. (rectTransform.position.x / parent.width)

        rectTransform = rect;

        // Here we calculate the min and max anchors.
        SetInitialValues();


        // And finally setting the anchors.
        rectTransform.anchorMin = minAnchors;
        rectTransform.anchorMax = maxAnchors;


        // Resetting the rect to its initial position, width, and height.
        rectTransform.pivot = initialPivot;
        rectTransform.localPosition = rectInitialPosition;


        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, thisRectHeight);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thisRectWidth);
    }

}