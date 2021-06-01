using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMovementToGlitter : MonoBehaviour
{
    private void OnBecameVisible()
    {
#if UNITY_EDITOR
        if (Camera.current && Camera.current.name == "SceneCamera") return;
#endif
        if (DifficultyManager.Instance.difficultyLevel == DifficultyManager.EDifficultyLevel.veryHard)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.pause = true;
            PrinceOfMoroccoManager.Instance.StartAction();
        }
    }
}