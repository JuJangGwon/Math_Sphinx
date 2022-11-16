using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TexDrawLib;

public class ProblemText : MonoBehaviour
{
    public Dictionary<string, string> problem_text = new Dictionary<string, string>();

    [System.Serializable]
    public class problem
    {
        
    }

    private void Awake()
    {
        Setting_Dictionary(); //따로 만들기 귀찮아서 여기다가 넣음
        print(problem_text.Count);
    }

    public void Setting_Dictionary()
    {
        problem_text.Add("1 + 3 = \\square", "\\katuri{1 + 3");

        problem_text.Add("\begin{align}  28~\\ -~~~26~\\ \\hline  \\square \\end{align}", "\\katuri{28 - 26");

        problem_text.Add("\begin{align}  38 ~\\  \times ~~~1~  \\ \\hline  \\square\\square \\end{align}", "\\katuri{38 \times 1");

        problem_text.Add("\frac{7}{3}=\\square", "\frac{7}{3}");

        problem_text.Add("\begin{align}  ~ ) \\underline{ ~~ 24 ~~~~ 18 ~}~~~~최대공약수:~\\square \\  ~~  \\end{align}", "\\katuri{24, 18의 최대공약수");

        problem_text.Add("4+x=6 ~\rightarrow~ x=\\square", "\\katuri{4+x = 6, x는?");

        problem_text.Add("10\\%~인상\rightarrow\\square\\square\\square", "\\katuri{100의 10% 인상");

        problem_text.Add("\begin{align} &15a^{4}b^{3}\\div\\left(-5a^{3}b\right)\times\\left(-ab^{2}\right)\\=\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square \\end{align}", "\\katuri{15a^{4}b^{3}\\div\\left(-5a^{3}b\right)\times\\eft(-ab^{2}\right)}");

        problem_text.Add("\begin{align}  38~\\ -~~~13~\\ \\hline  \\square\\square \\end{align}", "\\katuri{38 - 13}");

        problem_text.Add("10\\%~인하\rightarrow\\square\\square\\square", "\\katuri{100의 10% 인하}");

        problem_text.Add("2ab\\div\frac{1}{4}a^{3}\times a^{4}b^{2}=\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square\\square", "\\katuri2ab\\div\frac{1}{4}a^{3}\times a^{4}b^{2}");

        problem_text.Add("\frac{8}{5}=\\square", "\\katuri\frac{8}{5}");

        problem_text.Add("\begin{align}  ~ ) \\underline{ ~~ 4 ~~~~ 8 ~} ~~~\rightarrow~최대공약수:~\\square \\  ~~  \\end{align}", "\\katuri{4, 8의 최대공약수}");

        problem_text.Add("4+x=7+1 ~\rightarrow~ x=\\square", "\\katuri{4+x=7+1, x는?}");

        problem_text.Add("0보다~3만큼~큰~수\rightarrow\\square\\square", "\\katuri{0보다 3만큼 큰 수}");

        problem_text.Add("\begin{align}  25~\\ -~~~15~\\ \\hline  \\square\\square \\end{align}", "\\katuri25 - 15");

        problem_text.Add("\begin{align}  12 ~\\  \times ~~~4~  \\ \\hline  \\square\\square \\end{align}", "\\katuri12 \times 4");

        problem_text.Add("\frac{12}{4}=\\square", "\\katuri\frac{12}{4}");

        problem_text.Add("3 + 3 = \\square", "\\katuri3 + 3");

        problem_text.Add("\begin{align}  39~\\ -~~~23~\\ \\hline  \\square\\square \\end{align}", "\\katuri39 - 23");

        problem_text.Add("4 + 3 = \\square", "\\katuri4 + 3");

        problem_text.Add("2 + 3 = \\square", "\\katuri2 + 3");

        problem_text.Add("\begin{align}  39~\\ -~~~23~\\ \\hline  \\square\\square \\end{align}", "\\katuri2 + 3");

        problem_text.Add("\begin{align}  38~\\ -~~~13~\\ \\hline  \\square\\square \\end{align} ", "\\katuri2 + 3");
    }

    public string Retext_Problems(string s)
    {
        foreach (var item in problem_text)
        {
            AWS.instance.text.text = item.Key;

            if (s == AWS.instance.text.text)
            {
                AWS.instance.text.text = item.Value;
                return AWS.instance.text.text;
            }
        }
        return s;
    }
}
