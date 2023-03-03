using System;
using System.Text;



class TextProgressBar
{
    public float Progress { get; private set; } = 0.0f;
    public int Width { get; private set; } = 10;
    public bool ShowPercent { get; set; } = false;

    private char empty_char = '-';
    private char filled_char = '=';
    private char left_endcap = '[';
    private char right_endcap = ']';

    public TextProgressBar()
    {
    }

    public TextProgressBar(int width, char left, char right, char filled, char empty)
    {
        Width = width;
        SetEndcaps(left, right);
        SetFillChar(filled, empty);
    }

    public void SetFillChar(char filled, char empty)
    {
        filled_char = filled;
        empty_char = empty;
    }

    public void SetEndcaps(char left, char right)
    {
        left_endcap = left;
        right_endcap = right;
    }

    public bool SetProgrees(float valueSet)
    {
        Progress = valueSet;
        if (Progress >= 1.0) {
            return true;
        }

        return false;
    }

    public bool AddProgress(float valueAdd)
    {
        Progress += valueAdd;

        return false;
    }

    public string Render()
    {
        StringBuilder bar = new StringBuilder(12);
        bar.Append(left_endcap);

        int amountFilled = (int)Math.Floor(Width * Progress);
        int total = Width;

        if (Progress >= 0.99) {
            amountFilled = Width;
        }

        // Quantity to fill
        for (int i = 0; i < amountFilled; i++) {
            bar.Append(filled_char);
            total--;
        }
        // Quantity to be empty
        for (int i = 0; i < (total); i++) {
            bar.Append(empty_char);
        }

        bar.Append(right_endcap);

        if (ShowPercent) {
            bar.Append(" ");
            bar.Append((int)(Progress * 100.0f));
            bar.Append("%");
        }
        
        return bar.ToString();
    }
}