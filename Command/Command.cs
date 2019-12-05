using System;
using NUnit.Framework;

namespace Command
{
    public  interface  ICommand
    {
        void execute(); 
    }

    public class FireBowlCommand : ICommand
    {
        public SlaveWizard Wizard;

        public FireBowlCommand(SlaveWizard wizard)
        {
            Wizard = wizard; 
        }

        public void execute()
        {
            Wizard.FireBowl();
        }
    }

    public class AcidSplashCommand : ICommand
    {
        public SlaveWizard Wizard;

        public AcidSplashCommand(SlaveWizard wizard)
        {
            Wizard = wizard; 
        }

        public void execute()
        {
            Wizard.AcidSplash();
        }
    }
    
    public class EvilGoblin
    {
        private ICommand Command;

        public void SetCommand(ICommand command)
        {
            Command = command; 
        }

        public void ExecuteCommand()
        {
            Command.execute();
        }
    }

    public class SlaveWizard
    {
        public void FireBowl()
        {
            Console.WriteLine("FireBowl Fired");
        }
        public void AcidSplash()
        {
            Console.WriteLine("Acid splashed");
        }
    }

    [TestFixture]
    public class CommandTest
    {
        [Test]
        public void Command()
        {
            //Assign the commands to the goblins
            var enslavedWizard = new SlaveWizard();
            var fireBowlCommand = new FireBowlCommand(enslavedWizard);
            var acidSplashCommand = new AcidSplashCommand(enslavedWizard);
            var dodlin = new EvilGoblin();
            dodlin.SetCommand(fireBowlCommand);
            var maggie = new EvilGoblin();
            maggie.SetCommand(acidSplashCommand);
            
            //Execute the command from the goblins/invokers 
            
            dodlin.ExecuteCommand();
            maggie.ExecuteCommand();
            
            // Output
            //FireBowl Fired
            //Acid splashed
        }
    }

}