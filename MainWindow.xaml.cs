using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator.src;
using static Calculator.src.Calculate;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculate calculate = new Calculate();
        Util util = new Util();

        bool m_has_error = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HighMore_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_HighMore();
            Ending.Content = calculate.DisplayEndings();
        }

        private void Qishi_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_Qishi();
            Ending.Content = calculate.DisplayEndings();
        }

        private void Skadi_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_Skadi();
            Ending.Content = calculate.DisplayEndings();
        }

        private void Mizuki_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_Mizuki();
            Ending.Content = calculate.DisplayEndings();
        }

        private void Xiuchui_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_Xiuchui();
            Ending.Content = calculate.DisplayEndings();
        }

        private void Hanzai_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_Hanzai();
            Ending.Content = calculate.DisplayEndings();
        }

        private void Mubei_Click(object sender, RoutedEventArgs e)
        {
            calculate.HasEnding_Mubei();
            Ending.Content = calculate.DisplayEndings();
        }

        private void TemporaryRecruit_6_Star_Add_Click(object sender, RoutedEventArgs e)
        {
            calculate.TempRecr6ValueAdd();
            Counter_6_Star.Content = calculate.GetTempRecr6S();
        }

        private void TemporaryRecruit_6_Star_Sub_Click(object sender, RoutedEventArgs e)
        {
            calculate.TempRecr6ValueSub();
            Counter_6_Star.Content = calculate.GetTempRecr6S();

        }

        private void TemporaryRecruit_5_Star_Add_Click(object sender, RoutedEventArgs e)
        {
            calculate.TempRecr5ValueAdd();
            Counter_5_Star.Content = calculate.GetTempRecr5S();
        }

        private void TemporaryRecruit_5_Star_Sub_Click(object sender, RoutedEventArgs e)
        {
            calculate.TempRecr5ValueSub();
            Counter_5_Star.Content = calculate.GetTempRecr5S();
        }
        private void TemporaryRecruit_4_Star_Add_Click(object sender, RoutedEventArgs e)
        {
            calculate.TempRecr4ValueAdd();
            Counter_4_Star.Content = calculate.GetTempRecr4S();
        }

        private void TemporaryRecruit_4_Star_Sub_Click(object sender, RoutedEventArgs e)
        {
            calculate.TempRecr4ValueSub();
            Counter_4_Star.Content = calculate.GetTempRecr4S();
        }

        private void ConCeal_Add_Click(object sender, RoutedEventArgs e)
        {
            calculate.SpecialKillValueAdd();
            Counter_Conceal.Content = calculate.GetSpecialKills();

        }

        private void Conceal_Sub_Click(object sender, RoutedEventArgs e)
        {
            calculate.SpecialKillValueSub();
            Counter_Conceal.Content = calculate.GetSpecialKills();
        }

        private void Enlightenment_Add_Click(object sender, RoutedEventArgs e)
        {
            calculate.EnlightenmentsValueAdd();
            Counter_Enlightenment.Content = calculate.GetEnlightenments();
        }

        private void Enlightenment_Sub_Click(object sender, RoutedEventArgs e)
        {
            calculate.EnlightenmentsValueSub();
            Counter_Enlightenment.Content = calculate.GetEnlightenments();
        }

        private void Difficulty_Value_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            util.Window_PreviewKeyDown(sender, e);
        }

        private void Difficulty_Value_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
            if (Difficulty_Value.Text.Equals("0"))
            {
                Difficulty_OutOfValue_Info.Content = "难度值应为数值且在1-15之间";
                Difficulty_Value.Text = "";
            }
            else if (!int.TryParse(Difficulty_Value.Text, out int i))
            {
                calculate.SetDifficultyDefault();
                Difficulty_Value.Text = "";
                m_has_error = true;
            }
            else if (util.IsOutOfValue(int.Parse(Difficulty_Value.Text)) && (!Difficulty_Value.Text.Equals("")))
            {
                calculate.SetDifficultyDefault();
                Difficulty_OutOfValue_Info.Content = "难度值应为数值且在1-15之间";
                Difficulty_Value.Text = "";
                m_has_error = true;
            }
            else
            {
                calculate.SetDifficulty(Difficulty_Value.Text);
                m_has_error = false;
                Difficulty_OutOfValue_Info.Content = "";
            }
        }

        // emergency level
        private string[] BUTTON_CONTENT =
        {
            "铳与秩序",
            "领地意识",
            "狩猎场",
            "失控",
            "育生池",
            "好梦在何方",
            "机械之灾",
            "余烬方阵",
            "水火相容",
            "深度认知"
        };

        private void Chongyuzhixv_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Chongyuzhixv))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Chongyuzhixv));
                Chongyuzhixv_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Chongyuzhixv));
                Chongyuzhixv_Button.Content = BUTTON_CONTENT[0];
            }
        }

        private void LingDiYiShi_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Lingdiyishi))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Lingdiyishi));
                LingDiYiShi_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Lingdiyishi));
                LingDiYiShi_Button.Content = BUTTON_CONTENT[1];
            }
        }

        private void ShouLieChang_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Shouliechang))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Shouliechang));
                ShouLieChang_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shouliechang));
                ShouLieChang_Button.Content = BUTTON_CONTENT[2];
            }
        }

        private void ShiKong_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Shikong))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Shikong));
                ShiKong_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shikong));
                ShiKong_Button.Content = BUTTON_CONTENT[3];
            }
        }

        private void Yushengchi_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Yushengchi))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Yushengchi));
                Yushengchi_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Yushengchi));
                Yushengchi_Button.Content = BUTTON_CONTENT[4];
            }
        }

        private void Haomengzaihefang_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Haomengzaihefang))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Haomengzaihefang));
                Haomengzaihefang_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Haomengzaihefang));
                Haomengzaihefang_Button.Content = BUTTON_CONTENT[5];
            }
        }

        private void JIxiezhizai_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Jixiezhizai))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Jixiezhizai));
                JIxiezhizai_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Jixiezhizai));
                JIxiezhizai_Button.Content = BUTTON_CONTENT[6];
            }
        }

        private void Yujinfangzhen_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Yujinfangzhen))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Yujinfangzhen));
                Yujinfangzhen_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Yujinfangzhen));
                Yujinfangzhen_Button.Content = BUTTON_CONTENT[7];
            }
        }

        private void Shuohuoxiangrong_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Shuihuoxiangrong))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Shuihuoxiangrong));
                Shuohuoxiangrong_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shuihuoxiangrong));
                Shuohuoxiangrong_Button.Content = BUTTON_CONTENT[8];
            }
        }

        private void Shendurenzhi_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasEmergencyLevel(EmergencyLevel.Shendurenzhi))
            {
                EmergencyLevelList.Items.Add(calculate.GetEmergencyLevelName(EmergencyLevel.Shendurenzhi));
                Shendurenzhi_Button.Content += " √";
            }
            else
            {
                EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shendurenzhi));
                Shendurenzhi_Button.Content = BUTTON_CONTENT[9];
            }
        }

        private string[] SPECIAL_NAME =
{
            "真相通关",
            "真相无漏",
            "跳舞通关",
            "跳舞无漏+箱子全收",
            "鸭本运作",
            "监工现场杀鸭"
        };
        private void Zhenxiangtongguan_Button_Click(object sender, RoutedEventArgs e)
        {
            if (calculate.HasSpecialScore(Special.Zhenxiangtongguan))
            {
                SpecialAwardList.Items.Add(calculate.GetSpecialScoreName(Special.Zhenxiangtongguan));
                Zhenxiangtongguan_Button.Content += " √";
            }
            else
            {
                SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Zhenxiangtongguan));
                Zhenxiangtongguan_Button.Content = SPECIAL_NAME[0];
            }            
        }

        private void Zhenxiangwulou_Button_Click(object sender, RoutedEventArgs e)
        {
            if(calculate.HasSpecialScore(Special.Zhenxiangwulou))
            {
                SpecialAwardList.Items.Add(calculate.GetSpecialScoreName(Special.Zhenxiangwulou));
                Zhenxiangwulou_Button.Content += " √";
            }
            else
            {
                SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Zhenxiangwulou));
                Zhenxiangwulou_Button.Content = SPECIAL_NAME[1];
            }
        }

        private void Tiaowutongguan_Button_Click(object sender, RoutedEventArgs e)
        {
            if(calculate.HasSpecialScore(Special.Tiaowutongguan))
            {
                SpecialAwardList.Items.Add(calculate.GetSpecialScoreName(Special.Tiaowutongguan));
                Tiaowutongguan_Button.Content += " √";
            }
            else
            {
                SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Tiaowutongguan));
                Tiaowutongguan_Button.Content = SPECIAL_NAME[2];
            }
        }

        private void Tiaowuwulou_Xiangziquanshou_Button_Click(object sender, RoutedEventArgs e)
        {
            if(calculate.HasSpecialScore(Special.Tiaowuwulou_Xiangziquanshou))
            {
                SpecialAwardList.Items.Add(calculate.GetSpecialScoreName(Special.Tiaowuwulou_Xiangziquanshou));
                Tiaowuwulou_Xiangziquanshou_Button.Content += " √";
            }
            else
            {
                SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Tiaowuwulou_Xiangziquanshou));
                Tiaowuwulou_Xiangziquanshou_Button.Content = SPECIAL_NAME[3];
            }
        }

        private void Yabenyunzuo_Button_Click(object sender, RoutedEventArgs e)
        {
            if(calculate.HasSpecialScore(Special.Yabenyunzuo))
            {
                SpecialAwardList.Items.Add(calculate.GetSpecialScoreName(Special.Yabenyunzuo));
                Yabenyunzuo_Button.Content += " √";
            }
            else
            {
                SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Yabenyunzuo));
                Yabenyunzuo_Button.Content = SPECIAL_NAME[4];
            }
        }

        private void Jiangongxianchangshaya_Button_Click(object sender, RoutedEventArgs e)
        {
            if(calculate.HasSpecialScore(Special.Jiangongxianchangshaya))
            {
                SpecialAwardList.Items.Add(calculate.GetSpecialScoreName(Special.Jiangongxianchangshaya));
                Jiangongxianchangshaya_Button.Content += " √";
            }
            else
            {
                SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Jiangongxianchangshaya));
                Jiangongxianchangshaya_Button.Content = SPECIAL_NAME[5];
            }
        }

        private void Collections_Amount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            util.Window_PreviewKeyDown(sender, e);
        }

        private void Collections_Amount_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Collections_Amount.Text.Equals(""))
            {
                calculate.SetCollectionAmout("0");
            }
            else if (!int.TryParse(Collections_Amount.Text, out int i))
            {
                Collections_Amount.Text = "";
                calculate.SetCollectionAmout("0");
            }
            else if (int.Parse(Collections_Amount.Text) < 0)
            {
                Collections_Amount.Text = "";
                calculate.SetCollectionAmout("0");
            }
            else
                calculate.SetCollectionAmout(Collections_Amount.Text);
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            TotalScore_TextBlock.Text = calculate.GetTotalScore().ToString();
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            calculate.ResetAll();
            PlayerID.Text= "";
            Difficulty_Value.Text = "";
            Difficulty_OutOfValue_Info.Content = "";
            Squad.Text = "";
            Ending.Content = "";
            Counter_6_Star.Content = "0";
            Counter_5_Star.Content = "0";
            Counter_4_Star.Content = "0";
            Counter_Conceal.Content = "0";
            Counter_Enlightenment.Content = "0";
            Jiangongxianchangshaya_Button.Content = SPECIAL_NAME[5];
            Yabenyunzuo_Button.Content = SPECIAL_NAME[4];
            Tiaowuwulou_Xiangziquanshou_Button.Content = SPECIAL_NAME[3];
            Tiaowutongguan_Button.Content = SPECIAL_NAME[2];
            Zhenxiangwulou_Button.Content = SPECIAL_NAME[1];
            Zhenxiangtongguan_Button.Content = SPECIAL_NAME[0];
            Shendurenzhi_Button.Content = BUTTON_CONTENT[9];
            Shuohuoxiangrong_Button.Content = BUTTON_CONTENT[8];
            Yujinfangzhen_Button.Content = BUTTON_CONTENT[7];
            JIxiezhizai_Button.Content = BUTTON_CONTENT[6];
            Haomengzaihefang_Button.Content = BUTTON_CONTENT[5];
            Yushengchi_Button.Content = BUTTON_CONTENT[4];
            ShiKong_Button.Content = BUTTON_CONTENT[3];
            ShouLieChang_Button.Content = BUTTON_CONTENT[2];
            LingDiYiShi_Button.Content = BUTTON_CONTENT[1];
            Chongyuzhixv_Button.Content = BUTTON_CONTENT[0];
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Chongyuzhixv));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Lingdiyishi));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shouliechang));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shikong));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Yushengchi));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Haomengzaihefang));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Jixiezhizai));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Yujinfangzhen));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shuihuoxiangrong));
            EmergencyLevelList.Items.Remove(calculate.GetEmergencyLevelName(EmergencyLevel.Shendurenzhi));
            SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Zhenxiangtongguan));
            SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Zhenxiangwulou));
            SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Tiaowutongguan));
            SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Tiaowuwulou_Xiangziquanshou));
            SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Yabenyunzuo));
            SpecialAwardList.Items.Remove(calculate.GetSpecialScoreName(Special.Jiangongxianchangshaya));
            Collections_Amount.Text = "";
            GameScore_TextBox.Text = "";
            TotalScore_TextBlock.Text = "";
        }
    }
}
