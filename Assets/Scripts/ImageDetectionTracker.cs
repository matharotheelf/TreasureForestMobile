using UnityEngine;

namespace UnityEngine.XR.ARFoundation
{

    public class ImageDetectionTracker : MonoBehaviour
    {
        [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;
        [SerializeField]

        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {

                // Handle added event
            }

            foreach (var updatedImage in eventArgs.updated)
            {
                // Handle updated event
            }

            foreach (var removedImage in eventArgs.removed)
            {
                // Handle removed event
            }
        }
    }
}
