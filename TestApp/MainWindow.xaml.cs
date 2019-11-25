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
using System.IO;

using Toub.Sound.Midi;

namespace TestApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        List<object> Music = new List<object>();
        int TagStaff;
        
        class Note
        {
            public NoteOn Tone;
            public int Tempo;
            public Note(NoteOn note, int tempo)
            {
                Tone = note;
                Tempo = tempo;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas noteCursor = new Canvas { Name = "NoteCursor", Width = 20, Height = 100 };
            Button G3 = new Button { Name = "G3", Background = null, Width = 20, Height = 10 };
            Button A3 = new Button { Name = "A3", Background = null, Width = 20, Height = 10 };
            Button B3 = new Button { Name = "B3", Background = null, Width = 20, Height = 10 };
            Button C4 = new Button { Name = "C4", Background = null, Width = 20, Height = 10 };
            Button D4 = new Button { Name = "D4", Background = null, Width = 20, Height = 10 };
            Button E4 = new Button { Name = "E4", Background = null, Width = 20, Height = 10 };
            Button F4 = new Button { Name = "F4", Background = null, Width = 20, Height = 10 };
            Button G4 = new Button { Name = "G4", Background = null, Width = 20, Height = 10 };
            Button A4 = new Button { Name = "A4", Background = null, Width = 20, Height = 10 };
            Button B4 = new Button { Name = "B4", Background = null, Width = 20, Height = 10 };
            Button C5 = new Button { Name = "C5", Background = null, Width = 20, Height = 10 };
            Button D5 = new Button { Name = "D5", Background = null, Width = 20, Height = 10 };
            Button E5 = new Button { Name = "E5", Background = null, Width = 20, Height = 10 };
            Button F5 = new Button { Name = "F5", Background = null, Width = 20, Height = 10 };
            Button G5 = new Button { Name = "G5", Background = null, Width = 20, Height = 10 };
            Button A5 = new Button { Name = "A5", Background = null, Width = 20, Height = 10 };
            Button B5 = new Button { Name = "B5", Background = null, Width = 20, Height = 10 };
            Button C6 = new Button { Name = "C6", Background = null, Width = 20, Height = 10 };

            MainCanvas.Children.Add(noteCursor);
            
            Canvas.SetTop(G3, 90);
            Canvas.SetLeft(G3, 0);
            noteCursor.Children.Add(G3);
            Canvas.SetTop(A3, 85);
            Canvas.SetLeft(A3, 0);
            noteCursor.Children.Add(A3);
            Canvas.SetTop(B3, 80);
            Canvas.SetLeft(B3, 0);
            noteCursor.Children.Add(B3);
            Canvas.SetTop(C4, 75);
            Canvas.SetLeft(C4, 0);
            noteCursor.Children.Add(C4);
            Canvas.SetTop(D4, 70);
            Canvas.SetLeft(D4, 0);
            noteCursor.Children.Add(D4);
            Canvas.SetTop(E4, 65);
            Canvas.SetLeft(E4, 0);
            noteCursor.Children.Add(E4);
            Canvas.SetTop(F4, 60);
            Canvas.SetLeft(F4, 0);
            noteCursor.Children.Add(F4);
            Canvas.SetTop(G4, 55);
            Canvas.SetLeft(G4, 0);
            noteCursor.Children.Add(G4);
            Canvas.SetTop(A4, 50);
            Canvas.SetLeft(A4, 0);
            noteCursor.Children.Add(A4);
            Canvas.SetTop(B4, 45);
            Canvas.SetLeft(B4, 0);
            noteCursor.Children.Add(B4);
            Canvas.SetTop(C5, 40);
            Canvas.SetLeft(C5, 0);
            noteCursor.Children.Add(C5);
            Canvas.SetTop(D5, 35);
            Canvas.SetLeft(D5, 0);
            noteCursor.Children.Add(D5);
            Canvas.SetTop(E5, 30);
            Canvas.SetLeft(E5, 0);
            noteCursor.Children.Add(E5);
            Canvas.SetTop(F5, 25);
            Canvas.SetLeft(F5, 0);
            noteCursor.Children.Add(F5);
            Canvas.SetTop(G5, 20);
            Canvas.SetLeft(G5, 0);
            noteCursor.Children.Add(G5);
            Canvas.SetTop(A5, 15);
            Canvas.SetLeft(A5, 0);
            noteCursor.Children.Add(A5);
            Canvas.SetTop(B5, 10);
            Canvas.SetLeft(B5, 0);
            noteCursor.Children.Add(B5);
            Canvas.SetTop(C6, 5);
            Canvas.SetLeft(C6, 0);
            noteCursor.Children.Add(C6);

            G3.Click += new RoutedEventHandler(NoteCursorClicked);
            A3.Click += new RoutedEventHandler(NoteCursorClicked);
            B3.Click += new RoutedEventHandler(NoteCursorClicked);
            C4.Click += new RoutedEventHandler(NoteCursorClicked);
            D4.Click += new RoutedEventHandler(NoteCursorClicked);
            E4.Click += new RoutedEventHandler(NoteCursorClicked);
            F4.Click += new RoutedEventHandler(NoteCursorClicked);
            G4.Click += new RoutedEventHandler(NoteCursorClicked);
            A4.Click += new RoutedEventHandler(NoteCursorClicked);
            B4.Click += new RoutedEventHandler(NoteCursorClicked);
            C5.Click += new RoutedEventHandler(NoteCursorClicked);
            D5.Click += new RoutedEventHandler(NoteCursorClicked);
            E5.Click += new RoutedEventHandler(NoteCursorClicked);
            F5.Click += new RoutedEventHandler(NoteCursorClicked);
            G5.Click += new RoutedEventHandler(NoteCursorClicked);
            A5.Click += new RoutedEventHandler(NoteCursorClicked);
            B5.Click += new RoutedEventHandler(NoteCursorClicked);
            C6.Click += new RoutedEventHandler(NoteCursorClicked);
        }

        private void ShiftCursor(Canvas currentCanvas)
        {
            foreach(UIElement child in currentCanvas.Children)
            {
                Double currentLeftLocation = Canvas.GetLeft(child);
                Double currentTopLocation = Canvas.GetTop(child);
                if(Canvas.GetLeft(child) > 760)
                {
                    Double newLeftLocation = 0;
                    Double newTopLocation = currentTopLocation + 100;
                    Canvas.SetLeft(child, newLeftLocation);
                    Canvas.SetTop(child, newTopLocation);
                }
                else
                {
                    switch (TagStaff)
                    {
                        case 0:
                            Double newLeftLocation = currentLeftLocation + 10;
                            Canvas.SetLeft(child, newLeftLocation);
                            break;
                        case 1:
                            newLeftLocation = currentLeftLocation + 20;
                            Canvas.SetLeft(child, newLeftLocation);
                            break;
                        case 2:
                            newLeftLocation = currentLeftLocation + 40;
                            Canvas.SetLeft(child, newLeftLocation);
                            break;
                        case 3:
                            newLeftLocation = currentLeftLocation + 80;
                            Canvas.SetLeft(child, newLeftLocation);
                            break;
                        case 4:
                            newLeftLocation = currentLeftLocation + 160;
                            Canvas.SetLeft(child, newLeftLocation);
                            break;
                    }
                }
            }
        }

        private void ToggleChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            TagStaff = Convert.ToInt16(radioButton.Tag);
        }

        private void NoteCursorClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Canvas canvas = button.Parent as Canvas;

            double top = (double)button.GetValue(Canvas.TopProperty);
            double left = (double)button.GetValue(Canvas.LeftProperty);
            ShiftCursor(canvas);
            DrawNote(top, left, button.Name);
        }

        private void DrawNote(double top, double left, string note)
        {
            MidiPlayer.OpenMidi();
            MidiPlayer.Play(new ProgramChange(0, 1, GeneralMidiInstruments.AcousticGrand));
            NoteOn G3 = new NoteOn(35, 1, "G3", 127);
            NoteOn A3 = new NoteOn(35, 1, "A3", 127);
            NoteOn B3 = new NoteOn(35, 1, "B3", 127);
            NoteOn C4 = new NoteOn(35, 1, "C4", 127);
            NoteOn D4 = new NoteOn(35, 1, "D4", 127);
            NoteOn E4 = new NoteOn(35, 1, "E4", 127);
            NoteOn F4 = new NoteOn(35, 1, "F4", 127);
            NoteOn G4 = new NoteOn(35, 1, "G4", 127);
            NoteOn A4 = new NoteOn(35, 1, "A4", 127);
            NoteOn B4 = new NoteOn(35, 1, "B4", 127);
            NoteOn C5 = new NoteOn(35, 1, "C5", 127);
            NoteOn D5 = new NoteOn(35, 1, "D5", 127);
            NoteOn E5 = new NoteOn(35, 1, "E5", 127);
            NoteOn F5 = new NoteOn(35, 1, "F5", 127);
            NoteOn G5 = new NoteOn(35, 1, "G5", 127);
            NoteOn A5 = new NoteOn(35, 1, "A5", 127);
            NoteOn B5 = new NoteOn(35, 1, "B5", 127);
            NoteOn C6 = new NoteOn(35, 1, "C6", 127);

            int WHOLE = 1600;
            int HALF = WHOLE / 2;
            int QUARTER = HALF / 2;
            int EIGHTH = QUARTER / 2;
            int SIXTEENTH = EIGHTH / 2;

            BitmapImage TwoExtraBitImg = new BitmapImage(new Uri("/Resources/TwoExtraBar.png", UriKind.Relative));
            Image G3TwoExtraBar = new Image();
            G3TwoExtraBar.Source = TwoExtraBitImg;
            G3TwoExtraBar.SetValue(Canvas.TopProperty, top - 10);
            G3TwoExtraBar.SetValue(Canvas.LeftProperty, left);
            Image A3TwoExtraBar = new Image();
            A3TwoExtraBar.Source = TwoExtraBitImg;
            A3TwoExtraBar.SetValue(Canvas.TopProperty, top - 5);
            A3TwoExtraBar.SetValue(Canvas.LeftProperty, left);
            Image C6TwoExtraBar = new Image();
            C6TwoExtraBar.Source = TwoExtraBitImg;
            C6TwoExtraBar.SetValue(Canvas.TopProperty, top + 5);
            C6TwoExtraBar.SetValue(Canvas.LeftProperty, left);
            BitmapImage OneExtraBitImg = new BitmapImage(new Uri("/Resources/OneExtraBar.png", UriKind.Relative));
            Image B3OneExtraBar = new Image();
            B3OneExtraBar.Source = OneExtraBitImg;
            B3OneExtraBar.SetValue(Canvas.TopProperty, top - 10);
            B3OneExtraBar.SetValue(Canvas.LeftProperty, left);
            Image C4OneExtraBar = new Image();
            C4OneExtraBar.Source = OneExtraBitImg;
            C4OneExtraBar.SetValue(Canvas.TopProperty, top - 5);
            C4OneExtraBar.SetValue(Canvas.LeftProperty, left);
            Image B5OneExtraBar = new Image();
            B5OneExtraBar.Source = OneExtraBitImg;
            B5OneExtraBar.SetValue(Canvas.TopProperty, top);
            B5OneExtraBar.SetValue(Canvas.LeftProperty, left);
            Image A5OneExtraBar = new Image();
            A5OneExtraBar.Source = OneExtraBitImg;
            A5OneExtraBar.SetValue(Canvas.TopProperty, top - 5);
            A5OneExtraBar.SetValue(Canvas.LeftProperty, left);

            switch (TagStaff)
            {
                case 0:
                    BitmapImage SixBitImg = new BitmapImage(new Uri("/Resources/SixteenthNote.png", UriKind.Relative));
                    Image SixImage = new Image();
                    SixImage.Source = SixBitImg;
                    SixImage.SetValue(Canvas.TopProperty, top - 35);
                    SixImage.SetValue(Canvas.LeftProperty, left + 1);
                    BitmapImage SixBitImgReverse = new BitmapImage(new Uri("/Resources/SixteenthNoteReverse.png", UriKind.Relative));
                    Image SixImageReverse = new Image();
                    SixImageReverse.Source = SixBitImgReverse;
                    SixImageReverse.SetValue(Canvas.TopProperty, top);
                    SixImageReverse.SetValue(Canvas.LeftProperty, left + 1);                    
                    switch (note)
                    {
                        case "G3":
                            Music.Add(new Note(G3, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            MainCanvas.Children.Add(G3TwoExtraBar);
                            break;
                        case "A3":
                            Music.Add(new Note(A3, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            MainCanvas.Children.Add(A3TwoExtraBar);
                            break;
                        case "B3":
                            Music.Add(new Note(B3, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            MainCanvas.Children.Add(B3OneExtraBar);
                            break;
                        case "C4":
                            Music.Add(new Note(C4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            MainCanvas.Children.Add(C4OneExtraBar);
                            break;
                        case "D4":
                            Music.Add(new Note(D4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            break;
                        case "E4":
                            Music.Add(new Note(E4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            break;
                        case "F4":
                            Music.Add(new Note(F4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            break;
                        case "G4":
                            Music.Add(new Note(G4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            break;
                        case "A4":
                            Music.Add(new Note(A4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImage);
                            break;
                        case "B4":
                            Music.Add(new Note(B4, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            break;
                        case "C5":
                            Music.Add(new Note(C5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            break;
                        case "D5":
                            Music.Add(new Note(D5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            break;
                        case "E5":
                            Music.Add(new Note(E5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            break;
                        case "F5":
                            Music.Add(new Note(F5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            break;
                        case "G5":
                            Music.Add(new Note(G5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            break;
                        case "A5":
                            Music.Add(new Note(A5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            MainCanvas.Children.Add(A5OneExtraBar);
                            break;
                        case "B5":
                            Music.Add(new Note(B5, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            MainCanvas.Children.Add(B5OneExtraBar);
                            break;
                        case "C6":
                            Music.Add(new Note(C6, SIXTEENTH));
                            MainCanvas.Children.Add(SixImageReverse);
                            MainCanvas.Children.Add(C6TwoExtraBar);
                            break;
                        default:
                            break;
                    }
                    break;
                case 1:
                    BitmapImage EightBitImg = new BitmapImage(new Uri("/Resources/EighthNote.png", UriKind.Relative));
                    Image EightImage = new Image();
                    EightImage.Source = EightBitImg;
                    EightImage.SetValue(Canvas.TopProperty, top - 35);
                    EightImage.SetValue(Canvas.LeftProperty, left + 1);
                    BitmapImage EightBitImgReverse = new BitmapImage(new Uri("/Resources/EighthNoteReverse.png", UriKind.Relative));
                    Image EightImageReverse = new Image();
                    EightImageReverse.Source = EightBitImgReverse;
                    EightImageReverse.SetValue(Canvas.TopProperty, top);
                    EightImageReverse.SetValue(Canvas.LeftProperty, left + 1);
                    switch (note)
                    {
                        case "G3":
                            Music.Add(new Note(G3, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            MainCanvas.Children.Add(G3TwoExtraBar);
                            break;
                        case "A3":
                            Music.Add(new Note(A3, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            MainCanvas.Children.Add(A3TwoExtraBar);
                            break;
                        case "B3":
                            Music.Add(new Note(B3, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            MainCanvas.Children.Add(B3OneExtraBar);
                            break;
                        case "C4":
                            Music.Add(new Note(C4, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            MainCanvas.Children.Add(C4OneExtraBar);
                            break;
                        case "D4":
                            Music.Add(new Note(D4, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            break;
                        case "E4":
                            Music.Add(new Note(E4, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            break;
                        case "F4":
                            Music.Add(new Note(F4, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            break;
                        case "G4":
                            Music.Add(new Note(G4, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            break;
                        case "A4":
                            Music.Add(new Note(A4, EIGHTH));
                            MainCanvas.Children.Add(EightImage);
                            break;
                        case "B4":
                            Music.Add(new Note(B4, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            break;
                        case "C5":
                            Music.Add(new Note(C5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            break;
                        case "D5":
                            Music.Add(new Note(D5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            break;
                        case "E5":
                            Music.Add(new Note(E5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            break;
                        case "F5":
                            Music.Add(new Note(F5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            break;
                        case "G5":
                            Music.Add(new Note(G5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            break;
                        case "A5":
                            Music.Add(new Note(A5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            MainCanvas.Children.Add(A5OneExtraBar);
                            break;
                        case "B5":
                            Music.Add(new Note(B5, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            MainCanvas.Children.Add(B5OneExtraBar);
                            break;
                        case "C6":
                            Music.Add(new Note(C6, EIGHTH));
                            MainCanvas.Children.Add(EightImageReverse);
                            MainCanvas.Children.Add(C6TwoExtraBar);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    BitmapImage QtrBitImg = new BitmapImage(new Uri("/Resources/QuarterNote.png", UriKind.Relative));
                    Image QtrImage = new Image();
                    QtrImage.Source = QtrBitImg;
                    QtrImage.SetValue(Canvas.TopProperty, top - 35);
                    QtrImage.SetValue(Canvas.LeftProperty, left + 1);
                    BitmapImage QtrBitImgReverse = new BitmapImage(new Uri("/Resources/QuarterNoteReverse.png", UriKind.Relative));
                    Image QtrImageReverse = new Image();
                    QtrImageReverse.Source = QtrBitImgReverse;
                    QtrImageReverse.SetValue(Canvas.TopProperty, top);
                    QtrImageReverse.SetValue(Canvas.LeftProperty, left + 1);
                    switch (note)
                    {
                        case "G3":
                            Music.Add(new Note(G3, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            MainCanvas.Children.Add(G3TwoExtraBar);
                            break;
                        case "A3":
                            Music.Add(new Note(A3, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            MainCanvas.Children.Add(A3TwoExtraBar);
                            break;
                        case "B3":
                            Music.Add(new Note(B3, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            MainCanvas.Children.Add(B3OneExtraBar);
                            break;
                        case "C4":
                            Music.Add(new Note(C4, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            MainCanvas.Children.Add(C4OneExtraBar);
                            break;
                        case "D4":
                            Music.Add(new Note(D4, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            break;
                        case "E4":
                            Music.Add(new Note(E4, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            break;
                        case "F4":
                            Music.Add(new Note(F4, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            break;
                        case "G4":
                            Music.Add(new Note(G4, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            break;
                        case "A4":
                            Music.Add(new Note(A4, QUARTER));
                            MainCanvas.Children.Add(QtrImage);
                            break;
                        case "B4":
                            Music.Add(new Note(B4, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            break;
                        case "C5":
                            Music.Add(new Note(C5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            break;
                        case "D5":
                            Music.Add(new Note(D5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            break;
                        case "E5":
                            Music.Add(new Note(E5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            break;
                        case "F5":
                            Music.Add(new Note(F5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            break;
                        case "G5":
                            Music.Add(new Note(G5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            break;
                        case "A5":
                            Music.Add(new Note(A5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            MainCanvas.Children.Add(A5OneExtraBar);
                            break;
                        case "B5":
                            Music.Add(new Note(B5, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            MainCanvas.Children.Add(B5OneExtraBar);
                            break;
                        case "C6":
                            Music.Add(new Note(C6, QUARTER));
                            MainCanvas.Children.Add(QtrImageReverse);
                            MainCanvas.Children.Add(C6TwoExtraBar);
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    BitmapImage HalfBitImg = new BitmapImage(new Uri("/Resources/HalfNote.png", UriKind.Relative));
                    Image HalfImage = new Image();
                    HalfImage.Source = HalfBitImg;
                    HalfImage.SetValue(Canvas.TopProperty, top - 35);
                    HalfImage.SetValue(Canvas.LeftProperty, left + 1);
                    BitmapImage HalfBitImgReverse = new BitmapImage(new Uri("/Resources/HalfNoteReverse.png", UriKind.Relative));
                    Image HalfImageReverse = new Image();
                    HalfImageReverse.Source = HalfBitImgReverse;
                    HalfImageReverse.SetValue(Canvas.TopProperty, top);
                    HalfImageReverse.SetValue(Canvas.LeftProperty, left + 1);
                    switch (note)
                    {
                        case "G3":
                            Music.Add(new Note(G3, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            MainCanvas.Children.Add(G3TwoExtraBar);
                            break;
                        case "A3":
                            Music.Add(new Note(A3, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            MainCanvas.Children.Add(A3TwoExtraBar);
                            break;
                        case "B3":
                            Music.Add(new Note(B3, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            MainCanvas.Children.Add(B3OneExtraBar);
                            break;
                        case "C4":
                            Music.Add(new Note(C4, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            MainCanvas.Children.Add(C4OneExtraBar);
                            break;
                        case "D4":
                            Music.Add(new Note(D4, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            break;
                        case "E4":
                            Music.Add(new Note(E4, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            break;
                        case "F4":
                            Music.Add(new Note(F4, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            break;
                        case "G4":
                            Music.Add(new Note(G4, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            break;
                        case "A4":
                            Music.Add(new Note(A4, HALF));
                            MainCanvas.Children.Add(HalfImage);
                            break;
                        case "B4":
                            Music.Add(new Note(B4, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            break;
                        case "C5":
                            Music.Add(new Note(C5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            break;
                        case "D5":
                            Music.Add(new Note(D5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            break;
                        case "E5":
                            Music.Add(new Note(E5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            break;
                        case "F5":
                            Music.Add(new Note(F5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            break;
                        case "G5":
                            Music.Add(new Note(G5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            break;
                        case "A5":
                            Music.Add(new Note(A5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            MainCanvas.Children.Add(A5OneExtraBar);
                            break;
                        case "B5":
                            Music.Add(new Note(B5, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            MainCanvas.Children.Add(B5OneExtraBar);
                            break;
                        case "C6":
                            Music.Add(new Note(C6, HALF));
                            MainCanvas.Children.Add(HalfImageReverse);
                            MainCanvas.Children.Add(C6TwoExtraBar);
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    BitmapImage bitmapImage4 = new BitmapImage(new Uri("/Resources/WholeNote.png", UriKind.Relative));
                    Image image4 = new Image();
                    image4.Source = bitmapImage4;
                    image4.SetValue(Canvas.TopProperty, top - 35);
                    image4.SetValue(Canvas.LeftProperty, left + 1);
                    MainCanvas.Children.Add(image4);
                    switch (note)
                    {
                        case "G3":
                            Music.Add(new Note(G3, WHOLE));
                            MainCanvas.Children.Add(G3TwoExtraBar);
                            break;
                        case "A3":
                            Music.Add(new Note(A3, WHOLE));
                            MainCanvas.Children.Add(A3TwoExtraBar);
                            break;
                        case "B3":
                            Music.Add(new Note(B3, WHOLE));
                            MainCanvas.Children.Add(B3OneExtraBar);
                            break;
                        case "C4":
                            Music.Add(new Note(C4, WHOLE));
                            MainCanvas.Children.Add(C4OneExtraBar);
                            break;
                        case "D4":
                            Music.Add(new Note(D4, WHOLE));
                            break;
                        case "E4":
                            Music.Add(new Note(E4, WHOLE));
                            break;
                        case "F4":
                            Music.Add(new Note(F4, WHOLE));
                            break;
                        case "G4":
                            Music.Add(new Note(G4, WHOLE));
                            break;
                        case "A4":
                            Music.Add(new Note(A4, WHOLE));
                            break;
                        case "B4":
                            Music.Add(new Note(B4, WHOLE));
                            break;
                        case "C5":
                            Music.Add(new Note(C5, WHOLE));
                            break;
                        case "D5":
                            Music.Add(new Note(D5, WHOLE));
                            break;
                        case "E5":
                            Music.Add(new Note(E5, WHOLE));
                            break;
                        case "F5":
                            Music.Add(new Note(F5, WHOLE));
                            break;
                        case "G5":
                            Music.Add(new Note(G5, WHOLE));
                            break;
                        case "A5":
                            Music.Add(new Note(A5, WHOLE));
                            MainCanvas.Children.Add(A5OneExtraBar);
                            break;
                        case "B5":
                            Music.Add(new Note(B5, WHOLE));
                            MainCanvas.Children.Add(B5OneExtraBar);
                            break;
                        case "C6":
                            Music.Add(new Note(C6, WHOLE));
                            MainCanvas.Children.Add(C6TwoExtraBar);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void PlayButtonClick(object sender, RoutedEventArgs e)
        {
            foreach(Note note in Music)
            {
                MidiPlayer.Play(note.Tone);
                System.Threading.Thread.Sleep(note.Tempo);
            }
        }
    }
}
