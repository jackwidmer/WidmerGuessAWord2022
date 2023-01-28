// Jack Widmer
// 11/23/2022
// GuessAWord with online words.

/*
 * In Chapter 6, you created a game named GuessAWord in which a player
 * guesses letters to try to replicate a hidden word. Now create a
 * modified version of the program named GuessAWordWithExceptionHandling
 * that throws and catches an exception when the user enters a guess that
 * is not a letter of the alphabet. Create a NonLetterException class tha
 * t descends from Exception. The Message string for your new class should
 * indicate the nonletter character that caused the Exception's creation.
 * When a NonLetterException is thrown and caught, the message should be
 * displayed.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; // needed for sound player
using System.IO; // Needed for file I/O
using System.Net; // needed for WebClient
using System.Runtime.CompilerServices;

namespace WidmerGuessAWord2022
{
    public partial class frmMain : Form
    {
        //string[] words = {"powershell", "computer", "network", "linux",
        //                  "microsoft", "desktop", "keyboard", "hello"};

        // This used to be an array declaration with predefined words.
        // We now changed it to a list of type string
        List<string> words = new List<string>();

        Random random = new Random();

        string word;
        string definition;
        string hiddenWord;
        int countTries;
        

        // Add the crowd5.wav file to resources through project, project
        // properties, then resources. Add resource through existing file
        SoundPlayer audio = new SoundPlayer(WidmerGuessAWord2022.Properties
                                            .Resources.crowd5);

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            // Note: maxLength property set to 1 on txtGuess

            string myLetter;
            char[] arrayHiddenWord = hiddenWord.ToCharArray();
            //myLetter = txtGuess.Text;
            try
            {
                myLetter = GetLetter(txtGuess.Text);
                if (lblLettersUsed.Text.Contains(myLetter))
                {
                    lblStatus.Text = "You have already used that letter!";
                }
                else
                { // Letter has not been used yet
                    lblLettersUsed.Text += myLetter;
                    countTries++;

                    bool found = false;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word.Substring(i, 1) == myLetter)
                        { // A match was found. Replace the * char with the letter
                            arrayHiddenWord[i] = Convert.ToChar(myLetter);
                            found = true;
                        }
                    }
                    if (found)
                    {
                        lblStatus.Text = "Clap clap clap";
                        if(chkSoundEffects.Checked) audio.Play();
                    }
                    else
                    {
                        lblStatus.Text = "Sigh :-(";
                    }

                    hiddenWord = new string(arrayHiddenWord);
                    lblWord.Text = hiddenWord;
                    txtTries.Text = countTries.ToString();

                    // Determine if the entire word has been guessed
                    if (!hiddenWord.Contains("*"))
                    {
                        lblStatus.Text = "You solved the word!";
                        btnGuess.Enabled = false;
                        btnPlayAgain.Visible = true;
                    }

                    txtGuess.Text = "";
                    txtGuess.Focus();
                }
            } // End try
            catch(NonLetterException ex)
            {
                lblStatus.Text = "You have a bad character: " + ex.OffendingCharacter;
            }
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Read in our initial set up backup word list
            words.Add("powershell");
            words.Add("computer");
            words.Add("network");
            words.Add("linux");
            words.Add("microsoft");
            words.Add("desktop");
            words.Add("keyboard");
            words.Add("hello");

            const string FILENAME = "english_words_basic.txt";
            string lineIn;
            int lineCounter = 0; // Not really needed. Used for debugging

            try
            {
                FileStream dictionaryFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(dictionaryFile);

                dictionaryFile.Position = 0;
                lineCounter = 0;

                lineIn = reader.ReadLine();
                while (lineIn != null)
                {
                    words.Add(lineIn.ToLower());
                    lineCounter++;
                    lineIn = reader.ReadLine();
                }

                dictionaryFile.Close();
                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Dictionary not found.", "Reduced Functionality", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Console.WriteLine("lineCounter = " + lineCounter);

            // Read user preferences to a file...
            const string FILENAMEPREF = "preferences.txt";

            try
            {
                FileStream preferencesFile = new FileStream(FILENAMEPREF, FileMode.Open, FileAccess.Read);
                StreamReader readerPref = new StreamReader(preferencesFile);

                txtPlayerName.Text = readerPref.ReadLine();
                chkSoundEffects.Checked = Convert.ToBoolean(readerPref.ReadLine());

                preferencesFile.Close();
                readerPref.Close();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Preferences not set..", "Preferences Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            NewGame();
        } // frmMain_Load end

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Write user preferences to a file...
            const string FILENAMEPREF = "preferences.txt";

            FileStream preferencesFile = new FileStream(FILENAMEPREF, FileMode.Create, FileAccess.Write);
            StreamWriter writerPref = new StreamWriter(preferencesFile);

            writerPref.WriteLine(txtPlayerName.Text);
            writerPref.WriteLine(Convert.ToString(chkSoundEffects.Checked));

            writerPref.Close();
            preferencesFile.Close();

            string csvFile = "runningLog.csv";
            string playerDetails = Environment.NewLine + txtPlayerName.Text + "," + DateTime.Now.ToString("h:mm:ss tt") + 
                "," + countTries.ToString() + "," + word;

            if (!File.Exists(csvFile))
            {
                string header = "Player Name" + "," + "Date/Time" + "," + "Attempts" + "," + "Word";
                File.WriteAllText(csvFile, header);
            }

            File.AppendAllText(csvFile, playerDetails);
        }

        private void NewGame()
        {
            // word = words[random.Next(words.Length)];
            // The above code was for an array. Below is the new way!
            word = words[random.Next(words.Count)];

            // ONLINE retrieval of a word
            // Go out to the web and get a word
            try
            {
                string htmlContent;
                Console.WriteLine("About to open website.");
                using (WebClient client = new WebClient())
                {
                    string url = "https://randomword.com";
                    htmlContent = client.DownloadString(url);
                    // Console.WriteLine(htmlContent);
                }

                // <div id="random_word">quinism</div>
                string randomWordStart = @"<div id=""random_word"">";
                int startWordIndex = htmlContent.IndexOf(randomWordStart) + 22;
                int endWordIndex = htmlContent.IndexOf("</div>", startWordIndex);
                Console.WriteLine("startWordIndex = " + startWordIndex);
                Console.WriteLine("endWordIndex = " + endWordIndex);

                if (htmlContent.IndexOf(randomWordStart) != -1)
                {
                    word = htmlContent.Substring(startWordIndex, endWordIndex - startWordIndex);
                    Console.WriteLine("word = " + word);


                    //<div id="random_word_definition">pathological state resulting from excessive use of quinine  </div>

                    string randomDefinitionStart = @"<div id=""random_word_definition"">";
                    int startDefinitionIndex = htmlContent.IndexOf(randomDefinitionStart) + 33;
                    int endDefinitionIndex = htmlContent.IndexOf("</div>", startDefinitionIndex);
                    Console.WriteLine("startDefinitionIndex = " + startDefinitionIndex);
                    Console.WriteLine("endDefinitionIndex = " + endDefinitionIndex);

                    if (htmlContent.IndexOf(randomDefinitionStart) != -1)
                    {
                        definition = htmlContent.Substring(startDefinitionIndex, endDefinitionIndex - startDefinitionIndex);
                        Console.WriteLine("definition = " + definition);
                        lblDefinition.Text = definition;
                    }
                    else
                    {
                        lblDefinition.Text = "Error finding online definition.";
                    }
                }
                else
                {
                    lblDefinition.Text = "Error finding online word";
                }

            } // end try
            catch(WebException ex)
            {
                Console.WriteLine(ex.Message);
                lblDefinition.Text = "Online dictionary not found.";
            }
            hiddenWord = "";
            // Create the hiddenWord with the same number of asterisks
            // as the chosen word.
            for(int i = 0; i < word.Length; i++)
                hiddenWord += "*";

            lblWord.Text = hiddenWord;

            lblStatus.Text = "";
            txtGuess.Text = "";
            countTries = 0;
            txtTries.Text = "";

            lblLettersUsed.Text = "";
            btnPlayAgain.Visible = false;
            btnGuess.Enabled = true;

        }

        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        { // See if the enter key was pressed in the letter guess text box
            if(e.KeyCode == Keys.Enter)
            {
                btnGuess_Click(this, new EventArgs());
            }
        }

        private string GetLetter(string myString)
        {
            // Sanitize the input: make sure we have only a single character
            // a-z.
            char letter;
            if (Char.TryParse(myString, out letter))
            {
                // We have exactly one character
                letter = Char.ToLower(letter);
                if(letter < 'a' || letter > 'z')
                {
                    // Problem...
                    string badLetter = Convert.ToString(letter);
                    throw new NonLetterException(badLetter);
                }

                string goodletter = Convert.ToString(letter);
                return goodletter;
            }
            else
            {
                // TryParse failed
                throw new NonLetterException("Null or multiple characters.");
            }
        }

        
    } // End public partial class frmMain : Form

    // This is the custom exception class that the book
    // exercise is asking us to create

    public class NonLetterException : Exception
    {
        private string offendingCharacter;

        public NonLetterException() : base("A non-letter was entered.")
        {
            // Nothing else we need to do...
        }

        public NonLetterException(string nonletter)
            : base("The non-letter '" + nonletter + "' was entered.")
        {
            offendingCharacter = nonletter;
        }

        // Using built in getter
        public string OffendingCharacter
        {
            get { return offendingCharacter; }
        }
        // We did it like this the last couple weeks...
        /*
        public string GetOffendingCharacter()
        {
            return offendingCharacter;
        }
        */
    } // end public class NonLetterException : Exception

 
}
