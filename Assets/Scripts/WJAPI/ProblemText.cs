using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TexDrawLib;

public static class ProblemText
{
    public static Dictionary<string, string> problem_text = new Dictionary<string, string>();

    public static void Setting_Dictionary()
    {
        problem_text.Add("1 + 3 = \\square", "");
        problem_text.Add("\begin{align}  28~\\ -~~~26~\\ \\hline  \\square \\end{align}","");
        problem_text.Add("\begin{align}  38 ~\\  \times ~~~1~  \\ \\hline  \\square\\square \\end{align}","");
        problem_text.Add("\frac{7}{3}=\\square","");
        problem_text.Add("\begin{align}  ~ ) \\underline{ ~~ 24 ~~~~ 18 ~}~~~~최대공약수:~\\square \\  ~~  \\end{align}","");
        problem_text.Add("4+x=6 ~\rightarrow~ x=\\square","");
        problem_text.Add("10\\%~인상\rightarrow\\square\\square\\square","");
        problem_text.Add("\begin{align} &15a^{4}b^{3}\\div\\left(-5a^{3}b\right)\times\\left(-ab^{2}\right)\\=\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square \\end{align}","");
        problem_text.Add("\begin{align}  38~\\ -~~~13~\\ \\hline  \\square\\square \\end{align}","");
        problem_text.Add("10\\%~인하\rightarrow\\square\\square\\square","");
        problem_text.Add("2ab\\div\frac{1}{4}a^{3}\times a^{4}b^{2}=\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square","");
        problem_text.Add("\frac{8}{5}=\\square","");
        problem_text.Add("\begin{align}  ~ ) \\underline{ ~~ 4 ~~~~ 8 ~} ~~~\rightarrow~최대공약수:~\\square \\  ~~  \\end{align}","");
        problem_text.Add("4+x=7+1 ~\rightarrow~ x=\\square","");
        problem_text.Add("0보다~3만큼~큰~수\rightarrow\\square\\square","");
        problem_text.Add("\begin{align}  25~\\ -~~~15~\\ \\hline  \\square\\square \\end{align}","");
        problem_text.Add("\begin{align}  12 ~\\  \times ~~~4~  \\ \\hline  \\square\\square \\end{align}","");
        problem_text.Add("\frac{12}{4}=\\square","");
        problem_text.Add("3 + 3 = \\square","");
        problem_text.Add("\begin{align}  39~\\ -~~~23~\\ \\hline  \\square\\square \\end{align}","");

        foreach (var item in problem_text)
        {
            AWS.instance.text.text = item.Key;

            Debug.Log(AWS.instance.text.text);
        }
    }

    public static string Retext_Problems(string s)
    {
        foreach (var item in problem_text)
        {
            AWS.instance.text.text = item.Key;

            if (s == AWS.instance.text.text)
            {
                Debug.Log(1);
                return item.Value;
            }
            else { Debug.Log(0); return null; }
        }
        return null;
    }
}
