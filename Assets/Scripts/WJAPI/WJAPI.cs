using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WJAPI : MonoBehaviour
{
    // 우리가 필요한거 
    public string Problem_Answer;          // 문제가 생성된후 api로 부터 알아온 정답
    public string[] Answer_Selection;      // 4지선다 문제 정답 선택지
    public static int Answer_num;                 // 위 4개 배열중 어느번째 선택지가 정답인.
    public string Problem_Explain;         // 문제 설명
    public int Answer_Count;               // 보기 개수




    //

    public WJAPI2 WJAPI2;
    public TextMeshProUGUI txQuestion;
    //public Rug[] btAnsr = new Rug[2];

    //public GameObject btStart;

    protected TextMeshProUGUI[] txAnsr;


    public enum STATE
    {
        DN_SET,         
        DN_PROG,       
        LEARNING,     
    }

    public STATE eState;
    protected bool bRequest;

    protected int nDigonstic_Idx;   

    protected WJAPI2.Learning_Data cLearning;
    protected int nLearning_Idx;    
    protected string[] strQstCransr = new string[8];       
    protected long[] nQstDelayTime = new long[8];       


    void Awake()
    {
        eState = STATE.DN_SET;              // 진단 단계 설정하는 곳 

        cLearning = null;
        nLearning_Idx = 0;
        bRequest = false;
        WJAPI2.OnRequest_DN_Setting(0);              // 0 레벨 문제로 시작
    }


    public void MakeQuestion()                          // 문제 출제 함수 
    {
        switch (eState)
        {
            case STATE.DN_SET: DoDN_Start(); break;             // 진단평가 진행중인경우 
            case STATE.LEARNING: DoLearning(); break;           // 학습중인 경우 
        }
    }

    // 버튼식을 사용할 때 [ 정답 클릭식으로 사용할 때]
    public void OnClick_Ansr(int _nIndex)               // 정답 버튼 누를때
    {
        switch (eState)
        {
            case STATE.DN_SET:
            case STATE.DN_PROG:                         // 진단 
                {
                    DoDN_Prog(Answer_Selection[_nIndex]);
                }
                break;
            case STATE.LEARNING:
                {
                    strQstCransr[nLearning_Idx - 1] = Answer_Selection[_nIndex];
                    nQstDelayTime[nLearning_Idx - 1] = 5000;       
                    DoLearning();
                }
                break;
        }
    }
   

    protected void DoDN_Start()
    {
        nDigonstic_Idx = 0;
        WJAPI2.OnRequest_DN_Setting(0);
        bRequest = true;
    }


    protected void DoDN_Prog(string _qstCransr)
    {
        string strYN = "N";
        if (WJAPI2.cDiagnotics.data.qstCransr.CompareTo(_qstCransr) == 0)
            strYN = "Y";

        WJAPI2.OnRequest_DN_Progress("W",
                                         WJAPI2.cDiagnotics.data.qstCd,          // ???? ????
                                         _qstCransr,                                // ?????? ?????? -> ???????? ?????? ???? ?????? ????
                                         strYN,                                     // ????????("Y"/"N")
                                         WJAPI2.cDiagnotics.data.sid,            // ???? SID
                                         5000);                                     // ?????? - ???? ?????? ?????? ????

        bRequest = true;
    }


    protected void DoLearning()
    {
        if (cLearning == null)
        {
            nLearning_Idx = 0;
            //   SetActive_Question(true);

            WJAPI2.OnRequest_Learning();

            bRequest = true;
        }
        else
        {
            if (nLearning_Idx >= WJAPI2.cLearning_Info.data.qsts.Count)
            {
                WJAPI2.OnLearningResult(cLearning, strQstCransr, nQstDelayTime);      // ???? ???? ????
                cLearning = null;

             //   SetActive_Question(false);
                return;
            }

            MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);


            ++nLearning_Idx;

            bRequest = false;
        }
    }


    protected void MakeQuestion(string _qstCn, string _qstCransr, string _qstWransr)
    {
        char[] SEP = { ',' };
        string[] tmWrAnswer;

        Problem_Explain = WJAPI2.GetLatexCode(_qstCn);
        txQuestion.text = Problem_Explain;  // <- 문제 지문임 라텍스 변환 필요

        Problem_Answer = _qstCransr;                      // 문제 정답          
        tmWrAnswer = _qstWransr.Split(SEP, System.StringSplitOptions.None);   // 답을 제외한 선택지 받아주는 코드  , 단위로 스플릿해줌 
        for (int i = 0; i < tmWrAnswer.Length; ++i)
            tmWrAnswer[i] = WJAPI2.GetLatexCode(tmWrAnswer[i]);



        int nWrCount = tmWrAnswer.Length;
        //if (nWrCount >= 2)       
            nWrCount = Answer_Count - 1;


        int nAnsrCount = nWrCount + 1;      

        int nAnsridx = UnityEngine.Random.Range(0, nAnsrCount);        
        for (int i = 0, q = 0; i < nAnsrCount; ++i, ++q)
        {
            if (i == nAnsridx)
            {
                Answer_Selection[i] = Problem_Answer;
                Answer_num = i;
                --q;
            }
            else
                Answer_Selection[i] = tmWrAnswer[q];
        }


    }

    public void setAnswer(int num, int selectionnum)
    {
        Debug.Log("#");
        if (Answer_Selection[num-1] != Problem_Answer)
        {
            int n = 0;
            for (int i = 0; i < selectionnum; i++)
            {
                if (Answer_Selection[i] == Problem_Answer)
                {
                    n = i;
                    break;
                }
            }
            string temp = Answer_Selection[num - 1];
            Answer_Selection[num - 1] = Problem_Answer;
            Answer_Selection[n] = temp;
        }
    }
    void Update()
    {
        if (bRequest == true &&
           WJAPI2.CheckState_Request() == 1)
        {
            switch (eState)
            {
                case STATE.DN_SET:
                    {
                        MakeQuestion(WJAPI2.cDiagnotics.data.qstCn, WJAPI2.cDiagnotics.data.qstCransr, WJAPI2.cDiagnotics.data.qstWransr);

                        ++nDigonstic_Idx;

                        eState = STATE.DN_PROG;
                    }
                    break;
                case STATE.DN_PROG:
                    {
                        if (WJAPI2.cDiagnotics.data.prgsCd == "E")
                        {
                         //   SetActive_Question(false);

                            nDigonstic_Idx = 0;

                            eState = STATE.LEARNING;            // ???? ???? ????
                        }
                        else
                        {
                            MakeQuestion(WJAPI2.cDiagnotics.data.qstCn, WJAPI2.cDiagnotics.data.qstCransr, WJAPI2.cDiagnotics.data.qstWransr);

                            ++nDigonstic_Idx;
                        }
                    }
                    break;
                case STATE.LEARNING:
                    {
                        cLearning = WJAPI2.cLearning_Info.data;
                        MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);

                        ++nLearning_Idx;
                    }
                    break;
            }
            bRequest = false;
        }

    }
}
