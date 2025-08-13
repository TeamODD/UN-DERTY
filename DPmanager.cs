using UnityEngine;
using UnityEngine.UI;

public class DPmanager : MonoBehaviour
{
    public static DPmanager Instance;

    public int currentDP = 0;
    public int maxDP = 100;

    public Slider dpSlider;
    public Image dpFill;
    public Color safeColor = Color.green;
    public Color warningColor = Color.red;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        LoadDP();
        UpdateUI();
    }

    public void AddDP(int amount)
    {
        currentDP += amount;
        Debug.Log($"DP +{amount}: ���� DP = {currentDP}");
        UpdateUI();
        CheckDPThreshold();
    }

    public void RemoveDP(int amount)
    {
        currentDP = Mathf.Max(currentDP - amount, 0);
        Debug.Log($"DP -{amount}: ���� DP = {currentDP}");
        UpdateUI();
    }

    void CheckDPThreshold()
    {
        if (currentDP >= maxDP)
        {
            Debug.Log("DP �ִ�ġ ���� - é�� ����");
            ResetDP();
            ResetStage();
        }
    }

    void UpdateUI()
    {
        if (dpSlider != null)
        {
            dpSlider.maxValue = maxDP;
            dpSlider.value = currentDP;
        }

        if (dpFill != null)
        {
            dpFill.color = (currentDP >= 3) ? warningColor : safeColor;
        }
    }

    public void ResetDP()
    {
        currentDP = 0;
        UpdateUI();
    }

    public void ResetStage()
    {
        // ���⿡ ���� ó��: �� ����� ��
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    public void SaveDP()
    {
        PlayerPrefs.SetInt("SavedDP", currentDP);
        PlayerPrefs.Save();
    }

    public void LoadDP()
    {
        currentDP = PlayerPrefs.GetInt("SavedDP", 0);
    }

    public bool CheckNPCCondition(int threshold)
    {
        return currentDP >= threshold;
    }
}
