using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KursForms
{
    public partial class Form1 : Form
    {
        internal const string ProgramName = "Нижний Текст";
        public static string CurFile; // Имя текущего открытого файла
        public static bool isOpened; // Указывает, открыт ли файл или нет
        /// <summary>
        /// Массив пар регулярное выржение-код цвета.
        /// Совпадения красятся в указанный цвет
        /// </summary>
        public static Dictionary<string, int> Palette { get; private set; }
        public Form1(string[] args)
        {
            InitializeComponent();
            isOpened = args.Length > 0;
            CurFile = isOpened ? args[0] : "Безымянный";
            Text = CurFile + " – " + ProgramName;
            Palette = new Dictionary<string, int>
            {
                { @"\bint\b|\bdouble\b|\bfloat\b|\bbool\b|\btrue\b|\bfalse\b", unchecked ((int)0xFF569CD6) },
                { @"\b\d+\.?[fL]?\b", unchecked ((int)0xFFB5CEA8) }
            };
            if(isOpened) rtb.LoadFile(CurFile, RichTextBoxStreamType.UnicodePlainText);
            PaintText();
        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {
            PaintText();
        }
        private void PaintText()
        {
            rtb.SelectAll();
            rtb.SelectionColor = rtb.ForeColor;
            rtb.DeselectAll();
            foreach (KeyValuePair<string, int> pair in Palette)
            {
                MatchCollection matches = Regex.Matches(rtb.Text, pair.Key, RegexOptions.Compiled);
                if (matches.Count > 0)
                {

                    foreach (Match m in matches)
                    {
                        rtb.Select(m.Index, m.Length);
                        rtb.SelectionColor = Color.FromArgb(pair.Value);
                        rtb.DeselectAll();
                    }
                }
            }
            rtb.Select(rtb.Text.Length, 0);
        }
        private void TSMI_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TSMI_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы txt (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CurFile = ofd.FileName;
                isOpened = true;
                Text = CurFile + " – " + ProgramName;
                rtb.LoadFile(CurFile, RichTextBoxStreamType.UnicodePlainText);
            }
        }

        private void TSMI_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы txt (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (isOpened)
            {
                rtb.SaveFile(CurFile, RichTextBoxStreamType.UnicodePlainText);
                return;
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CurFile = sfd.FileName;
                isOpened = true;
                Text = CurFile + " – " + ProgramName;
                rtb.SaveFile(CurFile, RichTextBoxStreamType.UnicodePlainText);
            }
        }
    }
}
