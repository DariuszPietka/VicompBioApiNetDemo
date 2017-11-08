
/** \mainpage Jak najprościej zaimplementować biometrię palca w aplikacji C#/.NET
 * 
 * Ten projekt pokazuje łatwy sposób realizacji tego zadania przy pomocy kompleksowego
 * rozwiązania firmy Vicomp\n
 * Hardware: certyfikowany przez FBI skaner odcisków palców Safran MorphoSmart (USB)\n
 * Software: oprogramowanie (API) VicompBioAPI z interfejsem dla C#/.NET (VicompBioApiNet.dll)\n
 * Szczegóły i kontakt: http://www.vicomp.com.pl, office@vicomp.com.pl
 * \n
 * \n
 * TO PROSTE !\n
 * 1) Włączasz do swojej aplikacji odniesienie (reference) do dwóch bibliotek VicompBioApiNet.dll i Wsq2BmpNet.dll\n
 * 2) Tworzysz instancję/obiekt klasy VicompFingerprintScanner scanner = new VicompFingerprintScanner()\n
 * 3) Odpalasz kiedy trzeba metodę scanner.startAcquistionAndSaveToFile(fileNameWithoutExt, ScannerCallback)\n
 * 4) Reagujesz na komunikaty z procesu skanowania w napisanym przez siebie callback/delegate ScannerCallback(int scanCode), gdzie:\n
 * \n
         *  scanCode = VICOMP_FINGER_SCAN_FAILED = -1 Skanowanie zakończone niepowodzeniem (timeout, anulowano lub błąd)\n
         *  scanCode = VICOMP_FINGER_SCAN_READY = 0 Skanowanie zakończone powodzeniem, trzy pliki fileNameWithoutExt zapisano na dysku
         *  z automatycznie dodanymi rozszerzeniami: wsq, bmp, raw\n
         *  scanCode = VICOMP_FINGER_SCAN_LIVE = 1 Obraz pośredni w trakcie niezakończonego jeszcze skanowania zapisano na dysku (fileNameWithoutExt.bmp)\n
         *  scanCode = VICOMP_FINGER_SCAN_EMPTY = 10 Brak palca na skanerze\n
         *  scanCode = VICOMP_FINGER_SCAN_UP = 11 Przesuń palec w górę\n
         *  scanCode = VICOMP_FINGER_SCAN_DOWN = 12 Przesuń palec w dół\n
         *  scanCode = VICOMP_FINGER_SCAN_LEFT = 13 Przesuń palec w lewo\n
         *  scanCode = VICOMP_FINGER_SCAN_RIGHT = 14 Przesuń palec w prawo\n
         *  scanCode = VICOMP_FINGER_SCAN_HARDER = 15 Mocniej przyciśnij palec do skanera\n
         *  scanCode = VICOMP_FINGER_SCAN_REMOVE = 17 Zdejmij palec ze skanera i połóż ponownie\n
         *  scanCode = VICOMP_FINGER_SCAN_GOOD = 18 Dobra jakość obrazu, tak trzymaj, za chwilę zakończę skanowanie\n
 * \n
 * Po zakończeniu skanowania masz na dysku trzy pliki obrazowe: fileNameWithoutExt.wsq, fileNameWithoutExt.bmp, fileNameWithoutExt.raw\n
 * Oczywiście, fileNameWithoutExt jest dowonym argumentem typu string, z którym wywołujesz metodę startAcquistionAndSaveToFile(...)\n 
 * \n
 * \n
 * ALE UWAGA !\n
 * Dla poprawnego budowania/debugowania oraz działania aplikacji w jej katalogu roboczym
 * muszą być obecne wszystkie następujące biblioteki:\n
 * VicompBioApiNet.dll i Wsq2BmpNet.dll - opakowanie całości dla aplikacji C#/.NET, biblioteki zarządzane,
 * tylko do nich potrzebne są odwołania w projekcie aplikacji, a dodatkowo poniższe biblioteki natywne C/C++\n
 * VicompBioAPI.dll\n
 * MORPHO_SDK.dll\n
 * MorphoGLog.dll\n
 * ImageCompress.dll\n
 * PThreadVC2.dll\n
 * GrFinger.dll\n
 * \n
 * \n
 * Jeśli cokolwiek wymaga dojaśnienia, proszę pytać: darek@vicomp.com.pl
*/

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using VicompBioApiNet;

namespace VicompBioApiNetDemo
{
    /** Główne okno aplikacji (innych okien nie ma).
     * 
     *  Cała funkcjonalność aplikacji zawarta jest w tej klasie.
     *  Aplikacja demonstruje sposób użycia pakietu VicompBioAPI,
     *  służącego do skanowania i weryfikacji ocisków palców.
     */
    public partial class FormMain : Form
    {
        VicompFingerprintScanner scanner = new VicompFingerprintScanner();
        string ScanFileWithoutExt = "scan"; // rdzeń nazwy generowanych plików skanera
        System.Timers.Timer timer; // do pokazywania upływu czasu przy czekaniu na palec (progressBar)

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (buttonTest.Text == "Anuluj")
            {
                // Skanowanie asynchroniczne w toku i naciśnięto "Anuluj"
                scanner.cancelAsyncAcquisition();
                return;
            }

