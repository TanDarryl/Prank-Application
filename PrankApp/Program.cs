using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;

namespace PrankApp
{
    class Program
    {
        private static bool _ThreadStart = true;
        public static Random _random = new Random();
        public static int moreErractic = 0;
        static void Main(string[] args)
        {
            Thread.Sleep(300000);

            Console.WriteLine("PrankPC prank application!\nBy: Moobshake :)");

            Thread prankMouseThread = new Thread(new ThreadStart(PrankMouseThread));
            Thread prankKeyboardThread = new Thread(new ThreadStart(PrankKeyboardThread));
            Thread prankSoundThread = new Thread(new ThreadStart(PrankSoundThread));
            Thread prankPopUpThread = new Thread(new ThreadStart(PrankPopUpThread));
            Thread terminateThread = new Thread(new ThreadStart(TerminateThread));

            prankMouseThread.Start();
            prankKeyboardThread.Start();
            prankSoundThread.Start();
            prankPopUpThread.Start();
            terminateThread.Start();
        }

        public static void TerminateThread()
        {
            DateTime future = DateTime.Now.AddMinutes(3);
            while (future > DateTime.Now)
            {
                Thread.Sleep(500);
            }

            _ThreadStart = false;
        }

        public static void PrankMouseThread()
        {
            Console.WriteLine("Prank Mouse Thread Started!");
            while (_ThreadStart)
            {
                Console.WriteLine(Cursor.Position.ToString());

                switch (_random.Next(4))
                {
                    case 0:
                        Cursor.Position = new System.Drawing.Point(Cursor.Position.X - _random.Next(400), Cursor.Position.Y - _random.Next(200));
                        break;
                    case 1:
                        Cursor.Position = new System.Drawing.Point(Cursor.Position.X - _random.Next(400), Cursor.Position.Y + _random.Next(200));
                        break;
                    case 2:
                        Cursor.Position = new System.Drawing.Point(Cursor.Position.X + _random.Next(400), Cursor.Position.Y - _random.Next(200));
                        break;
                    case 3:
                        Cursor.Position = new System.Drawing.Point(Cursor.Position.X + _random.Next(400), Cursor.Position.Y + _random.Next(200));
                        break;
                }

                Thread.Sleep(15000 - moreErractic);

                if(moreErractic <= 13000)
                {
                    moreErractic += 1000;
                }
                else if(moreErractic <= 14900)
                {
                    moreErractic += 30;
                }
            }
            Console.WriteLine("Prank Mouse Thread Ended!");
        }

        public static void PrankKeyboardThread()
        {
            Console.WriteLine("Prank Keyboard Thread Started!");
            while (_ThreadStart)
            {
                char key = (char)(_random.Next(25)+65);
                if(_random.Next(2) == 0)
                {
                    key = Char.ToLower(key);
                }
                SendKeys.SendWait(key.ToString());
                Thread.Sleep(15000 - moreErractic);
            }
            Console.WriteLine("Prank Keyboard Thread Ended!");
        }

        public static void PrankSoundThread()
        {
            Console.WriteLine("Prank Sound Thread Started!");
            while (_ThreadStart)
            {
                if (_random.Next(10) < 3)
                {
                    
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                    
                }
                Thread.Sleep(15000 - moreErractic);
            }
            Console.WriteLine("Prank Sound Thread Ended!");
        }

        public static void PrankPopUpThread()
        {
            Console.WriteLine("Prank PopUp Thread Started!");
            while (_ThreadStart)
            {
                if(moreErractic < 1000)
                {
                    Thread.Sleep(160000);
                }
                else
                {
                    Thread.Sleep(1000);
                }
                MessageBox.Show("Darryl HACKED YOU MUAHAHAHAH :)", "Internet Explorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Console.WriteLine("Prank PopUp Thread Ended!");
        }
    }
}