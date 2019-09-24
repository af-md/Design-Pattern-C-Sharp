using System;

namespace TemplatePattern
{
    public class PaladingGoblin : AbstractGoblin
    {
        public PaladingGoblin()
        {
        }

        public override void DoAction()
        {
            Console.WriteLine("Attacked the enemy");
        }
 
        public override void DoBonusAction()
        {
            Console.WriteLine("Heal rangerGoblin");
        }
        
        public override void DoTurnOver()
        {
            Console.WriteLine("Turn Over");
        }
    }
}