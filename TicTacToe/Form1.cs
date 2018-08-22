using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private int _player = 2; // even = X turn, odd = O turn; 
        private int _clickNumber; //to numer gry byl, prawda?
        private int s1; //co to za zmienne? sprobuj je nazwac tak, zeby mi bylo latwo zrozumiec za co odpowiadaja
        private int s2;
        private int sd;  // count _clickNumber;
        private const string _x = "X";
        private const string _o = "O";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (button.Text != string.Empty)
                return;

            button.Text = _player % 2 == 0 ? _x : _o;

            _player++;
            _clickNumber++;

            if (CheckDraws())
            {
                MessageBox.Show("Tie Game!!");
                sd++;
                NewGame();
            }

            if (!CheckWinner())
                return;

            if(button.Text == _x)
            {
                MessageBox.Show(_x + " Won!!");
                s1++;
                NewGame();
            }
            else
            {
                MessageBox.Show(_o + " Won!!");
                s2++;
                NewGame();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Results();
        }

        private void EButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Results()
        {
            XWin.Text = _x + ": " + s1;
            OWin.Text = _o + ": " + s2;
            Draws.Text = "Draws: " + sd;
        }

        private void NewGame()
        {
            _player = 2;
            _clickNumber = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = string.Empty;
            Results();
        }
        private void NGButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private bool CheckDraws()
        {
            return _clickNumber == 9 && !CheckWinner();
        }

        bool CheckWinner()
        {
            //horizontal checks
            if (A00.Text == A01.Text && A01.Text == A02.Text && A00.Text != string.Empty)
                return true;
            if (A10.Text == A11.Text && A11.Text == A12.Text && A10.Text != string.Empty)
                return true;
            if (A20.Text == A21.Text && A21.Text == A22.Text && A20.Text != string.Empty)
                return true;
            
            //vertical checks
            if (A00.Text == A10.Text && A10.Text == A20.Text && A00.Text != string.Empty)
                return true;
            if (A01.Text == A11.Text && A11.Text == A21.Text && A01.Text != string.Empty)
                return true;
            if (A02.Text == A12.Text && A12.Text == A22.Text && A02.Text != string.Empty)
                return true;
            
            // diagonal checks
            if (A00.Text == A11.Text && A11.Text == A22.Text && A00.Text != string.Empty)
                return true;
            if (A20.Text == A11.Text && A11.Text == A02.Text && A20.Text != string.Empty)
                return true;

            return false;
        }

        private void RButton_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            NewGame();
        }
    }
}
