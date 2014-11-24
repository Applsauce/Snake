using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

// Ett skamlöst (försök) till kopia av det klassiska snakespelet av Fredrik Österberg. 
// Börjad 2014-11-10 på polhemskolan.
// Funktionallitet 2014-11-18, ska implementera highscore ---23:336 Gjort med värdelistad
// 15:15 2014-11-19,  
// Fixade bugegn när bäret spawnar i ormen, tog bort Bärfinns krav på ifsats
// Lade till funktionalitet för sparning av highscore samt fixade bugg med dupliketter av highscorevärde.
// Bytte bolleaner för riktning till int
// Fixa buggen när ormen kan gå bakåt (in i svansen) vid snabba tagenttryckningar (se AG 2), använde boolean
// för att kolla så ormen rör sig imellan var rörelsrikntings änrding.
// 2014-11-21 11:30 Lade till WASDA funktionalitet
// 2014-11-24 Lade till ändringsbar hastighet och poäng, lade till musik(val).
//
// ATT GÖRA: 
// 3. Lägg till initialer (eller namn) för indentifikation i highscore.
// 5. Lägg istälnningsbar svårighetsgrad (ändrar timerupdateringen).
namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Rektangel> snake = new List<Rektangel>();
        private List<int> Highscore = new List<int>();
        Rektangel bär;
        Random generator = new Random();
        private int offset = 15;      // Förflyttning i pixlar.
        int bärX;                     // Bärets position
        int bärY;
        int max_tile_w;
        int max_tile_h;
        int score = 0;
        bool bärFinns = false;
        bool pausat = false;
        bool knapptryckning = false;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Snake_Highscore.txt"); // Placering av highscore-filen. Kan behövas adminrättigheter

        public Form1()
        {
            InitializeComponent();
            StartGame();

            this.KeyPreview = true; // Ser till att programmet läser in tagentknapper
        }                           // innan det reagerar på dom. Vet inte om behövs??

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for ( int i = 0; i < snake.Count; i++)
            {
                Rektangel rektangel = snake.ElementAt(i);
                rektangel.Rita(g);
            }

            //if (!bärFinns) // Skapar nytt bär
            //{
            //Generera: // Skapar koordniaterna för bäret
            //    bärX = generator.Next(0, this.Width  - 2 * offset);
            //    bärY = generator.Next(0, this.Height - 2 * offset);

            //    // Kollar ifall bärets position överlappar ormens
            //    Rektangel rektangel = snake.ElementAt(0);
            //    if (rektangel.ÄrTräffad(bärX, bärY, bärX + offset, bärY + offset)) goto Generera;

            //    // Skapar bäret
            //    bär = new Rektangel(bärX, bärY, offset, offset, Color.Red);
            //    bärFinns = true;
            //}
            if (bärFinns) bär.Rita(g); // Ritar bär

            // Förhindrar blinkning av OnPaint
            this.DoubleBuffered = true;
            
        }

        // Kollar vilken av tagentpilarna som tryckts ner senast.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (( e.KeyCode == Keys.Up || e.KeyCode == Keys.W ) && !snake[0].R.Equals(3) && !knapptryckning)
            {
                snake[0].R = 1;        // För uppåt pilen, Pil upp och W
                knapptryckning = true;
            }
            else if (( e.KeyCode == Keys.Right || e.KeyCode == Keys.D ) && !snake[0].R.Equals(4) && !knapptryckning)
            {
                snake[0].R = 2;        // För höger pilen, Pil höger och D
                knapptryckning = true;
            }

            else if (( e.KeyCode == Keys.Down || e.KeyCode == Keys.S ) && !snake[0].R.Equals(1) && !knapptryckning)
            {
                snake[0].R = 3;        // För neråt pilen, Pil ner och S
                knapptryckning = true;
            }
            else if (( e.KeyCode == Keys.Left || e.KeyCode == Keys.A ) && !snake[0].R.Equals(2) && !knapptryckning)
            {
                snake[0].R = 4;        // För vänster pilen, Pil Vänstyer och A
                knapptryckning = true;
            }
            else if (e.KeyCode == Keys.Escape) // Pausar spelet ifall man trycker escape
            {
                if (!pausat)
                {
                    pausat = true;
                    timer.Stop();
                    gbxMeny.Enabled = true;
                    gbxMeny.Visible = true;
                }
                else
                {
                    pausat = false;
                    timer.Start();
                    gbxMeny.Enabled = false;
                    gbxMeny.Visible = false;
                }
            }
        }

        // Tickande timer som updaterar ormen 
        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if ( i == 0)    // Logik för huvudet
                {
                    switch (snake[i].R)
                    {
                        case 1:           // Rörelse uppåt
                            snake[i].Y -= offset;
                            break;

                        case 2:           // Rörelse höger
                            snake[i].X += offset;
                            break;

                        case 3:           // Rörelse neråt
                            snake[i].Y += offset;
                            break;

                        case 4:           // Rörelse vänster
                            snake[i].X -= offset;
                            break;
                    }
                      // Kollision för kroppen
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                            GameOver();
                    }

                    // Kollision för bär
                    if (snake[i].X == bär.X && snake[i].Y == bär.Y && bärFinns)
                    {
                        bärFinns = false; // tar bort bäret
                        // Skapar nytt bär
                        Rektangel del = new Rektangel(this.Width, this.Height, offset, offset, Color.Purple);
                        snake.Add(del);

                        score++;
                        GenerateFood();
                    }

                    // Kollision för gränserna
                    if (snake[i].X < 0 || snake[i].Y < 0 || snake[i].X > this.Width - offset || snake[i].Y > this.Height - offset * 2)
                    {
                        GameOver();
                    }
                        
                }

                else // Logik för kroppen
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }

            knapptryckning = false;
            Invalidate();
        }

        // Skapar bär för ormen
        private void GenerateFood()
        {
            max_tile_w = this.Width / offset;
            max_tile_h = this.Height / offset;

            // Skapar koordniaterna för bäret
        Generera:
            bärX = generator.Next(0, max_tile_w - 2);
            bärY = generator.Next(0, max_tile_h - 3);
            bär = new Rektangel(bärX * offset, bärY * offset, offset, offset, Color.Red);

            for (int i = 0; i < snake.Count; i++)
            {
                if (snake[i].X == bär.X && snake[i].Y == bär.Y) goto Generera;
            }
            bärFinns = true;
        }

        // startar spelet
        private void StartGame()
        {
            lblTitel.Text = "Vill du spela lite Snake?";
            gbxMeny.Enabled = false;
            gbxMeny.Visible = false;
            score = 0;
            snake.Clear();
            Rektangel huvud = new Rektangel(offset, offset, offset, offset, Color.Purple);
            snake.Add(huvud);
            GenerateFood();
            timer.Start();
        }

        // Avslutar spelet
        private void GameOver()
        { 
            timer.Stop(); // Stannar spelet

            lblTitel.Text = "GAME OVER!";
            tbxPoäng.Text = (score * SliderSpeed.Value).ToString();

            gbxMeny.Enabled = true; // Viasr menyn
            gbxMeny.Visible = true;
            Highscore.Clear();
            tbxHighScore.Text = "";

            if (!File.Exists(path)) // Skapar fil ifall det inte finns
            {
                using (StreamWriter sw = File.CreateText(path));
            }
            using (StreamWriter sw = File.AppendText(path)) // Skriver in poängen i filen
            {
                sw.WriteLine(score.ToString());
            }
            try // Testar ifall det går att läsa filen
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = "";
                    while (line != null) 
                    {
                        line = sr.ReadLine(); // Gör om varje tal i txtfilen till en lista av int
                        if (line == null) goto Highscore;
                        Highscore.Add(int.Parse(line));
                    }
                Highscore:
                    Highscore.Sort(); // Sorterar listan och skriver till i textboxen
                    Highscore.Reverse();

                    for (int i = 0; i < Highscore.Count; i++)
                    {
                        tbxHighScore.AppendText(Highscore[i] + "\n");
                    }
                    tbxHighScore.SelectionStart = 0; // Ställer in textboxen att visa det största talet först
                    tbxHighScore.ScrollToCaret();
                }
            }
            catch (Exception ex) // Felmeddelande
            {
                tbxHighScore.Text = "Could not read the file";
            }

        }

        private void btnNyttSpel_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        // Sätter hastigheten av ormen
        private void SliderSpeed_Scroll(object sender, EventArgs e)
        {
            int interval = (10 - SliderSpeed.Value)* 20;
            if (interval == 0) interval = 1;
            timer.Interval = interval;
        }

        private void wmp_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            wmp.URL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Snake_Music.mp3");
        }

        private void btnNyttSpel_Enter(object sender, EventArgs e)
        {
            StartGame();
        }



    }
}