            // Wyczyść obrazek na ekranie i usuń stare pliki obrazowe z dysku
            if (pictureBox.Image != null)
                pictureBox.Image = null;
            if (File.Exists(ScanFileWithoutExt + ".wsq"))
                File.Delete(ScanFileWithoutExt + ".wsq");
            if (File.Exists(ScanFileWithoutExt + ".bmp"))
                File.Delete(ScanFileWithoutExt + ".bmp");
            if (File.Exists(ScanFileWithoutExt + ".raw"))
                File.Delete(ScanFileWithoutExt + ".raw");

            progressBar.Value = 0;
            progressBar.Visible = true;
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
            timer.Interval = 1000;
            timer.Start();

            // Uwaga, podajemy nazwę pliku bez rozszerzenia, na wyjściu powstaną trzy pliki: .wsq, .bmp i .raw
            // Możemy odpalić skan asynchroniczny podając delegata lub synchroniczny, gdy jako delegata podamy
            // null, ale wtedy blokujemy główny wątek do momentu zakończenia skanowania

            if (radioButtonSync.Checked)
            {
                labelMessage.Text = "Startuję skaner i czekam na położenie palca ...";
                labelMessage.Refresh();
                buttonTest.Enabled = false;
                if (scanner.startAcquisitionAndSaveToFile(ScanFileWithoutExt, null) == 0) // OK
                {
                    if (File.Exists(ScanFileWithoutExt + ".bmp"))
                    {
                        labelMessage.Text = "Pliki obrazowe zapisano w katalogu roboczym aplikacji.";
                        pictureBox.Image = Image.FromFile(ScanFileWithoutExt + ".bmp");
                        pictureBox.Refresh();
                        pictureBox.Image.Dispose();
                    }
                    else
                    {
                        labelMessage.Text = "Problem z zapisem kompletu plików po skanowaniu.";
                    }
                }
                else
                {
                    labelMessage.Text = "Problem ze skanowaniem odcisku palca.\n" +
                                        "Kiknij \"Test\", żeby powtórzyć próbę.";
                }

                buttonTest.Enabled = true;
                timer.Stop();
                progressBar.Visible = false;
            }
            else
            { 
                if (scanner.startAcquisitionAndSaveToFile(ScanFileWithoutExt, ScannerCallback) == 0) // OK
                {
                    labelMessage.Text = "Skaner wystartował, czekam na położenie palca ...";
                    buttonTest.Text = "Anuluj";
                }
                else
                    labelMessage.Text = "Problem z wystartowaniem skanera. Czy podłączony?";
            }
        }

