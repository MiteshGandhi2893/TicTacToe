using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TICTACTO
{
    public partial class TicTacToe : Form
    {
        int score1 = 0,score2=0;
        string sname="";
        string p1 = "";
        string p2 = "";
        public TicTacToe()
        {
            InitializeComponent();
            buttarray=new Button[9]{button1,button2,button3,button4,button5,button6,button7,button8,button9};
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        bool _isGameOver=false, _isX=true;
        string symbol="";
        int a = 0;
        int b = 0;
        private void ClickHandler(object sender, System.EventArgs e)
        {
            
            Button tempButton = (Button)sender;

            if (this._isGameOver)
            {
                MessageBox.Show("Game Over...Select Play for a new game!",
                                "ERROR", MessageBoxButtons.OK);
                return;
            }

            if (tempButton.Text != "")    // if not empty..already has X or O
            {
                //MessageBox.Show("Button already has value!", "ERROR", MessageBoxButtons.OK);
                return;
            }

            if (_isX)    // Alternate putting the X or O character in the Text property
                tempButton.Text = label2.Text;
            else
                tempButton.Text = label4.Text;

            _isX = !_isX;    // 
            
          
         TicTacToe.CheckAndProcessWinner(buttarray,out this._isGameOver,out symbol);
       //  MessageBox.Show(symbol+"    "+a+"    "+b);
         if (_isGameOver)
         {
           
             sname = symbol;
             
          
             
     
             if (sname == label2.Text)
             {
               
                 textBox3.Text = "" + (Convert.ToInt16(textBox3.Text)+1);
                 MessageBox.Show(textBox1.Text + "  " + "wins");
             }
             else
             {

                 textBox4.Text = "" + (Convert.ToInt16(textBox4.Text) + 1);
                 MessageBox.Show(textBox2.Text + "  " + "wins");
             }
         }
         _isGameOver = false;
       //  _isX = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.SelectedItem.ToString();
            if (label2.Text == "X")
            {
                label4.Text = "0";
                comboBox2.Text = label4.Text;
            }
            else
            {
                label4.Text = "X";
                comboBox2.Text = label4.Text;
            }
            p1 = label2.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = comboBox2.SelectedItem.ToString();
            if (label4.Text == "X")
            {
                label2.Text = "0";
                comboBox1.Text = label2.Text;

            }
            else
            {
                label2.Text = "X";
                        comboBox1.Text = label2.Text;
            }
            p2 = label4.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" && textBox2.Text == "") || (textBox1.Text == "" || textBox2.Text == ""))
            {
                MessageBox.Show("plz fill all the textbox");
            }
            else if (comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("plz select your letter");
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Visible = true;
                textBox4.Visible = true;
               comboBox1.Enabled = false;
               textBox3.Text = "0";
               textBox4.Text = "0";
           comboBox2.Enabled = false;
                label5.Text = textBox1.Text;
                label6.Text = textBox2.Text;
                for (int i = 0; i < 9; i++)
                {
                    this.buttarray[i].Click += new System.EventHandler(this.ClickHandler);
                   
                }
               
            }
            button10.Visible = false;

        }
        static public void CheckAndProcessWinner(Button[] myControls,out bool gameOver,out string symbol)
        {
           
            gameOver = false;
            symbol = "";
           
            for (int i = 0; i < 8; i++)
            {
                int a = Winners[i, 0], b = Winners[i, 1], c = Winners[i, 2];
                Button b1 = myControls[a], b2 = myControls[b], b3 = myControls[c];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "") // if one if blank
                    continue;    // try another -- no need to go further

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackColor = b2.BackColor = b3.BackColor = Color.LightCoral;
                    b1.Font = b2.Font = b3.Font
                         = new System.Drawing.Font("Microsoft Sans Serif", 32F,
                                                   System.Drawing.FontStyle.Italic &
                                                   System.Drawing.FontStyle.Bold,
                                                   System.Drawing.GraphicsUnit.Point,
                                                   ((System.Byte)(0)));
                     TicTacToe f1=new TicTacToe();
                   
                    symbol = b1.Text;
                    gameOver = true;
                   
                    break;
                    
                }
            }
           
        }
        static private int[,] Winners = new int[,]
   {
    {0,1,2},
    {3,4,5},
    {6,7,8},
    {0,3,6},
    {1,4,7},
    {2,5,8},
    {0,4,8},
    {2,4,6}
   };
        Button[] buttarray;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
           
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < 9; i++)
            {
                buttarray[i].Text = "";

                buttarray[i].BackColor = Color.White;
                buttarray[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 32F,
                                                   System.Drawing.FontStyle.Italic &
                                                   System.Drawing.FontStyle.Bold,
                                                   System.Drawing.GraphicsUnit.Point,
                                                   ((System.Byte)(0)));
            }
            for (int i = 0; i < 9; i++)
            {
                this.buttarray[i].Click += new System.EventHandler(this.ClickHandler);

            }
        }

      
    }
}
