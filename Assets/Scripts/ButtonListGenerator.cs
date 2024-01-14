using UnityEngine;
using UnityEngine.UI;

public class ButtonListGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform contentPanel;
    public ScrollRect scrollRect;

    private int buttonCount = 10; // Number of buttons
    private string[] buttonNames;

    void Start()
    {
        Debug.Log("Generating Buttons ");
        GenerateButtonList();
    }

    void GenerateButtonList()
{
    buttonNames = new string[buttonCount];

    // Create a vertical layout group on the content panel
    VerticalLayoutGroup verticalLayout = contentPanel.GetComponent<VerticalLayoutGroup>();
    // Ensure that the child controls height to enable proper layouting
    verticalLayout.childControlHeight = true;

    for (int i = 0; i < buttonCount; i++)
    {
        buttonNames[i] = "lab" + (i + 1);

        GameObject button = Instantiate(buttonPrefab) as GameObject;
        button.transform.SetParent(contentPanel);

        // Set the button's text
        
        Text textComponent = button.GetComponentInChildren<Text>(true);
        if (textComponent != null)
        {
          textComponent.text = buttonNames[i];
        }

        // Set the RectTransform properties for layouting
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        buttonRect.anchorMin = new Vector2(0, 1); // Anchor to top-left corner
        buttonRect.anchorMax = new Vector2(1, 1);
        buttonRect.pivot = new Vector2(0.5f, 0.5f); // Center pivot

        // Optionally, set the size of the button
        buttonRect.sizeDelta = new Vector2(50, 50);

        // You can attach a click event listener here if needed
        button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(buttonNames[i-1]));
    }

    // Update the content size of the scroll view
    LayoutRebuilder.ForceRebuildLayoutImmediate(contentPanel.GetComponent<RectTransform>());
    scrollRect.normalizedPosition = new Vector2(0, 1); // Scroll to the top
}


   /*
    void GenerateButtonList()
    {
        buttonNames = new string[buttonCount + 1];

        for (int i = 0; i < buttonCount; i++)
        {
            buttonNames[i] = "lab" + (i + 1);

            GameObject button = Instantiate(buttonPrefab) as GameObject;
            button.transform.SetParent(contentPanel);

            // Set the button's text
            Text textComponent = button.GetComponentInChildren<Text>(true);
            if (textComponent != null)
            {
                textComponent.text = buttonNames[i];
            }
            // Set the RectTransform properties for layouting
            RectTransform buttonRect = button.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0, 1); // Anchor to top-left corner
            buttonRect.anchorMax = new Vector2(1, 1);
            buttonRect.pivot = new Vector2(0.5f, 0.5f); // Center pivot

            // Optionally, set the size of the button
            buttonRect.sizeDelta = new Vector2(1, 1);

            // You can attach a click event listener here if needed
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(buttonNames[i]));
        }

        // Update the content size of the scroll view
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentPanel.GetComponent<RectTransform>());
        scrollRect.normalizedPosition = new Vector2(0, 1); // Scroll to the top
    }
    */
    /*
        void GenerateButtonList()
        {
            buttonNames = new string[buttonCount];

            for (int i = 0; i < buttonCount; i++)
            {
                buttonNames[i] = "lab" + (i + 1);

                GameObject button = Instantiate(buttonPrefab) as GameObject;
                button.transform.SetParent(contentPanel);

                // Set the button's text
                //button.GetComponentInChildren<Text>().text = buttonNames[i];
                //button.GetComponentInChildren<Text>(true)?.text = buttonNames[i];
                Text textComponent = button.GetComponentInChildren<Text>(true);
                if (textComponent != null)
                {
                    textComponent.text = buttonNames[i];
                }


                // You can attach a click event listener here if needed
                button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(buttonNames[i]));
            }

            // Update the content size of the scroll view
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentPanel.GetComponent<RectTransform>());
            scrollRect.normalizedPosition = new Vector2(0, 1); // Scroll to the top
        }
        */

    void OnButtonClick(string buttonName)
    {
        Debug.Log("Button Clicked: " + buttonName);
        // Add your button click logic here
    }
}