        private void OnTimerEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            progressBar.Invoke((MethodInvoker)(() => progressBar.Value = progressBar.Value + 1));
        }

        /** Po odpaleniu skanowania funkcją startAcquisitionAndSaveToFile(...) zajmujesz się tylko obsługą zdarzeń w tym callbacku
         * 
         *  \param scanCode - kod zdarzenia komunikowanego użytkownikowi
         *  
         *  Możliwe do otrzymania wartości scanCode:\n
         *  VICOMP_FINGER_SCAN_FAILED = -1 Skanowanie zakończone niepowodzeniem (timeout, anulowano lub błąd)\n
         *  VICOMP_FINGER_SCAN_READY = 0 Skanowanie zakończone powodzeniem, trzy pliki zapisano na dysku (.wsq, .bmp, .raw)\n
         *  VICOMP_FINGER_SCAN_LIVE = 1 Obraz pośredni w trakcie niezakończonego jeszcze skanowania zapisano na dysku (.bmp)\n
         *  VICOMP_FINGER_SCAN_EMPTY = 10 Brak palca na skanerze\n
         *  VICOMP_FINGER_SCAN_UP = 11 Przesuń palec w górę\n
         *  VICOMP_FINGER_SCAN_DOWN = 12 Przesuń palec w dół\n
         *  VICOMP_FINGER_SCAN_LEFT = 13 Przesuń palec w lewo\n
         *  VICOMP_FINGER_SCAN_RIGHT = 14 Przesuń palec w prawo\n
         *  VICOMP_FINGER_SCAN_HARDER = 15 Mocniej przyciśnij palec do skanera\n
         *  VICOMP_FINGER_SCAN_REMOVE = 17 Zdejmij palec ze skanera i połóż ponownie\n
         *  VICOMP_FINGER_SCAN_GOOD = 18 Dobra jakość obrazu, tak trzymaj, za chwilę zakończę skanowanie\n
         */
        public void ScannerCallback(int scanCode)
        {
            // Uwaga, potrzebna synchronizacja, w tym specjalne operacje na kontrolkach GUI,
            // ponieważ wykonując kod w callbacku jesteśmy w innym wątku niż główny.

            if (scanCode == VICOMP_FINGER_SCAN_READY) // OK, skany gotowe w plikach na dysku, to jest koniec skanowania
            {
                if (File.Exists(ScanFileWithoutExt+".bmp")) // dla pewności
                {
                    labelMessage.Invoke((MethodInvoker)(() => labelMessage.Text = "Pliki obrazowe zapisano w katalogu roboczym aplikacji."));
                    using (Bitmap bmp = new Bitmap(ScanFileWithoutExt + ".bmp"))
                    {
                        pictureBox.Invoke((MethodInvoker)(() => pictureBox.Image = new Bitmap(bmp)));
                    }
                }
                else
                {
                    labelMessage.Invoke((MethodInvoker)(() => labelMessage.Text = "Problem z plikami obrazowymi po skanowaniu."));
                }
            }
            else
            if (scanCode == VICOMP_FINGER_SCAN_LIVE) // OK, żywy obraz w trakcie skanowania, ale to nie koniec skanowania
            {
                if (File.Exists(ScanFileWithoutExt + ".bmp")) // dla pewności
                {
                    using (Bitmap bmp = new Bitmap(ScanFileWithoutExt + ".bmp"))
                    {
                        pictureBox.Invoke((MethodInvoker)(() => pictureBox.Image = new Bitmap(bmp)));
                    }
                }
                return;
            }
            else
            if (scanCode == VICOMP_FINGER_SCAN_FAILED) // DUPA, koniec skanowania, ale nie ma obrazów
            {
                labelMessage.Invoke((MethodInvoker)(() => labelMessage.Text = "Anulowano, timeout lub jakiś inny problem ze skanowaniem.\n" +
                                                                              "Kiknij \"Test\", żeby powtórzyć próbę."));
                pictureBox.Invoke((MethodInvoker)(() => pictureBox.Image = null));
            }
            else // Wszystkie inne możliwe eventy, które nie kończą procesu skanowania            
            {
                // W przypadku aplikacji do kontroli dokumentów nie trzeba chyba obsługiwać tych zdarzeń,
                // bo szczerze mówiąc, nie wiadomo jak je pokazać klientowi, od którego pobieramy odcisk
                // palca. A to do niego są głównie skierowane te komunikaty. Nie będziemy przecież obracać
                // ekranu, żeby pokazać strzałki, w którą stronę ma przesunąć palec i inne tego typu wskazówki.

                pictureBoxUp.Invoke((MethodInvoker)(() => pictureBoxUp.Visible = false));
                pictureBoxDown.Invoke((MethodInvoker)(() => pictureBoxDown.Visible = false));
                pictureBoxLeft.Invoke((MethodInvoker)(() => pictureBoxLeft.Visible = false));
                pictureBoxRight.Invoke((MethodInvoker)(() => pictureBoxRight.Visible = false));

                switch (scanCode)
                {
                    case VICOMP_FINGER_SCAN_EMPTY:
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Nie widzę palca, czekam na położenie ..."));
                        break;
                    case VICOMP_FINGER_SCAN_UP:
                        pictureBoxUp.Invoke((MethodInvoker)(() => pictureBoxUp.Visible = true));
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Przesuń palec w górę"));
                        break;
                    case VICOMP_FINGER_SCAN_DOWN:
                        pictureBoxDown.Invoke((MethodInvoker)(() => pictureBoxDown.Visible = true));
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Przesuń palec w dół"));
                        break;
                    case VICOMP_FINGER_SCAN_LEFT:
                        pictureBoxLeft.Invoke((MethodInvoker)(() => pictureBoxLeft.Visible = true));
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Przesuń paec w lewo"));
                        break;
                    case VICOMP_FINGER_SCAN_RIGHT:
                        pictureBoxRight.Invoke((MethodInvoker)(() => pictureBoxRight.Visible = true));
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Przesuń palec w prawo"));
                        break;
                    case VICOMP_FINGER_SCAN_HARDER:
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Przyciśnij palec mocniej ..."));
                        break;
                    case VICOMP_FINGER_SCAN_REMOVE:
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "Jakiś problem, zabierz palec i połóż ponownie ..."));
                        break;
                    case VICOMP_FINGER_SCAN_GOOD:
                        labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = "OK, wystarczy do weryfikacji, tak trzymaj ..."));
                        break;
                }

                return;
            }
          
            // Koniec skanowania
            timer.Stop();
            buttonTest.Invoke((MethodInvoker)(() => buttonTest.Text = "Test"));
            progressBar.Invoke((MethodInvoker)(() => progressBar.Visible = false));
            labelSubMessage.Invoke((MethodInvoker)(() => labelSubMessage.Text = ""));
            pictureBoxUp.Invoke((MethodInvoker)(() => pictureBoxUp.Visible = false));
            pictureBoxDown.Invoke((MethodInvoker)(() => pictureBoxDown.Visible = false));
            pictureBoxLeft.Invoke((MethodInvoker)(() => pictureBoxLeft.Visible = false));
            pictureBoxRight.Invoke((MethodInvoker)(() => pictureBoxRight.Visible = false));
        }

    } // end of class

} // end of namespace
