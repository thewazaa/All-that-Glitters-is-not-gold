using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMovementToGlitter : MonoBehaviour
{
    private void OnBecameVisible()
    {
        if (DifficultyManager.Instance.difficultyLevel == DifficultyManager.EDifficultyLevel.veryHard)
        {
            GameManager.Instance.pause = true;
            PrinceOfMoroccoManager.Instance.StartAction();
        }
    }
}