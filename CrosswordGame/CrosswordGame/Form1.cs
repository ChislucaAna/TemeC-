using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Reflection;
using static CrosswordGame.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CrosswordGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int secondsLeft = 600;
        public class Word
        {
            public int Id;
            public string value;
            public string description;
            public int direction=0; // 1 pt orizontal,-1 pt vertical
            public int startingRow;
            public int startingColumn;
            public Word(int Id,string value, string description)
            {
                this.Id = Id;   
                this.value = value;
                this.description = description;
            }   
        }

        List<Word> words = new List<Word>(); //toate cuvintele din fisier
        List<Word> selectedWords = new List<Word>(); //cele care s-au selectat din fisier
        Queue<Word> WordsAdded = new Queue<Word>();    //cele adaugate
        List<Word> WordsToAdd = new List<Word>();  //cele de adaugat

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button2.Text = "Resume Timer";
            }
            else
            {
                button2.Text = "Pause Timer";
            }
            timer1.Enabled = !timer1.Enabled;
        }

        public void getWords()
        {
            StreamReader reader = new StreamReader("words.txt");
            string line;

            while((line = reader.ReadLine()) != null)
            {
                line = reader.ReadLine();
                string[] fields = line.Split(';');
                words.Add(new Word(words.Count,fields[0], fields[1]));
            }
            for(int i=0; i<5; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0,words.Count);
                selectedWords.Add(new Word(i, words[index].value, words[index].description));
                Thread.Sleep(50);
            }
            reader.Close();
            //daca nu folosesti tolist ai doua variabile care dau point catre acelasi obiect
            //in memorie. Orice modificare asupra uneia se va face si pe a doua
            //daca folosesti to list poti adauga sau sterge independent obiecte din cele doua liste,
            //dar daca modifici o instanta de tip word in una din liste(un field al obiectului word)
            //modificarea va avea loc in ambele liste.
            // unusedWords = selectedWords.Select(w => new Word(w.id, w.value, w.description)).ToList();
            //daca creezi nou obiect ai putea modifica si fielduri
            foreach (Word word in selectedWords)
            {
                listView1.Items.Add((word.Id) + ". "+ word.description);
            }
        }

        public void WriteHorizontally(string s, int startingRow, int startingColumn)
        {
            int coloana = startingColumn;
            foreach (char c in s)
            {
                
                TextBox t = new TextBox();
                t.Text = "";
                t.ReadOnly = false;
                t.Width = 20;
                t.Height = 20;
                t.BackColor = Color.White;
                t.Text = c.ToString();
                if (tableLayoutPanel1.GetControlFromPosition(coloana, startingRow) == null)
                {
                    tableLayoutPanel1.Controls.Add(t, coloana, startingRow);
                }
                coloana++;
            }
        }

        public void WriteVertically(string s, int startingRow, int startingColumn)
        {
            int rand = startingRow;
            foreach (char c in s)
            {
                TextBox t = new TextBox();
                t.Text = "";
                t.ReadOnly = false;
                t.Width = 20;
                t.Height = 20;
                t.BackColor = Color.White;
                t.Text = c.ToString();
                if (tableLayoutPanel1.GetControlFromPosition(startingColumn, rand) == null)
                {
                    tableLayoutPanel1.Controls.Add(t, startingColumn, rand);
                }
                rand++;
            }
        }

        public int CountOccupied(int row,int col,int l, int dir)
        {
            if(dir==1)
            {
                int occupied_spaces = 0; //must be excatly one, the intersection
                for(int c = col; c<=col+l; c++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(c, row) != null)
                    {
                        occupied_spaces++;
                    }
                }
                return occupied_spaces; 
            }
            else //dir==-1
            {
                int occupied_spaces = 0;
                for (int r = row; r <= row + l; r++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(col, r) != null)
                    {
                        occupied_spaces++;
                    }
                }
                return occupied_spaces;
            }
        }

        public void createCrossword()
        {
            WordsAdded = new Queue<Word>();
            WordsToAdd = selectedWords.ToList();

            int nrRanduri = tableLayoutPanel1.RowCount;
            int nrColoane= tableLayoutPanel1.ColumnCount;

            Word firstWord = selectedWords.First(); 
            WriteHorizontally(firstWord.value,nrRanduri/2,nrColoane/2);

            firstWord.direction = 1;
            firstWord.startingRow = nrRanduri / 2;
            firstWord.startingColumn = nrColoane/2;
            WordsAdded.Enqueue(firstWord);
            WordsToAdd.Remove(firstWord);
            Console.WriteLine("Added word: " + firstWord.value);

            while (WordsToAdd.Any())
            {
                bool found_match = false;
                foreach(Word w1 in WordsAdded.ToList())
                {
                    foreach (Word w2 in WordsToAdd.ToList())  
                    {
                        int startingrow = w1.startingRow;
                        int startingcolumn = w1.startingColumn;

                        foreach (char c in w1.value)
                        {
                            if (w1.direction == 1) // horizontal base word
                                startingcolumn++;
                            if (w1.direction == -1) // vertical  base word
                                startingrow++;

                            if (w2.value.Contains(c) && found_match==false)
                            {
                                int diferenceInPlacement = w2.value.IndexOf(c); //cu cat mai la stanga/mai sus trebuie sa inceapa noul cuvant
                                if (w1.direction == -1 && startingcolumn - diferenceInPlacement >=0 
                                    && CountOccupied(startingrow - 1, startingcolumn - diferenceInPlacement,w2.value.Length,1)==1)
                                {
                                    WriteHorizontally(w2.value, startingrow-1, startingcolumn - diferenceInPlacement);
                                    WordsAdded.Enqueue(w2);
                                    WordsToAdd.Remove(w2);

                                    w2.direction = 1;
                                    w2.startingRow = startingrow - diferenceInPlacement;
                                    w2.startingColumn = startingcolumn-1;

                                    found_match = true;

                                    Console.WriteLine("Added word: " + w2.value);
                                }
                                if (w1.direction == 1 && startingrow - diferenceInPlacement >= 0
                                     && CountOccupied(startingrow - diferenceInPlacement, startingcolumn - 1,w2.value.Length,-1)==1)
                                {
                                    WriteVertically(w2.value, startingrow-diferenceInPlacement, startingcolumn-1);

                                    WordsAdded.Enqueue(w2);
                                    WordsToAdd.Remove(w2);

                                    w2.direction = -1;
                                    w2.startingRow = startingrow-1;
                                    w2.startingColumn = startingcolumn - diferenceInPlacement;

                                    found_match = true;
                                    Console.WriteLine("Added word: " + w2.value);
                                }
                            }
                            if (found_match) break;
                        }
                        if (found_match) break;
                    }
                    if (found_match) break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getWords();
            this.Refresh();
            createCrossword();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            txtTimeLeft.Text = (secondsLeft/60).ToString() + " : "+(secondsLeft % 60).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewWord addNewWord = new AddNewWord();
            addNewWord.Show();
            
        }
    }
}
