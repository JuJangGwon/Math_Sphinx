using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WJ_Sample : MonoBehaviour
{
    public WJ_Conn scWJ_Conn;
    public GameObject goPopup_Level_Choice;
    public Text txQuestion;
    public Button []btAnsr = new Button[4];
    public Text txState;

    public Button btStart;

    protected Text []txAnsr;


   
    protected enum STATE        //  wjapi ?? ?? enum 
    {
        DN_SET,       // ???? ? ??
        DN_PROG,      // ???? ?? 
        LEARNING,     // ??
    }

    protected STATE eState;         // wjapi ????


    //
    protected bool bRequest;        

    protected int nDigonstic_Idx;  

    protected WJ_Conn.Learning_Data cLearning;
    protected int nLearning_Idx;    
    protected string[] strQstCransr = new string[8];     
    protected long[] nQstDelayTime = new long[8];         




    // Start is called before the first frame update
    void Awake()
    {
        NativeLeakDetection.Mode = NativeLeakDetectionMode.EnabledWithStackTrace;

        eState = STATE.LEARNING;
        goPopup_Level_Choice.active = false;

        cLearning = null;
        nLearning_Idx = 0;


        txAnsr = new Text[btAnsr.Length];
        for (int i = 0; i < btAnsr.Length; ++i)
            txAnsr[i] = btAnsr[i].GetComponentInChildren<Text>();

        SetActive_Question(false);
        btStart.gameObject.active = true;

        bRequest = false;
    }



    // ???? ???? ???? ?????? ????
    public void OnClick_MakeQuestion()
    {        
        switch (eState)
        {
            case STATE.DN_SET: DoDN_Start(); break;
            //???? ????.
            case STATE.LEARNING: DoLearning(); break;
        }        
    }




    // ???? ???? ???? ???????? ???????? ?????? ???? ?????? ?????? ????
    public void OnClick_Level(int _nLevel)
    {
        nDigonstic_Idx = 0;
        SetActive_Question(true);
        btStart.gameObject.active = false;

        // ???? ????
        scWJ_Conn.OnRequest_DN_Setting(_nLevel);

        // ???? ???? ???? ????
        goPopup_Level_Choice.active = false;

        bRequest = true;
    }


    // ???? ????
    public void OnClick_Ansr(int _nIndex)
    {
        print(eState);
        switch (eState)
        {
            case STATE.DN_SET:
            case STATE.DN_PROG:
                {
                    // ???????? ????
                    DoDN_Prog(txAnsr[_nIndex].text);
                }
                break;
            case STATE.LEARNING:
                {
                    strQstCransr[nLearning_Idx - 1] = txAnsr[_nIndex].text;
                    nQstDelayTime[nLearning_Idx - 1] = 5000;        // ??????
                    DoLearning();
                }
                break;
        }
    }





    protected void DoDN_Start()
    {
        goPopup_Level_Choice.active = true;
    }


    protected void DoDN_Prog(string _qstCransr)
    {
        string strYN = "N";
        if (scWJ_Conn.cDiagnotics.data.qstCransr.CompareTo(_qstCransr) == 0)
            strYN = "Y";

        scWJ_Conn.OnRequest_DN_Progress("W",
                                         scWJ_Conn.cDiagnotics.data.qstCd,          // ???? ????
                                         _qstCransr,                                // ?????? ?????? -> ???????? ?????? ???? ?????? ????
                                         strYN,                                     // ????????("Y"/"N")
                                         scWJ_Conn.cDiagnotics.data.sid,            // ???? SID
                                         5000);                                     // ?????? - ???? ?????? ?????? ????

        bRequest = true;
    }


    protected void DoLearning()
    {
        if (cLearning == null)
        {
            print("a");
            nLearning_Idx = 0;
            SetActive_Question(true);
            btStart.gameObject.active = false;

            scWJ_Conn.OnRequest_Learning();
            bRequest = true;
        }
        else
        {            
            if (nLearning_Idx >= scWJ_Conn.cLearning_Info.data.qsts.Count)
            {
                txState.text = "9999 : 9999 9999";
                scWJ_Conn.OnLearningResult(cLearning, strQstCransr, nQstDelayTime);      // ???? ???? ????
                cLearning = null;

                SetActive_Question(false);
                btStart.gameObject.active = true;
                return;
            }

            MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);

            txState.text = "???? : ???? ???? " + (nLearning_Idx + 1).ToString();


            ++nLearning_Idx;

            bRequest = false;
        }
    }





    protected void MakeQuestion(string _qstCn, string _qstCransr, string _qstWransr)
    {
        print("MakeQuestion");
        char[] SEP = { ',' };
        string[] tmWrAnswer;
        
        txQuestion.text = scWJ_Conn.GetLatexCode(_qstCn);// ???? ????

        string strAnswer = _qstCransr;  // ???? ?????? ???????? ??????                
         tmWrAnswer = _qstWransr.Split(SEP, System.StringSplitOptions.None);   // ???? ??????
         for(int i = 0; i < tmWrAnswer.Length; ++i)
             tmWrAnswer[i] = scWJ_Conn.GetLatexCode(tmWrAnswer[i]);

        int nWrCount = 3;
        if (nWrCount >= 4)       // 5???????? ?????? ?????? 4???????? ??????
            nWrCount = 3;


        int nAnsrCount = nWrCount + 1;       // ???? ????
       /* for (int i = 0; i < btAnsr.Length; ++i)
        {
            if (i < nAnsrCount)
                btAnsr[i].gameObject.active = true;
            else
                btAnsr[i].gameObject.active = false;
        }

        */
        // ???? ???????? ?????? ????.
        int nAnsridx = UnityEngine.Random.Range(0, nAnsrCount);        
        for (int i = 0, q = 0; i < nAnsrCount; ++i, ++q)
        {
            if (i == nAnsridx)
            {
                txAnsr[i].text = strAnswer;
                --q;
            }
            else
                txAnsr[i].text = i.ToString();
        }


    }




    protected void SetActive_Question(bool _bActive)
    {
        txQuestion.text = "";
        for (int i = 0; i < btAnsr.Length; ++i)
            btAnsr[i].gameObject.active = _bActive;
    }


    // Update is called once per frame
    void Update()
    {
        if(bRequest == true && 
           scWJ_Conn.CheckState_Request() == 1)
        {
            switch(eState)
            {
                case STATE.DN_SET:
                    {
                        MakeQuestion(scWJ_Conn.cDiagnotics.data.qstCn, scWJ_Conn.cDiagnotics.data.qstCransr, scWJ_Conn.cDiagnotics.data.qstWransr);

                        txState.text = "1 : 1234 " + (nDigonstic_Idx + 1).ToString();
                        ++nDigonstic_Idx;

                        eState = STATE.DN_PROG;
                    }
                    break;
                case STATE.DN_PROG:
                    {
                        if (scWJ_Conn.cDiagnotics.data.prgsCd == "E")
                        {
                            SetActive_Question(false);

                            nDigonstic_Idx = 0;
                            txState.text = "???? : ???????? ????";
                            btStart.gameObject.active = true;
                            
                            eState = STATE.LEARNING;            // ???? ???? ????
                        }
                        else
                        {
                            MakeQuestion(scWJ_Conn.cDiagnotics.data.qstCn, scWJ_Conn.cDiagnotics.data.qstCransr, scWJ_Conn.cDiagnotics.data.qstWransr);

                            txState.text = "???? : ???????? " + (nDigonstic_Idx + 1).ToString();
                            ++nDigonstic_Idx;
                        }
                    }
                    break;
                case STATE.LEARNING:
                    {
                        print("B");
                        cLearning = scWJ_Conn.cLearning_Info.data;
                        MakeQuestion(cLearning.qsts[nLearning_Idx].qstCn, cLearning.qsts[nLearning_Idx].qstCransr, cLearning.qsts[nLearning_Idx].qstWransr);
                        txState.text = "???? : ???? ???? " + (nLearning_Idx + 1).ToString();

                        ++nLearning_Idx;                        
                    }
                    break;
            }
            bRequest = false;
        }
        
    }
}
