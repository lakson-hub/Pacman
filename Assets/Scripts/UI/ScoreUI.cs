using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreTextMesh;

    private void Start() {
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
        
        UpdateVisual();
    }

    private void OnDestroy() {
        if (ScoreManager.Instance != null) {
            ScoreManager.Instance.OnScoreChanged -= ScoreManager_OnScoreChanged;
        }
    }

    private void ScoreManager_OnScoreChanged(object sender, EventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        scoreTextMesh.text = ScoreManager.Instance.GetScore().ToString();
    }
}
