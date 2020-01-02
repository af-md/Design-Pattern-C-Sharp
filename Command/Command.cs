using System;
using NUnit.Framework;

namespace Command
{
    public  interface  Command
    {
        void execute(); 
    }

    public class FireBowlConcreteCommand : Command
    {
        public SlaveWizard Wizard;

        public FireBowlConcreteCommand(SlaveWizard wizard)
        {
            Wizard = wizard; 
        }

        public void execute()
        {
            Wizard.FireBowl();
        }
    }

    public class AcidSplashConcreteCommand : Command
    {
        public SlaveWizard Wizard;

        public AcidSplashConcreteCommand(SlaveWizard wizard)
        {
            Wizard = wizard; 
        }

        public void execute()
        {
            Wizard.AcidSplash();
        }
    }
    
    public class EvilGoblinInvoker
    {
        private Command Command;

        public void SetCommand(Command command)
        {
            Command = command; 
        }

        public void ExecuteCommand()
        {
            Command.execute();
        }
    }

    public class SlaveWizardReceiver
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
            var fireBowlCommand = new FireBowlConcreteCommand(enslavedWizard);
            var acidSplashCommand = new AcidSplashConcreteCommand(enslavedWizard);
            var dodlin = new EvilGoblinInvoker();
            dodlin.SetCommand(fireBowlCommand);
            var maggie = new EvilGoblinInvoker();
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