using System;
using NUnit.Framework;

namespace TemplatePattern
{
    public abstract class AbstractGoblin 
    {
        // members declare here

        public void DoRound()
        {
            DoAction();
            DoBonusAction();
            DoTurnOver();
            //hook usage   
            if (HasHelpedAlly())
            {
                DoGiveBonus();
            }
        }

        public abstract void DoAction();

        public abstract void DoBonusAction();

        public abstract void DoTurnOver();

        public void DoGiveBonus()
        {
            Console.WriteLine("5 Bonus added");
        }

        public virtual bool HasHelpedAlly()
        {
            return true; 
        }

    }
}