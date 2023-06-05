using System;
using System.Collections.Generic;

public class Member {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double Courage { get; set; }
}

public class Bank {
    public int DifficultyLevel { get; set; }
}

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Plan Your Heist!");
        Console.WriteLine("");
         
        Console.WriteLine("Select the bank's difficulty level:");
        int difficultyLevel = int.Parse(Console.ReadLine());

          Bank bank = new Bank();
          bank.DifficultyLevel = difficultyLevel;

        int successfulRuns = 0;
        int failedRuns = 0;

         

        while (true) {
            Console.WriteLine("How many trial runs would you like?");
            int numTrialRuns = int.Parse(Console.ReadLine());
            List<int> userRuns = new List<int>();

            for (int i = 0; i < numTrialRuns; i++) {
                userRuns.Add(i);
            }

            foreach (int run in userRuns) {
                List<Member> teamMembers = new List<Member>();

                while (true) {
                    Console.WriteLine("Enter team member's name (or leave blank to stop adding members): ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                        break;

                    Console.WriteLine("Enter team member's skill level: ");
                    int skillLevel = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter team member's courage factor: ");
                    double courage = double.Parse(Console.ReadLine());

                    Member teamMember = new Member() {
                        Name = name,
                        SkillLevel = skillLevel,
                        Courage = courage
                    };

                    teamMembers.Add(teamMember);
                }

                int totalSkillLevel = 0;

                foreach (var teamMember in teamMembers) {
                    totalSkillLevel += teamMember.SkillLevel;
                }

               
                Random rnd = new Random();
                int luckValue = rnd.Next(-10, 10);

                int heistConclusion = luckValue + difficultyLevel;

                Console.WriteLine("The total skill of the team is " + totalSkillLevel);
                Console.WriteLine("The bank's difficulty level is " + heistConclusion);

                if (totalSkillLevel >= heistConclusion) {
                    Console.WriteLine("Success");
                    successfulRuns++;
                } else {
                    Console.WriteLine("Failure");
                    failedRuns++;
                }
            }

              Console.WriteLine("Successful runs: " + successfulRuns);
              Console.WriteLine("Failed runs: " + failedRuns);



            Console.WriteLine("Do you want to run another scenario? (y/n)");
            string input = Console.ReadLine();

            if (input.ToLower() != "y")
                break;
        }
    }
}
