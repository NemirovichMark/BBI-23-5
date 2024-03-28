//2 уровень 4 задание 
using System;


struct Sportsman
{
    public string lastName;
    public float[] jumpDifficulties;
    public float[] jumpScores;
    public float totalScore;


    class Program
    {
        static void Main(string[] args)
        {
            
            Sportsman[] sportsmen = new Sportsman[5];

            
            sportsmen[0].lastName = "Иванов";
            sportsmen[0].jumpDifficulties = new float[] { 3.0f, 2.5f, 3.5f, 3.0f };
            sportsmen[0].jumpScores = new float[] { 5.0f, 5.5f, 6.0f, 4.5f };

            sportsmen[1].lastName = "Петров";
            sportsmen[1].jumpDifficulties = new float[] { 2.5f, 3.0f, 2.5f, 3.0f };
            sportsmen[1].jumpScores = new float[] { 6.0f, 5.5f, 6.5f, 5.0f };

            sportsmen[2].lastName = "Сидоров";
            sportsmen[2].jumpDifficulties = new float[] { 3.5f, 3.0f, 3.0f, 3.5f };
            sportsmen[2].jumpScores = new float[] { 5.5f, 6.0f, 5.5f, 6.0f };

            sportsmen[3].lastName = "Козлов";
            sportsmen[3].jumpDifficulties = new float[] { 2.5f, 2.5f, 3.0f, 2.5f };
            sportsmen[3].jumpScores = new float[] { 5.0f, 5.0f, 5.0f, 5.0f };

            sportsmen[4].lastName = "Смирнов";
            sportsmen[4].jumpDifficulties = new float[] { 3.0f, 2.5f, 2.5f, 3.5f };
            sportsmen[4].jumpScores = new float[] { 4.5f, 4.5f, 5.0f, 4.5f };

            
            for (int i = 0; i < sportsmen.Length; i++)
            {
                float totalScore = 0;

               
                for (int j = 0; j < sportsmen[i].jumpScores.Length - 1; j++)
                {
                    for (int k = j + 1; k < sportsmen[i].jumpScores.Length; k++)
                    {
                        if (sportsmen[i].jumpScores[j] < sportsmen[i].jumpScores[k])
                        {
                            float temp = sportsmen[i].jumpScores[j];
                            sportsmen[i].jumpScores[j] = sportsmen[i].jumpScores[k];
                            sportsmen[i].jumpScores[k] = temp;
                        }
                    }
                }

                
                for (int j = 1; j < sportsmen[i].jumpScores.Length - 1; j++)
                {
                    totalScore += sportsmen[i].jumpScores[j];
                }

                totalScore *= sportsmen[i].jumpDifficulties[0];

               
                sportsmen[i].totalScore = totalScore;
            }

            for (int i = 0; i < sportsmen.Length - 1; i++)
            {
                for (int j = i + 1; j < sportsmen.Length; j++)
                {
                    if (sportsmen[i].totalScore < sportsmen[j].totalScore)
                    {
                        Sportsman temp = sportsmen[i];
                        sportsmen[i] = sportsmen[j];
                        sportsmen[j] = temp;
                    }
                }
            }

            
            for (int i = 0; i < sportsmen.Length; i++)
            {
                Console.WriteLine($"Спортсмен {sportsmen[i].lastName}: итоговая оценка - {sportsmen[i].totalScore}");
            }
        }
    }
}


