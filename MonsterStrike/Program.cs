using System;

namespace MonsterStrike
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MonsterStrike())
                game.Run();
        }
    }
}
