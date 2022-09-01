using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CamelQuestion : MonoBehaviour
{
    // 우리가 필요한거 
    public string Problem_Answer;          // 문제가 생성된후 api로 부터 알아온 정답
    public string[] Answer_Selection;      // 4지선다 문제 정답 선택지
    public int Answer_num;                 // 위 4개 배열중 어느번째 선택지가 정답인.

    public WJ_Conn scWJ_Conn;
    public TextMeshProUGUI txQuestion;

    public TextMeshProUGUI[] txAnsr;


    public enum STATE
    {
        DN_SET,
        DN_PROG,
        LEARNING,
    }

    public STATE eState;
    protected bool bRequest;

    protected int nDigonstic_Idx;

    protected WJ_Conn.Learning_Data cLearning;
    protected int nLearning_Idx;
    protected string[] strQstCransr = new string[8];
    protected long[] nQstDelayTime = new long[8];


    void Awake()
    {
        eState = STATE.LEARNING;              // 진단 단계 설정하는 곳 

        cLearning = null;
        nLearning_Idx = 0;
        bRequest = false;
        scWJ_Conn.OnRequest_DN_Setting(0);              // 0 레벨 문제로 시작 

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
        scWJ_Conn.OnRequest_DN_Setting(0);
        bRequest = true;
    }


    protected void DoDN_Prog(string _qstCransr)
    {
        string strYN = "N";
        if (scWJ_Conn.cDiagnotics.data.qstCransr.CompareTo(_qstCransr) == 0)
            strYN = "Y";

        scWJ_Conn.OnRequest_DN_Progress("W",
                                         scWJ_Conn.cDiagnotics.data.qstCd,          // 문제 코드
                                         _qstCransr,                                // 선택한 답내용 -> 사용자가 선택한 문항 데이터 입력
                                         strYN,                                     // 정답여부("Y"/"N")
                                         scWJ_Conn.cDiagnotics.data.sid,            // 문제 SID
                                         5000);                                     // 임시값 - 문제 풀이에 소요된 시간

        bRequest = true;
    }


    protected void DoLearning()
    {
        if (cLearning == null)
        {
            nLearning_Idx = 0;

            scWJ_Conn.OnRequest_Learning();

            bRequest = true;
        }
        else
        {
            if (nLearning_Idx >= scWJ_Conn.cLearning_Info.data.qsts.Count)
            {
                scWJ_Conn.OnLearningResult(cLearning, strQstCransr, nQstDelayTime);      // 학습 결과 처리
                cLearning = null;

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

        txQuestion.text = scWJ_Conn.GetLatexCode(_qstCn);  // <- 문제 지문임 라텍스 변환 필요

        Problem_Answer = _qstCransr;                      // 문제 정답          
        tmWrAnswer = _qstWransr.Split(SEP, System.StringSplitOptions.None);   // 답을 제외한 선택지 받아주는 코드  , 단위로 스플릿해줌 
        for (int i = 0; i < tmWrAnswer.Length; ++i)
            tmWrAnswer[i] = scWJ_Conn.GetLatexCode(tmWrAnswer[i]);



        int nWrCount = tmWrAnswer.Length;
        //if (nWrCount >= 2)       // 5지선다형 이상은 강제로 4지선다로 변경함
        nWrCount = 1;


        int nAnsrCount = nWrCount + 1;      // 보기 갯수

        // 보기 리스트에 정답을 넣음.
        int nAnsridx = UnityEngine.Random.Range(0, nAnsrCount);        // 정답 인덱스! 랜덤으로 배치
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


    void Update()
    {
        if (bRequest == true &&
           scWJ_Conn.CheckState_Request() == 1)
        {
            switch (eState)
            {
                case STATE.DN_SET:
                    {
                        MakeQuestion(scWJ_Conn.cDiagnotics.data.qstCn, scWJ_Conn.cDiagnotics.data.qstCransr, scWJ_Conn.cDiagnotics.data.qstWransr);

                        ++nDigonstic_Idx;

                        eState = STATE.DN_PROG;
                    }
                    break;
                case STATE.DN_PROG:
                    {
                        if (scWJ_Conn.cDiagnotics.data.prgsCd == "E")
                        {
                            //   SetActive_Question(false);

                            nDigonstic_Idx = 0;

                            eState = STATE.LEARNING;            // 진단 학습 완료
                        }
                        else
                        {
                            MakeQuestion(scWJ_Conn.cDiagnotics.data.qstCn, scWJ_Conn.cDiagnotics.data.qstCransr, scWJ_Conn.cDiagnotics.data.qstWransr);

                            ++nDigonstic_Idx;
                        }
                    }
                    break;
                case STATE.LEARNING:
                    {
                        cLearning = scWJ_Conn.cLearning_Info.data;
                        MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);

                        ++nLearning_Idx;
                    }
                    break;
            }
            bRequest = false;
        }

    }
}
