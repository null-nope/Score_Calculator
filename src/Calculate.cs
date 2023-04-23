﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculator.src
{
    public class Calculate
    {
        private string[] m_endings_text = { "海沫", "骑士", "蒂蒂", "水月", "锈锤", "寒灾", "墓碑" };
        private int[] ending_scores = { 0, 300, 160, 300, 160, 160, 160 };
        private string[] m_emergency_level =
        {       
                "铳与秩序 60",
                "领地意识 80",
                "狩猎场 50",
                "失控 150",
                "育生池 90",
                "好梦在何方 90",
                "机械之灾 50",
                "余烬方阵 120",
                "水火相容 150",
                "深度认知 150"
        };
        public enum EmergencyLevel
        {
            Chongyuzhixv = 0,
            Lingdiyishi = 1,
            Shouliechang = 2,
            Shikong = 3,
            Yushengchi = 4,
            Haomengzaihefang = 5,
            Jixiezhizai = 6,
            Yujinfangzhen = 7,
            Shuihuoxiangrong = 8,
            Shendurenzhi = 9
        }
        private int[] m_emergency_scores =
        {
                60,
                80,
                50,
                150,
                90,
                90,
                50,
                120,
                150,
                150
        };
        private string[] m_special_text =
        {
            "真相通关 50",
            "真相无漏 100",
            "跳舞通关 50",
            "跳舞无漏+箱子全收 100",
            "鸭本运作 80",
            "监工现场杀鸭 30"
        };
        public enum Special
        {
            Zhenxiangtongguan = 0,
            Zhenxiangwulou = 1,
            Tiaowutongguan = 2,
            Tiaowuwulou_Xiangziquanshou = 3,
            Yabenyunzuo = 4,
            Jiangongxianchangshaya = 5
        }
        private int[] m_special_scores =
        {
            50,
            100,
            50,
            100,
            80,
            30
        };

        //scores
        private int m_total_score;
        private int m_ending_score;
        private int m_on_route_awards;
        private int m_emergency_score;
        private int m_special_score;
        //difficulty
        private int m_difficulty;
        //endings
        private string m_endings_dis;
        private bool[] m_ending_state;
        //on route
        private int m_tempRecr_6s;
        private int m_tempRecr_5s;
        private int m_tempRecr_4s;
        private int m_special_kills;
        private int m_enlightenments;
        //emergency
        private bool[] m_emergency_state;
        //special
        private bool[] m_special_state;
        //collection
        private int m_collections;

        private bool m_difficulty_err;
        private bool m_collection_err;





        public Calculate()
        {
            Init_TotalScore();
            Init_Difficulty();
            Init_EndingsDis();
            Init_EndingState();
            Init_OnRouteAwards();
            Init_EmergencyState();
            Init_SpecialState();
            Init_Collection();
            ResetErrStates();
        }

        ~Calculate()
        {

        }

        // Private Methods
        private void Init_TotalScore()
        {
            m_total_score = 0;
        }

        private void Init_EndingsDis()
        {
            m_endings_dis = "";
        }

        private void Init_Difficulty()
        {
            m_difficulty = 10;
        }

        private void Init_EndingState()
        {
            m_ending_state = new bool[7];
            for (int i = 0; i < 7; i++)
                m_ending_state[i] = false;
        }

        private void Init_OnRouteAwards()
        {
            m_on_route_awards = 0;
            m_tempRecr_6s = 0;
            m_tempRecr_5s = 0;
            m_tempRecr_4s = 0;
            m_special_kills = 0;
            m_enlightenments = 0;
        }

        private void Init_EmergencyState()
        {
            m_emergency_state = new bool[m_emergency_level.Length];
            for (int i = 0; i < m_emergency_level.Length; i++)
                m_emergency_state[i] = false;
        }

        private void Init_SpecialState()
        {
            m_special_state = new bool[m_special_text.Length];
            for (int i = 0; i < m_special_text.Length; i++)
                m_special_state[i] = false;
        }

        private void Init_Collection()
        {
            m_collections = 0;
        }

        private int String2Int(string s, int type)
        {
            if (!s.Equals(""))
            {
                int i = 0;
                if (int.TryParse(s, out i))
                {
                    if (type == 0)
                        m_difficulty_err = false;
                    else if (type == 1)
                        m_collection_err = false;
                }
                else
                {
                    if (type == 0)
                        m_difficulty_err = true;
                    else if (type == 1)
                        m_collection_err = true;
                }
                if (s.Length > 0)
                    return int.Parse(s);
                else
                    return 0;
            }
            else
                return 0;
        }

        private double GetCoefOfDifficulty()
        {
            return m_difficulty / 10.0;
        }

        private int GetEndingScore()
        {
            m_ending_score = 0;
            for (int i = 0; i < 7; i++)
            {
                if (m_ending_state[i])
                    m_ending_score += ending_scores[i];
            }
            return m_ending_score;
        }

        private int GetOnRouteAwards()
        {
            m_on_route_awards = 0;
            m_on_route_awards += m_tempRecr_6s * 50;
            m_on_route_awards += m_tempRecr_5s * 20;
            m_on_route_awards += m_tempRecr_4s * 10;
            m_on_route_awards += m_special_kills * 20;
            m_on_route_awards += m_enlightenments * 0;
            return m_on_route_awards;
        }

        private int GetEmergencyScore()
        {
            m_emergency_score = 0;
            for (int i = 0; i < m_emergency_state.Length; i++)
            {
                if (m_emergency_state[i])
                    m_emergency_score += m_emergency_scores[i];
            }
            return m_emergency_score;
        }

        private int GetSpecialScore()
        {
            m_special_score = 0;
            for (int i = 0; i < m_special_state.Length; i++)
            {
                if (m_special_state[i])
                    m_special_score += m_special_scores[i];
            }
            return m_special_score;
        }

        private int GetCollectionScore()
        {
            return m_collections * 10;
        }

        private void CalculateTotalScore()
        {
            int total_score = 0;
            total_score += GetEndingScore();
            total_score += GetOnRouteAwards();
            total_score += GetEmergencyScore();
            total_score += GetSpecialScore();
            total_score += GetCollectionScore();
            total_score = (int)(total_score * GetCoefOfDifficulty());
            m_total_score = total_score;
        }

        private void RefreshEndingsDisplay()
        {
            m_endings_dis = "";
            for (int i = 0; i < 7; i++)
            {
                if (m_ending_state[i])
                    m_endings_dis += m_endings_text[i] + " ";
            }
        }

        // Public Methods
        public void SetDifficulty(string s)
        {
            m_difficulty = String2Int(s, 0);
            if (m_difficulty == 0)
                m_difficulty = 10;
        }
        public int GetDifficulty()
        {
            return m_difficulty;
        }
        public string DisplayEndings()
        {
            return m_endings_dis;
        }

        public void HasEnding_HighMore()
        {
            if (!m_ending_state[0])
                m_ending_state[0] = true;
            else
                m_ending_state[0] = false;
            RefreshEndingsDisplay();
        }
        public void HasEnding_Qishi()
        {
            if (!m_ending_state[1])
                m_ending_state[1] = true;
            else
                m_ending_state[1] = false;
            RefreshEndingsDisplay();
        }
        public void HasEnding_Skadi()
        {
            if (!m_ending_state[2])
                m_ending_state[2] = true;
            else
                m_ending_state[2] = false;
            RefreshEndingsDisplay();
        }
        public void HasEnding_Mizuki()
        {
            if (!m_ending_state[3])
                m_ending_state[3] = true;
            else
                m_ending_state[3] = false;
            RefreshEndingsDisplay();
        }
        public void HasEnding_Xiuchui()
        {
            if (!m_ending_state[4])
                m_ending_state[4] = true;
            else
                m_ending_state[4] = false;
            RefreshEndingsDisplay();
        }
        public void HasEnding_Hanzai()
        {
            if (!m_ending_state[5])
                m_ending_state[5] = true;
            else
                m_ending_state[5] = false;
            RefreshEndingsDisplay();
        }
        public void HasEnding_Mubei()
        {
            if (!m_ending_state[6])
                m_ending_state[6] = true;
            else
                m_ending_state[6] = false;
            RefreshEndingsDisplay();
        }

        public void TempRecr6ValueAdd()
        {
            m_tempRecr_6s++;
        }

        public void TempRecr5ValueAdd()
        {
            m_tempRecr_5s++;
        }

        public void TempRecr4ValueAdd()
        {
            m_tempRecr_4s++;
        }

        public void TempRecr6ValueSub()
        {
            if (m_tempRecr_6s > 0)
                m_tempRecr_6s--;
        }
        public void TempRecr5ValueSub()
        {
            if (m_tempRecr_5s > 0)
                m_tempRecr_5s--;
        }

        public void TempRecr4ValueSub()
        {
            if (m_tempRecr_4s > 0)
                m_tempRecr_4s--;
        }

        public void SpecialKillValueAdd()
        {
            m_special_kills++;
        }

        public void SpecialKillValueSub()
        {
            if (m_special_kills > 0)
                m_special_kills--;
        }

        public void EnlightenmentsValueAdd()
        {
            m_enlightenments++;
        }

        public void EnlightenmentsValueSub()
        {
            if (m_enlightenments > 0)
                m_enlightenments--;
        }

        public int GetTempRecr6S()
        {
            return m_tempRecr_6s;
        }
        public int GetTempRecr5S()
        {
            return m_tempRecr_5s;
        }

        public int GetTempRecr4S()
        {
            return m_tempRecr_4s;
        }

        public int GetSpecialKills()
        {
            return m_special_kills;
        }

        public int GetEnlightenments()
        {
            return m_enlightenments;
        }

        public string GetEmergencyLevelName(EmergencyLevel name)
        {
            int index = (int)name;
            return m_emergency_level[index];
        }

        public bool HasEmergencyLevel(EmergencyLevel name)
        {
            int index = (int)name;
            SetLevelState(index);
            return m_emergency_state[index];
        }

        public void SetLevelState(int index)
        {
            m_emergency_state[index] = !m_emergency_state[index];
        }

        public bool HasSpecialScore(Special name)
        {
            int index = (int)name;
            SetSpecialState(index);
            return m_special_state[index];
        }

        public void SetSpecialState(int index)
        {
            m_special_state[index] = !m_special_state[index];
        }

        public string GetSpecialScoreName(Special name)
        {
            int index = (int)name;
            return m_special_text[index];
        }

        public void SetCollectionAmout(string s)
        {
            m_collections = String2Int(s, 1);
        }

        public int GetCollectionAmout()
        {
            return m_collections;
        }

        public bool GetDiffcultyErrState()
        {
            return m_difficulty_err;
        }

        public bool GetCollectionErrState()
        {
            return m_collection_err;
        }

        public void ResetErrStates()
        {
            m_difficulty_err = false;
            m_collection_err = false;
        }

        public void ResetAll()
        {
            Init_TotalScore();
            Init_Difficulty();
            Init_EndingsDis();
            Init_EndingState();
            Init_OnRouteAwards();
            Init_EmergencyState();
            Init_SpecialState();
            Init_Collection();
            ResetErrStates();
        }

        public int GetTotalScore()
        {
            CalculateTotalScore();
            return m_total_score;
        }

    }
}
