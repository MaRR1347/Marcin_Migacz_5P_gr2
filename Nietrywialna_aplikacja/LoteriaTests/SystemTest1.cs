using System.Diagnostics;

namespace Loteria
{
    public class SystemTests
    {
        // Scieżka do skompilowanego pliku wykonywalnego aplikacji (.exe)
        private readonly string _sciezkaDoAplikacji = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Loteria.exe");

        // Helper uruchamiający proces systemowy aplikacji
        private (int ExitCode, string Output) UruchomProcesSystemowy(string input)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = _sciezkaDoAplikacji,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                using (StreamWriter sw = process.StandardInput)
                {
                    sw.WriteLine(input);
                }

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit(5000); // Timeout 5 sekund

                return (process.ExitCode, output);
            }
        }

        // TEST 1 (poprawny): Poprawne uruchomienie i zakończenie procesu w systemie
        [Fact]
        public void System_UruchomienieAplikacji_ZwracaKodSukcesuZero()
        {
            var (exitCode, output) = UruchomProcesSystemowy("1");

            Assert.Equal(0, exitCode);
            Assert.Contains("Ile wygenerować losowań?", output);
            Assert.Contains("Zestawy wylosowanych liczb:", output);
        }

        // TEST 2 (poprawny): Weryfikacja struktury wyjścia systemowego dla wielu zestawów
        [Fact]
        public void System_GenerowanieWieluZestawow_FormatWyjsciaZgodnyZWymaganiami()
        {
            var (exitCode, output) = UruchomProcesSystemowy("3");

            Assert.Equal(0, exitCode);
            Assert.Contains("Losowanie 1:", output);
            Assert.Contains("Losowanie 2:", output);
            Assert.Contains("Losowanie 3:", output);
            Assert.DoesNotContain("Losowanie 4:", output);
            Assert.Contains("Wystąpienia liczby 49:", output);
        }

        // TEST 3 (poprawny): Wydajność systemowa - generowanie dużej liczby losowań
        [Fact]
        public void System_SzybkosceDzialania_WykonanieDlaDuzejLiczbyLosowan()
        {
            // Arrange
            Stopwatch stoper = Stopwatch.StartNew();

            // Act
            var (exitCode, output) = UruchomProcesSystemowy("1000");
            stoper.Stop();

            // Assert
            Assert.Equal(0, exitCode);
            Assert.Contains("Losowanie 1000:", output);
            Assert.True(stoper.ElapsedMilliseconds < 2000, $"Czas wykonania wyniósł {stoper.ElapsedMilliseconds} ms, oczekiwano poniżej 2000 ms.");
        }

        // TEST 4 (niepoprawny): Reakcja systemu na niepoprawne dane wejściowe
        [Fact]
        public void System_BledneDaneWejsciowe_ZwracaObsluzonyBdadIObrywaProces()
        {
            // Act
            var (exitCode, output) = UruchomProcesSystemowy("nie_liczba");

            // Assert
            Assert.Equal(0, exitCode); // Aplikacja nie może się skraszować (crash/exception)
            Assert.Contains("Niepoprawna wartość. Podaj liczbę całkowitą większą od 0", output);
            Assert.DoesNotContain("Zestawy wylosowanych liczb:", output);
        }
    }
}