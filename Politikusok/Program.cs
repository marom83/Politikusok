using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Politikusok
{
    class Program
    {
        static List<Person> ReadInput(string inputFileName)
        {
            List<Person> persons = new List<Person>();

            StreamReader reader = null;
            string[] tokens;

            try
            {
                reader = new StreamReader(inputFileName);
                while (!reader.EndOfStream)
                {
                    tokens = reader.ReadLine().Split(';');
                    switch (tokens.Length)
                    {
                        case 0:
                        case 1:
                            throw new ArgumentException("A txt fájl sora túl rövid");
                        case 2:
                            /*                    persons.Add(new Politician(
                                                    tokens[0],
                                                    byte.Parse(tokens[1])
                                                    ));*/
                            break;
                        default:
                            List<Competence> competences = new List<Competence>();
                            for (int i = 2; i < tokens.Length; i++)
                                competences.Add((Competence)Enum.Parse(typeof(Competence), tokens[i]));
                            /*                    persons.Add(new Student(
                                                    tokens[0],
                                                    byte.Parse(tokens[1]),
                                                    competences
                                                    ));*/
                            break;
                    }
                }
            }
            // KÜLÖNBÖZŐ KIVÉTELEK KEZELÉSE!!!
            catch(FileNotFoundException)
            {
                Console.WriteLine("Nem sikerült megnyitni a fájlt.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Vmilyen IO hiba: {0}", e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Nem sikerült  a parsolás: {0}", e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(".....");
            }
            catch (TooShortException)
            {
                Console.WriteLine("Sajnos ez túl rövid.");
            }
            catch (TooYoungException)
            {
                Console.WriteLine("Vki túé fiatal.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Vmilyen hiba történt.", e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return persons;
        }
        static void Main(string[] args)
        {
            List<Person> persons = ReadInput("persons.txt");

            // MIN. 5 AUTÓVÁSÁRLÁS ÉS 5 KOMPETENCIA TANULÁSA

            // MINDENKI LERÉSZEGÍTÉSE RANDOM LEVEL-LEL
            // KÖZBEN HA VALAKINÉL KIVÉTEL DOBÓDIK, ÍRD KI A KÉPERNYŐRE, HOGY AZ ADOTT SZEMÉLY ELSZEGÉNYEDETT/ELHÜLYÜLT

            // EMBEREK KIÍRATÁSA

            Console.ReadKey();
        }
    }
}
