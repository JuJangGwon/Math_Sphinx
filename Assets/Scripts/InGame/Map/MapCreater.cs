using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1 = 땅 , 2 벽, 3 리턴 , 4 표지판 , 5 발판 ,6 nextstage

// 맵 배열 알고리즘 x = i * 3.4f + j * -3.7f,           y = i * 3f + j * 3.1f

/*int[,] map = new int[,] { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                          { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 }

 

 public static int[,] map = new int[,] { { 2 ,2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 2, 2, 2, 2, 1, 1, 2, 1, 2, 2, 2, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 2, 2, 2, 1, 1, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 2, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 2, 2, 2, 1, 2, 1, 2, 2, 2, 2, 1, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 2 },
                                            { 2 ,2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 , 2 }
 
 */



// 기본 

// 1stage 첫 표지판 1 (2, 21) , (12,32), (21, 26)
// + 1, 0 
public class MapCreater : MonoBehaviour
{
    float tileX = 6f;
    float tileY = 4.3f;
    public int stage = 2;
    public FindAnswerWay findanswerway_cs;
    public GameObject[] prefebs;
    public GameObject MapParent;
    public GameObject answerboard_prefeb;
    public int[,] startArea = new int[,]  { { 1,0,0,0,0,0,0,0,0,0,1},
                                            { 1,0,0,0,0,0,0,0,0,0,1},
                                            { 1,0,0,0,0,0,0,0,0,0,1},
                                            { 1,0,0,0,0,0,0,0,0,0,1},
                                            { 1,1,1,1,1,1,1,1,1,1,1}
};
    public int[,] tutorial_map = new int[,] { { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
                                              { 1,1,1,1,1,1,1,1,1,0,0,1,0,1,0,1 },
                                              { 1,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1 },
                                              { 1,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1 },
                                              { 1,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1 },
                                              { 1,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1 },
                                              { 1,0,0,0,0,0,0,1,1,1,1,1,1,1,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                                              { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }

    };

    public static int[,] map = new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,-1, -1, -1,-1,1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,-1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,-1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1 ,0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1 ,0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1},
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1 },
                                            { 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                            { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                                            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                                            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,0, 0, 0, 0, 0, 0, 0, 0, 0, 1,-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
    };
    /*
                                            
                                            
                                          
                                            
                                            
                                           
                                            
                                           
                                            
                                           
                                           
                                           
    };
      */                                         
                                            
    // 16, 10
   // 5,1 | 5,3 | 5,3 | 1, 5 
   // 4,1 | 4,3 | 3,4 | 4, 1
    public void maketile(GameObject gb,int num)
    {
        gb = Instantiate(prefebs[num]);
    }
    void CreateTutorialMap()
    {
       // for (int )
    }
    public void CreateMap()
    {
        int y = 0;
        int x = 0;
        if (InGameManeger.seletedStage == Stage.stage1)
        {
            y = 35;
            x = 36;
        }
        if (InGameManeger.seletedStage == Stage.tutorial)
        {
            y = 16;
            x = 16;
        }
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                int num = 0 ;
                if (InGameManeger.seletedStage == Stage.stage1)
                    num = map[i, j];
                if (InGameManeger.seletedStage == Stage.tutorial)
                    num = tutorial_map[i, j];
                GameObject gb;
                if (num == -1)
                    continue;
                if (num == 3)
                {
                    gb = Instantiate(prefebs[1]);
                    GameObject ngb = Instantiate(answerboard_prefeb);
                    ngb.transform.SetParent(MapParent.transform);
                    ngb.transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
                    ngb.transform.tag = "return";

                }
                else if (num == 5)
                {
                    gb = Instantiate(prefebs[1]);

                }
                else if (num == 6)
                {
                    gb = Instantiate(prefebs[1]);
                    GameObject ngb= Instantiate(answerboard_prefeb);
                    ngb.transform.SetParent(MapParent.transform);
                    ngb.transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
                    ngb.transform.tag = "prog_next_stage";
                }
                else
                {
                    gb = Instantiate(prefebs[num+1]);
                }
                gb.transform.SetParent(MapParent.transform);
                gb.transform.localPosition = new Vector3((i * tileX/2) + (j * -tileX/2), (i * tileY/2) + (j * tileY/2),0 );
                //first(gb, i, j);
            }
        }
      
    }
    public void progstage()
    {
        switch(stage)
        {
            case 2:
                second();
                stage++;
                break;
        }
    }
    void first(GameObject gb, int i, int j)
    {
        
        if (i == 1 && j == 5)
        {
            findanswerway_cs.answerboard[0] = Instantiate(answerboard_prefeb);
            findanswerway_cs.answerboard[0].transform.SetParent(MapParent.transform);
            findanswerway_cs.answerboard[0].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            findanswerway_cs.answerboard[0].transform.tag = "AnswerFootBoard1";
        }
        else if (i == 4 && j == 1)
        {
          //  findanswerway_cs.selection_text[3] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 4 && j == 3)
        {
         //   findanswerway_cs.selection_text[2] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 3 && j == 4)
        {
         //   findanswerway_cs.selection_text[1] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 1 && j == 4)
        {
       //     findanswerway_cs.selection_text[0] = gb.transform.GetChild(0).GetComponent<TextMesh>();
        }
        else if (i == 3 && j == 5)
        {
            findanswerway_cs.answerboard[1] = Instantiate(answerboard_prefeb);
            findanswerway_cs.answerboard[1].transform.SetParent(MapParent.transform);
            findanswerway_cs.answerboard[1].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            findanswerway_cs.answerboard[1].transform.tag = "AnswerFootBoard2";
        }
        else if (i == 5 && j == 3)
        {
            findanswerway_cs.answerboard[2] = Instantiate(answerboard_prefeb);
            findanswerway_cs.answerboard[2].transform.SetParent(MapParent.transform);
            findanswerway_cs.answerboard[2].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            findanswerway_cs.answerboard[2].transform.tag = "AnswerFootBoard3";
        }
        else if (i == 5 && j == 1)
        {
            findanswerway_cs.answerboard[3] = Instantiate(answerboard_prefeb);
            findanswerway_cs.answerboard[3].transform.localPosition = new Vector3((i * 3.4f) + (j * -3.7f), (i * 3f) + (j * 3.1f), 0);
            findanswerway_cs.answerboard[3].transform.tag = "AnswerFootBoard4";
        }
    }
    public void second()
    {
        int[] x = { 15, 15, 13, 11 };
        int[] y = { 1, 3, 5, 5 };
        int[] x2 = { 14, 14, 13, 11 };
        int[] y2 = { 1, 3, 4, 4 };
         // 14, 1 | 14, 3 | 13 , 4| 11, 4

        // 15,1 | 15, 3 | 13, 5,| 11, 5
        for (int i = 0; i < 4; i++)
        {
            GameObject gb = Instantiate(prefebs[4]);
            gb.transform.SetParent(MapParent.transform);
            gb.transform.transform.localPosition = new Vector3((y2[i] * 3.4f) + (x2[i] * -3.7f), (y2[i] * 3f) + (x2[i] * 3.1f), 0);
         //   findanswerway_cs.selection_text[i] = gb.transform.GetChild(0).GetComponent<TextMesh>();
            findanswerway_cs.answerboard[i] = Instantiate(answerboard_prefeb);
            findanswerway_cs.answerboard[i].SetActive(true);
            findanswerway_cs.answerboard[i].transform.SetParent(MapParent.transform);
            findanswerway_cs.answerboard[i].transform.localPosition = new Vector3((y[i] * 3.4f) + (x[i] * -3.7f), (y[i] * 3f) + (x[i] * 3.1f), 0);
        }
        findanswerway_cs.answerboard[0].transform.tag = "AnswerFootBoard1";
        findanswerway_cs.answerboard[1].transform.tag = "AnswerFootBoard2";
        findanswerway_cs.answerboard[2].transform.tag = "AnswerFootBoard3";
        findanswerway_cs.answerboard[3].transform.tag = "AnswerFootBoard3";

        GameObject portal = Instantiate(prefebs[7]);
        portal.transform.SetParent(MapParent.transform);
        portal.transform.transform.localPosition = new Vector3((10 * 3.4f) + (15 * -3.7f), (10 * 3f) + (15 * 3.1f), 0);

    }

}
