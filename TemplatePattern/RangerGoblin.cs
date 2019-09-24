using System;

namespace TemplatePattern
{
    public class RangerGoblin : AbstractGoblin
    {

        private int countArrow { get; set; } = 5;

        public RangerGoblin()
        {
        }

        public override void DoAction()
        {
            Console.WriteLine("Attacked the enemy");
            countArrow--; 
            Console.WriteLine("arrow left:" + countArrow);
        }

        public override void DoBonusAction()
        {
            Console.WriteLine("Hide with Paladin Goblin");
        }
        
        public override void DoTurnOver()
        {
            Console.WriteLine("Turn Over");
        }

        public override bool HasHelpedAlly()
        {
            return false; 
        }
    }
}