
namespace TemplatePattern
{
    public class TemplateTest
    {

        public void Test()
        {
            PaladingGoblin sparsh = new PaladingGoblin();
            
            sparsh.DoRound();
            
            // let's use the same skeleton but a different implementation of them 
            
            RangerGoblin ferdinand = new RangerGoblin();

            ferdinand.DoRound();
           
        }

    }
}