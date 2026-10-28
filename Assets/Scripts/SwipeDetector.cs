using UnityEngine;

public class SwipeDetector {

    private Vector2 anchorPosition;
    private bool isTracking;

    public void Begin(Vector2 startPosition) {
        anchorPosition = startPosition;
        isTracking = true;
    }
    
    public void End() {
        isTracking = false;
    }

    public bool TryToDetectSwipe(Vector2 currentPosition, float thresholdPixels, out Vector2 direction) {
        direction = Vector2.zero;
        
        if (!isTracking || thresholdPixels <= 0f) return false;

        Vector2 delta = currentPosition - anchorPosition;
        
        if (delta.sqrMagnitude < thresholdPixels * thresholdPixels) return false;
        
        direction = Mathf.Abs(delta.x) > Mathf.Abs(delta.y)
            ? new Vector2(Mathf.Sign(delta.x), 0f)
            : new Vector2(0f, Mathf.Sign(delta.y));
        
        anchorPosition = currentPosition;
        return true;
    }
}
