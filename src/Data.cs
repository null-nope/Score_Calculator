using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.src
{
    internal class Data
    {
        public string[] ITEM =
        {
            "选手",
            "分队",
            "难度",
            "结局",
            "结局得分",
            "临时招募六星",
            "临时招募五星",
            "临时招募四星",
            "击杀鸭/狗/熊",
            "启示",
            "道中加分",
            "紧急作战",
            "紧急作战加分",
            "特殊项",
            "特殊项加分",
            "藏品数",
            "藏品加分",
            "游戏结算得分",
            "总分"
        };
        public struct PlayerRecord
        {
            public string player_name;
            public string team;
            public int difficulty;
            public string ending;
            public int ending_score;
            public int amount_6s;
            public int amount_5s;
            public int amount_4s;
            public int amount_kills;
            public int amount_enlightenment;
            public int on_route_score;
            public string emergency;
            public int emergency_score;
            public string special;
            public int special_score;
            public int amount_collections;
            public int collections_score;
            public int game_score;
            public int total_score;
        };

        private static PlayerRecord buffer;
        public static void SavePlayerRecord(string player_id, string team, Calculate c)
        {
            buffer.player_name = player_id;
            buffer.team = team;
            buffer.difficulty = c.GetDifficulty();
            buffer.ending = c.GetEndings();
            buffer.ending_score = c.GetEndingScore();
            buffer.amount_6s = c.GetTempRecr6S();
            buffer.amount_5s = c.GetTempRecr5S();
            buffer.amount_4s = c.GetTempRecr4S();
            buffer.amount_kills = c.GetSpecialKills();
            buffer.amount_enlightenment = c.GetEnlightenments();
            buffer.on_route_score = c.GetOnRouteScore();
            buffer.emergency = c.GetEmergencyLevel();
            buffer.emergency_score = c.GetEmergencyScore();
            buffer.special = c.GetSpecial();
            buffer.special_score = c.GetSpecialScore();
            buffer.amount_collections = c.GetCollectionAmount();
            buffer.collections_score = c.GetCollectionScore();
            buffer.game_score = c.GetGameScore();
            buffer.total_score = c.GetTotalScore();
        } 
        public static PlayerRecord GetPlayerRecord()
        {
            return buffer;
        }
    }
}
